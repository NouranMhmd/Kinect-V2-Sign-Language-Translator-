/*******************************************************************************

INTEL CORPORATION PROPRIETARY INFORMATION
This software is supplied under the terms of a license agreement or nondisclosure
agreement with Intel Corporation and may not be copied or disclosed except in
accordance with the terms of that agreement
Copyright(c) 2013 Intel Corporation. All Rights Reserved.

*******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace voice_recognition.cs
{
    public partial class MainForm2 : Form
    {
        protected PXCMSession session;

        protected string curr_module_name;
        protected uint curr_language;
        protected int curr_volume;
        protected int curr_pitch;
        protected int curr_speech_rate;

        public MainForm2(PXCMSession session)
        {
            this.session = session;
            curr_module_name = "";
            curr_language = 0;
            curr_volume = 80;
            curr_pitch = 100;
            curr_speech_rate = 100;
            InitializeComponent();

            PropogateModule();
            PropogateLanguage();
        }

        private void PropogateModule()
        {
            PXCMSession.ImplDesc desc=new PXCMSession.ImplDesc();
            desc.cuids[0] = PXCMSpeechSynthesis.CUID;
            ToolStripMenuItem mm=new ToolStripMenuItem("Module");
            for (int i = 0; ; i++)
            {
                PXCMSession.ImplDesc desc1;
                if (session.QueryImpl(desc, i, out desc1) < pxcmStatus.PXCM_STATUS_NO_ERROR) break;
                ToolStripMenuItem tsmi = new ToolStripMenuItem(desc1.friendlyName, null, new EventHandler(Module_Item_Click));
                if (i == 0) tsmi.Checked = true;
                mm.DropDownItems.Add(tsmi);
            }
            MainMenu.Items.RemoveAt(0);
            MainMenu.Items.Insert(0,mm);
        }

        private void PropogateLanguage()
        {
            ToolStripMenuItem lm = new ToolStripMenuItem("Language");

            PXCMSession.ImplDesc desc = new PXCMSession.ImplDesc();
            desc.cuids[0] = PXCMSpeechSynthesis.CUID;
            desc.friendlyName=GetCheckedModule();
            PXCMSpeechSynthesis vsynth;
            if (session.CreateImpl<PXCMSpeechSynthesis>(desc, out vsynth) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                for (int i = 0; ; i++)
                {
                    PXCMSpeechSynthesis.ProfileInfo pinfo;
                    if (vsynth.QueryProfile(i, out pinfo) < pxcmStatus.PXCM_STATUS_NO_ERROR) break;

                    ToolStripMenuItem tsmi = new ToolStripMenuItem(LanguageToString(pinfo.language), null, new EventHandler(Language_Item_Click));
                    if (i == 0) tsmi.Checked = true;
                    lm.DropDownItems.Add(tsmi);
                }
                vsynth.Dispose();
            }

            MainMenu.Items.RemoveAt(1);
            MainMenu.Items.Insert(1, lm);
        }

        private string GetCheckedModule()
        {
            foreach (ToolStripMenuItem m in MainMenu.Items) {
                if (!m.Text.Equals("Module")) continue;
                foreach (ToolStripMenuItem e in m.DropDownItems) {
                    if (e.Checked) return e.Text;
                }
            }
            return null;
        }

        private int GetCheckedLanguage()
        {
            foreach (ToolStripMenuItem m in MainMenu.Items)
            {
                if (!m.Text.Equals("Language")) continue;
                for (int i=0;i<m.DropDownItems.Count;i++) {
                    if ((m.DropDownItems[i] as ToolStripMenuItem).Checked) 
                        return i;
                }
            }
            return 0;
        }

        private void RadioCheck(object sender, string name)
        {
            foreach (ToolStripMenuItem m in MainMenu.Items)
            {
                if (!m.Text.Equals(name)) continue;
                foreach (ToolStripMenuItem e1 in m.DropDownItems)
                {
                    e1.Checked = (sender == e1);
                }
            }
        }

        private void Module_Item_Click(object sender, EventArgs e)
        {
            RadioCheck(sender, "Module");
        }

        private void Language_Item_Click(object sender, EventArgs e)
        {
            RadioCheck(sender, "Language");
        }

        private void Speak_Click(object sender, EventArgs e)
        {
            if (Sentence.Text.Length == 0)
            {
                MessageBox.Show("Empty string");
                Sentence.Text = "The string should not be empty";
            }
            string sts=VoiceSynthesis.Speak(GetCheckedModule(),GetCheckedLanguage(),Sentence.Text, 
                curr_volume, curr_pitch, curr_speech_rate);
            if (sts != null) MessageBox.Show(sts);
        }

        private string LanguageToString(PXCMSpeechSynthesis.LanguageType language)
        {
        	switch (language) {
	        case PXCMSpeechSynthesis.LanguageType.LANGUAGE_US_ENGLISH:		return "US English";
	        case PXCMSpeechSynthesis.LanguageType.LANGUAGE_GB_ENGLISH:		return "British English";
	        case PXCMSpeechSynthesis.LanguageType.LANGUAGE_DE_GERMAN:		return "Deutsch";
	        case PXCMSpeechSynthesis.LanguageType.LANGUAGE_IT_ITALIAN:		return "italiano";
	        case PXCMSpeechSynthesis.LanguageType.LANGUAGE_BR_PORTUGUESE:	return "PORTUGUÊS";
	        case PXCMSpeechSynthesis.LanguageType.LANGUAGE_CN_CHINESE:		return "中文";
	        case PXCMSpeechSynthesis.LanguageType.LANGUAGE_FR_FRENCH:		return "Français";
	        case PXCMSpeechSynthesis.LanguageType.LANGUAGE_JP_JAPANESE:	    return "日本語";
	        case PXCMSpeechSynthesis.LanguageType.LANGUAGE_US_SPANISH:		return "español";
	        }
	        return null;
        }
        private void SetVolume_ValueChanged(object sender, EventArgs e)
        {
            curr_volume = (int) SetVolume.Value;
        }
        private void SetPitch_ValueChanged(object sender, EventArgs e)
        {
            curr_pitch = (int)SetPitch.Value;
        }
        private void SetSpeechRate_ValueChanged(object sender, EventArgs e)
        {
            curr_speech_rate = (int)SetSpeechRate.Value;
        }
    }
}
