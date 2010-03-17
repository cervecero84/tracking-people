using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WiimoteLib;
using Emgu.CV;
using Emgu.CV.Structure;
using CenterSpace.Free;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;

namespace FinalSolution
{
    class HandProb
    {
        #region Static Variables : Anthropometic data on human hans ----------------------------------------
        // data are taken from http://en.wikipedia.org/wiki/File:HandAnthropometry.JPG
        // units are cm
        private static double _mean = 18.65;
        private static double _var = 0.85;
        //private static double handWidth = 8.45;

        private static NormalDist handPDF = new NormalDist(_mean, _var);

        #endregion Static Variable


        public static double SkinConnectedProb(Image<Bgr, Byte> region, WiimoteLib.PointF touch, WiimoteLib.PointF ir, float pxRatio)
        {
            // Probability this is a hand, by size of hand
            double sizeProb = HandSizeProb(touch, ir, pxRatio);

            // Create a bounding box and look at the number of skin pixels to compute a prob of skin connection
            // between the touch point and the IR point
            Image<Bgr, Byte> handROI=region.Clone();
            CalibrationWizard sizeReference = new CalibrationWizard();
            Rectangle rectROI = Utility.Normalize(Utility.getBoundingBox(touch, ir), sizeReference.getCameraViewerSize());
            CvInvoke.cvSetImageROI(handROI, rectROI);
            Image<Bgr, Byte> hand = new Image<Bgr,byte>(rectROI.Size);
            CvInvoke.cvGetSubRect(handROI, hand, rectROI);
            Image<Gray, byte> skinPixels = SkinDetect(hand);
            double skinProb = skinPixels.GetAverage().Intensity / (skinPixels.Rows * skinPixels.Cols * 0.75); // 0.75 is a fudge factor, since hand will most like occupy a whole rectangle of ROI region

            // Final probability = "probability of hand size" AND "probabilit of skin"
            return skinProb * sizeProb;
        }

        public static double HandSizeProb(WiimoteLib.PointF touch, WiimoteLib.PointF ir, float pxRatio)
        {
            double dist = Math.Sqrt(Math.Pow(((touch.X - ir.X) * pxRatio),2) + Math.Pow(((touch.Y - ir.Y) * pxRatio),2));
            double ProbDist=handPDF.PDF(dist);
            return ProbDist;
        }

        public static Image<Gray, byte> SkinDetect(Image<Bgr, byte> Img)
        {

            Image<Gray, byte> S = new Image<Gray, byte>(Img.Width, Img.Height);
            Image<Gray, byte> skin = new Image<Gray, byte>(Img.Width, Img.Height);

            /* convert RGB color space to IRgBy color space using this formula:
            http://www.cs.hmc.edu/~fleck/naked-skin.html
            I = L(G)
            Rg = L(R) - L(G)
            By = L(B) - [L(G) +L(R)] / 2
            					
            to calculate the hue:
            hue = atan2(Rg,By) * (180 / 3.141592654f)
            Saturation = sqrt(Rg^2 + By^2)
            */

            for (int j = skin.Width - 1; j >= 0; j--)
            {
                for (int i = skin.Height - 1; i >= 0; i--)
                {

                    int R = Img.Data[i, j, 2];
                    int G = Img.Data[i, j, 1];
                    int B = Img.Data[i, j, 0];

                    double Rg = Math.Log(R) - Math.Log(G);
                    double By = Math.Log(B) - (Math.Log(G) + Math.Log(R)) / 2;

                    double hue_val = Math.Atan2(Rg, By) * (180 / Math.PI);
                    double sat_val = Math.Sqrt(Rg * Rg + By * By) * 255;


                    if (sat_val >= 20 && sat_val <= 130 && hue_val >= 110 && hue_val <= 180) //I simplified the naked people filter's two overlapping criteria
                    {
                        S[i, j] = new Gray(255);
                    }
                    else
                    {
                        S[i, j] = new Gray(0);
                    }
                }
            }


            //skin = S.Erode(1);
            skin = S.SmoothMedian(15); // median filter is used so that the image will be kept black and white

            return skin;

        }

        public static double getOrientation(WiimoteLib.PointF irPoint, WiimoteLib.PointF touchPoint)
        {
            touchPoint.X = irPoint.X - touchPoint.X;
            touchPoint.Y = irPoint.Y - touchPoint.Y;

            return Math.Atan2(touchPoint.Y, touchPoint.X);
        }
    }
}
