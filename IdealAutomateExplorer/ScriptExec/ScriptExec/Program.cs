﻿
using IdealAutomate.Core;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows;
using System;



namespace First
{
    public class Program : Window
    {



        static bool boolRunningFromHome = true;
        static byte[] mybytearray;
        static ControlEntity myControlEntity = new ControlEntity();
        static IdealAutomate.Core.Methods myActions = new Methods();
        static ImageEntity myImage = new ImageEntity();
        static int intRowCtr = 0;
        static int newLeft = 0;
        static int newTop = 0;
        static int[,] myResultArrayPutAllFast = new int[100, 100];
        static int[,] resultArray = new int[100, 100];
        static List<ComboBoxPair> cbp = new List<ComboBoxPair>();
        static List<ControlEntity> myListControlEntity = new List<ControlEntity>();
        static string strButtonPressed = "";
        static System.Drawing.Bitmap bm;

        [STAThread]
        public static void Main()
        {
            var window = new Window() //make sure the window is invisible
            {
                Width = 0,
                Height = 0,
                Left = -2000,
                WindowStyle = WindowStyle.None,
                ShowInTaskbar = false,
                ShowActivated = false,
            };
            window.Show();



            myImage = new ImageEntity();

            if (boolRunningFromHome)
            {
                myImage.ImageFile = myActions.ConvertWebImageToLocalFile(@"https://raw.githubusercontent.com/harvey007y/IdealAutomatex-harvey007y/main/testfolder/Admin.png");
            }
            else
            {
                myImage.ImageFile = myActions.ConvertWebImageToLocalFile(@"");
            }
            myImage.Sleep = 1000;
            myImage.Attempts = 1;
            myImage.RelativeX = 5;
            myImage.RelativeY = 5;

            myResultArrayPutAllFast = myActions.PutAllFastByStoppingOnPerfectMatch(myImage);
            if (myResultArrayPutAllFast.Length == 0)
            {
                myActions.MessageBoxShow("I could not find image of " + myImage.ImageFile);
            }
            // We found the image

            myActions.Sleep(1000);
            myActions.LeftClick(myResultArrayPutAllFast);

        myExit:
            Console.WriteLine("Script Ended");
        }
        private static BitmapSource BitmapSourceFromImage(System.Drawing.Image img)
        {
            MemoryStream memStream = new MemoryStream();

            // save the image to memStream as a png
            img.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);

            // gets a decoder from this stream
            System.Windows.Media.Imaging.PngBitmapDecoder decoder = new System.Windows.Media.Imaging.PngBitmapDecoder(memStream, System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat, System.Windows.Media.Imaging.BitmapCacheOption.Default);

            return decoder.Frames[0];
        }
        private static System.Drawing.Bitmap BytesToBitmap(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                System.Drawing.Bitmap img = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(ms);
                return img;
            }
        }
    }
}

