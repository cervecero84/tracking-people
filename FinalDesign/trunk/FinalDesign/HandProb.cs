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
        private static double _mean = 28;//18.65;
        private static double _var = 1;//0.85;
        //private static double handWidth = 8.45;

        private static NormalDist handPDF = new NormalDist(_mean, _var);

        #endregion Static Variable


        public static double SkinConnectedProb(Image<Bgr, Byte> region, WiimoteLib.PointF touch, WiimoteLib.PointF ir, double pxRatio, ref double sizeP, ref double skinP)
        {
            // Probability this is a hand, by size of hand
            double sizeProb = HandSizeProb(touch, ir, (float)pxRatio);

            // Create a bounding box and look at the number of skin pixels to compute a prob of skin connection
            // between the touch point and the IR point
            Image<Bgr, Byte> handROI=region.Clone();
            CalibrationWizard sizeReference = new CalibrationWizard();
            Rectangle rectROI = Utility.Normalize(Utility.getBoundingBox(touch, ir), sizeReference.getCameraViewerSize());

            handROI.ROI = rectROI;
            Image<Bgr, Byte> hand = new Image<Bgr, byte>(rectROI.Size);
            CvInvoke.cvCopy(handROI, hand, IntPtr.Zero);

            Image<Gray, byte> skinPixels = SkinDetect(hand);
            double skinProb = getConnectionProbability(ir, touch, skinPixels);

            sizeP = sizeProb;
            skinP = skinProb;

            // Final probability = "probability of hand size" AND "probabilit of skin"
            return skinProb * sizeProb;
        }

        public static double HandSizeProb(WiimoteLib.PointF touch, WiimoteLib.PointF ir, float pxRatio)
        {
            double dist = Math.Sqrt(Math.Pow(((touch.X - ir.X) * pxRatio),2) + Math.Pow(((touch.Y - ir.Y) * pxRatio),2));
            double ProbDist = 0;
            if (dist < _mean)
            {
                ProbDist = 1;
            }
            else
            {
                ProbDist = handPDF.PDF(dist) / handPDF.PDF(_mean);
            }
            return ProbDist;
        }

        public static double getConnectionProbability(WiimoteLib.PointF ir, WiimoteLib.PointF touch, Image<Gray, Byte> skin)
        {
            double m = (touch.Y - ir.Y)/(touch.X - ir.X);
            double b = touch.Y - touch.X * m;
            double prob = 0;

            Image<Gray, Byte> result = new Image<Gray, byte>(skin.Width, skin.Height);

            int h = skin.Height;
            int w = skin.Width;
            double total = 0;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    // NOTE: Check the case where the line is horizontal (m = INF)
                    double dist = 0;
                    if (Double.IsInfinity(m))
                    {
                        dist = Math.Abs(i - touch.Y);
                    }
                    else if (m == 0)
                    {
                        dist = Math.Abs(j - touch.X);
                    }
                    else
                    {
                        dist = Math.Sqrt(Math.Pow(i - (m * j + b), 2) + Math.Pow(j - (i - b) / m, 2));
                    }
                    // Quadratically reducing weights as move away from quasi-diagonal
                    dist *= dist;
                    prob += skin.Data[i,j,0] / dist;
                    result.Data[i, j, 0] = (byte)prob;
                    total += 255 / dist;
                }
            }

            result._EqualizeHist();

            return prob / total;
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

            for (int i = skin.Height - 1; i >= 0; i--)
            {
                for (int j = skin.Width - 1; j >= 0; j--)
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
            //if (medianLevel % 2 == 0) medianLevel = medianLevel + 1;
            //skin = S.SmoothMedian(medianLevel); // median filter is used so that the image will be kept black and white

            return S;

        }

        public static double getOrientation(WiimoteLib.PointF irPoint, WiimoteLib.PointF touchPoint)
        {
            touchPoint.X = irPoint.X - touchPoint.X;
            touchPoint.Y = irPoint.Y - touchPoint.Y;

            return Math.Atan2(touchPoint.Y, touchPoint.X);
        }
    }
}
