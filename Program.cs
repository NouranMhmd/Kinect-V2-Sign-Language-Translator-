/*******************************************************************************

INTEL CORPORATION PROPRIETARY INFORMATION
This software is supplied under the terms of a license agreement or nondisclosure
agreement with Intel Corporation and may not be copied or disclosed except in
accordance with the terms of that agreement
Copyright(c) 2013 Intel Corporation. All Rights Reserved.

*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Metrilus.Aiolos;
using Metrilus.Aiolos.Core;
using Metrilus.Aiolos.Kinect;
using Microsoft.Kinect;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;

namespace voice_recognition.cs
{
    static class Program
    {

        private static int cursorTop;
        private static int cursorLeft;
        private static KinectSensor kinectSensor;
        private static int width;
        private static int height;
        private static MultiSourceFrameReader reader;
        private static ushort[] depthFrameData;
        private static ushort[] irFrameData;
        private static Body[] bodies;
        private static CoordinateMapper coordinateMapper;
        private static MultiSourceFrameReference frameReference;
        private static object updateLock = new object();
        private static AutoResetEvent dataAvailable = new AutoResetEvent(false);
        private static bool isConnected;
        private static KinectEngine engine = new KinectEngine();

        //  Dictionary<string, string> words =  new Dictionary<string, string>();

        private static void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            lock (updateLock)
            {
                frameReference = e.FrameReference;
            }
            dataAvailable.Set();
        }

        /// <summary>
        /// Update to get a new frame. 
        /// This code is similar to the code in the Kinect SDK samples.
        /// </summary>
        private static void Update()
        {
            if (!isConnected)
                return;

            dataAvailable.WaitOne();

            MultiSourceFrame multiSourceFrame = null;
            DepthFrame depthFrame = null;
            InfraredFrame irFrame = null;
            BodyFrame bodyFrame = null;

            lock (updateLock)
            {
                try
                {
                    if (frameReference != null)
                    {
                        multiSourceFrame = frameReference.AcquireFrame();

                        if (multiSourceFrame != null)
                        {
                            DepthFrameReference depthFrameReference = multiSourceFrame.DepthFrameReference;
                            InfraredFrameReference irFrameReference = multiSourceFrame.InfraredFrameReference;
                            BodyFrameReference bodyFrameReference = multiSourceFrame.BodyFrameReference;

                            depthFrame = depthFrameReference.AcquireFrame();
                            irFrame = irFrameReference.AcquireFrame();

                            if ((depthFrame != null) && (irFrame != null))
                            {
                                FrameDescription depthFrameDescription = depthFrame.FrameDescription;
                                FrameDescription irFrameDescription = irFrame.FrameDescription;

                                int depthWidth = depthFrameDescription.Width;
                                int depthHeight = depthFrameDescription.Height;
                                int irWidth = irFrameDescription.Width;
                                int irHeight = irFrameDescription.Height;

                                // verify data and write the new registered frame data to the display bitmap
                                if (((depthWidth * depthHeight) == depthFrameData.Length) &&
                                    ((irWidth * irHeight) == irFrameData.Length))
                                {
                                    depthFrame.CopyFrameDataToArray(depthFrameData);
                                    irFrame.CopyFrameDataToArray(irFrameData);
                                }

                                if (bodyFrameReference != null)
                                {
                                    bodyFrame = bodyFrameReference.AcquireFrame();

                                    if (bodyFrame != null)
                                    {
                                        if (bodies == null || bodies.Length < bodyFrame.BodyCount)
                                        {
                                            bodies = new Body[bodyFrame.BodyCount];
                                        }
                                        using (bodyFrame)
                                        {
                                            bodyFrame.GetAndRefreshBodyData(bodies);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    // ignore if the frame is no longer available
                }
                finally
                {
                    if (depthFrame != null)
                    {
                        depthFrame.Dispose();
                        depthFrame = null;
                    }

                    if (irFrame != null)
                    {
                        irFrame.Dispose();
                        irFrame = null;
                    }
                    if (bodyFrame != null)
                    {
                        bodyFrame.Dispose();
                        bodyFrame = null;
                    }
                    if (multiSourceFrame != null)
                    {
                        multiSourceFrame = null;
                    }
                }
            }
        }
        ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Main - This is where you call Aiolos
        /// </summary>
        /// <param name="args"></param>
        /// 


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       /// [MTAThread]
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PXCMSession session = PXCMSession.CreateInstance();
            if (session!=null)
            {
                Application.Run(new Form1(session));
                session.Dispose();
            }



            // Do some stuff with the console.
            Console.Clear();
            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;

            try
            {
                Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                Console.WriteLine("Initializing AiolosK4W - Make sure the Kinect SDK detects your body.");

                // Connect to the Kinect.
                ConnectKinect();
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.SetCursorPosition(cursorLeft, cursorTop + 2);

                        // Get a new frame.
                        Update();

                        // Call Aiolos
                        // The only thing you have to do is to pass 
                        // * width,
                        // * height,
                        // * the raw IR data,
                        // * the raw depth data,
                        // * the bodies and
                        // * the coordinateMapper.
                        // All this data is provided by the Kinect SDK.
                        // A structured including all the hand data is returned.
                        KinectHand[] hands = engine.DetectFingerJoints(width, height, irFrameData, depthFrameData, bodies, coordinateMapper);

                        int numHandPrinted = 0;
                        for (int i = 0; i < hands.Length; i++)
                        {
                            if (hands[i] == null)
                                continue;

                            // Print the finger data.
                            PrintHand(hands[i], i, numHandPrinted);
                            numHandPrinted++;
                        }
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }




        private static void ConnectKinect()
        {
            // for Alpha, one sensor is supported
            kinectSensor = KinectSensor.GetDefault();

            if (kinectSensor != null)
            {
                // open the sensor
                kinectSensor.Open();

                FrameDescription frameDescription = kinectSensor.DepthFrameSource.FrameDescription;

                width = frameDescription.Width;
                height = frameDescription.Height;

                // open the reader for the depth frames
                reader = kinectSensor.OpenMultiSourceFrameReader(FrameSourceTypes.Depth | FrameSourceTypes.Infrared | FrameSourceTypes.Body);

                // allocate space to put the pixels being received and converted
                depthFrameData = new ushort[frameDescription.Width * frameDescription.Height];
                irFrameData = new ushort[frameDescription.Width * frameDescription.Height];
                coordinateMapper = kinectSensor.CoordinateMapper;

                if (reader != null)
                {
                    reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;
                }
                isConnected = true;
            }
            else
            {
                // TODO: throw exception
            }
        }

        /// <summary>
        /// Print the hand to the console.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="handNumber"></param>
        /// <param name="outputPos"></param>
        public static int[,] gg = new int[1000, 30];
        static string[] ww = new string[1000];
        static int k = 0;
        private static void PrintHand(KinectHand hand, int handNumber, int outputPos)
        {

            int firstLine = cursorTop + 3 + (outputPos * 7);
            Console.SetCursorPosition(cursorLeft, firstLine);
            Console.Clear();
            Console.Write("Hand: " + handNumber);
            int[] G = new int[30];
            int indx = 0;
            for (int fingerIdx = 0; fingerIdx < 5; fingerIdx++)
            {
                try
                {
                    Color c = Color.FromArgb(180, Engine.FingerColors[fingerIdx]);

                    Array f = Enum.GetValues(typeof(Hand.FingerJointType));
                    Array fNames = Enum.GetNames(typeof(Hand.FingerJointType));
                    int idxInEnum = fingerIdx * 3;
                    Microsoft.Kinect.DepthSpacePoint[] p = new Microsoft.Kinect.DepthSpacePoint[3];
                    //Microsoft.Kinect.ColorSpacePoint [] p1 = new Microsoft.Kinect.ColorSpacePoint [4];

                    string[] jointNames = new string[3];
                    for (int j = 0; j < 3; j++)
                    {
                        Hand.FingerJointType jt = (Hand.FingerJointType)f.GetValue(idxInEnum + j);
                        //  hand.FingerJoints J= (hand.FingerJoints)f.GetValue(idxInEnum + j);
                        p[j] = hand.FingerJoints[jt];
                        jointNames[j] = (string)fNames.GetValue(idxInEnum + j);
                        Console.SetCursorPosition(cursorLeft + j * 25, firstLine + fingerIdx + 1);
                        Console.Write(jointNames[j] + ": " + p[j].X.ToString("0.0") + ";" + p[j].Y.ToString("0.0") + "\n");
                        G[indx++] = (int)p[j].X;
                        G[indx++] = (int)p[j].Y;

                    }
                }
                catch (Exception)
                {
                }
            }

            //end for


            Console.WriteLine(k.ToString());
            int i;

            for (i = 0; i < k; i++)
            {
                int flag = 1;
                for (int j = 0; j < 30; j++)
                    if (!(gg[i, j] + 10 > G[j] && gg[i, j] - 10 < G[j]))
                        flag = 0;

                if (flag == 1)
                {
                    Console.WriteLine(ww[i]);
                    Console.WriteLine("Is that right? ");
                    Console.ReadLine();
                    break;
                }
            }
            if (i == k)
            {
                for (int j = 0; j < 30; j++)
                    gg[k, j] = G[j];
                Console.WriteLine("What is that means?");
                ww[k] = Console.ReadLine();
                k++;
            }
        }

    }
}
