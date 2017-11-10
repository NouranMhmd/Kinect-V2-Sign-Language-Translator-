/*******************************************************************************

INTEL CORPORATION PROPRIETARY INFORMATION
This software is supplied under the terms of a license agreement or nondisclosure
agreement with Intel Corporation and may not be copied or disclosed except in
accordance with the terms of that agreement
Copyright(c) 2013-2014 Intel Corporation. All Rights Reserved.

*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace voice_recognition.cs
{
    class VoiceRecognition
    {
        MainForm form;
        PXCMAudioSource source;
        PXCMSpeechRecognition sr;

        void OnRecognition(PXCMSpeechRecognition.RecognitionData data)
        {
            if (data.scores[0].label < 0)
            {
                form.PrintConsole(data.scores[0].sentence);
                if (data.scores[0].tags.Length > 0)
                    form.PrintConsole(data.scores[0].tags);
            }
            else
            {
                form.ClearScores();
                for (int i = 0; i < PXCMSpeechRecognition.NBEST_SIZE; i++)
                {
                    int label = data.scores[i].label;
                    int confidence = data.scores[i].confidence;
                    if (label < 0 || confidence == 0) continue;
                    form.SetScore(label, confidence);
                }
                if (data.scores[0].tags.Length > 0)
                    form.PrintConsole(data.scores[0].tags);
            }

        }

        void OnAlert(PXCMSpeechRecognition.AlertData data)
        {
            form.PrintStatus(form.AlertToString(data.label));
        }

        void CleanUp() {
            if (sr != null)
            {
                sr.Dispose();
                sr = null;
            }
            if (source != null)
            {
                source.Dispose();
                source = null;
            }
        }

        public bool SetVocabularyFromFile(String VocFilename)
        {

            pxcmStatus sts = sr.AddVocabToDictation(PXCMSpeechRecognition.VocabFileType.VFT_LIST, VocFilename);
            if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR) return false;

            return true;
        }

        bool SetGrammarFromFile(String GrammarFilename) 
        {

            Int32 grammar = 1;

	        pxcmStatus sts = sr.BuildGrammarFromFile(grammar, PXCMSpeechRecognition.GrammarFileType.GFT_NONE, GrammarFilename);
	        if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR) {
		        form.PrintStatus("Grammar Compile Errors:");
                form.PrintStatus(sr.GetGrammarCompileErrors(grammar));
		        return false;
	        }

	        sts = sr.SetGrammar(grammar);
	        if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR) return false;


            return true;
        }

        public void DoIt(MainForm form1, PXCMSession session) {
            form = form1;

            /* Create the AudioSource instance */
            source=session.CreateAudioSource();

            if (source == null) {
                CleanUp();
                form.PrintStatus("Stopped");
                return;
            }

            /* Set audio volume to 0.2 */
            source.SetVolume(0.2f);

        	/* Set Audio Source */
	        source.SetDevice(form.GetCheckedSource());

	        /* Set Module */
            PXCMSession.ImplDesc mdesc = new PXCMSession.ImplDesc();
            mdesc.iuid=form.GetCheckedModule();

            pxcmStatus sts = session.CreateImpl<PXCMSpeechRecognition>(out sr);
            if (sts >= pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                /* Configure */
                PXCMSpeechRecognition.ProfileInfo pinfo;
                sr.QueryProfile(form.GetCheckedLanguage(), out pinfo);
                sr.SetProfile(pinfo);

                /////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////////////////


                /* Set Command/Control or Dictation */
                if (form.IsCommandControl())
                {
                    string[] cmds = form.GetCommands();
                    if (form.g_file != null && form.g_file.Length != 0)
                    {
                        if(form.g_file.EndsWith(".list")){
                            form.FillCommandListConsole(form.g_file);
                            cmds = form.GetCommands();
					        if (cmds.GetLength(0) == 0)
						        form.PrintStatus("Command List Load Errors");
                        }

                        // input Command/Control grammar file available, use it
                        if (!SetGrammarFromFile(form.g_file))
                        {
					        form.PrintStatus("Can not set Grammar From File.");
					        CleanUp();
                            return;
				        };
                    }
                    else if (cmds != null && cmds.GetLength(0) != 0)
                    {
                        // voice commands available, use them
				        sr.BuildGrammarFromStringList(1, cmds, null);
                        sr.SetGrammar(1);
                    } else {
                        form.PrintStatus("No Command List. Dictation instead.");
                        if (form.v_file != null && form.v_file.Length != 0) SetVocabularyFromFile(form.v_file);
                        sr.SetDictation();
                    }
                }
                else
                {
                    if (form.v_file != null && form.v_file.Length != 0) SetVocabularyFromFile(form.v_file);
                    sr.SetDictation();
                }

            	/* Initialization */
	            form.PrintStatus("Init Started");
                PXCMSpeechRecognition.Handler handler = new PXCMSpeechRecognition.Handler();
                handler.onRecognition=OnRecognition;
                handler.onAlert=OnAlert;
                
                sts=sr.StartRec(source, handler);
                if (sts>=pxcmStatus.PXCM_STATUS_NO_ERROR) {
                    form.PrintStatus("Init OK");

                    /* Wait until the stop button is clicked */
                    while (!form.IsStop()) {
                        System.Threading.Thread.Sleep(5);
                    }

                    sr.StopRec();
                } else {
                    form.PrintStatus("Failed to initialize");
                }
	        } else {
		        form.PrintStatus("Init Failed");
        	}

            CleanUp();
	        form.PrintStatus("Stopped");
        }
    }
}
