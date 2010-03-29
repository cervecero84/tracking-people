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


        public static double SkinConnectedProb(Image<Bgr, Byte> region, WiimoteLib.PointF touch, WiimoteLib.PointF ir, double pxRatio, Size cameraViewerSize, ref double sizeP, ref double skinP)
        {
            // Probability this is a hand, by size of hand
            double sizeProb = HandSizeProb(touch, ir, (float)pxRatio);

            // Create a bounding box and look at the number of skin pixels to compute a prob of skin connection
            // between the touch point and the IR point
            Image<Bgr, Byte> handROI=region.Clone();
            Rectangle rectROI = Utility.Normalize(Utility.getBoundingBox(touch, ir), cameraViewerSize);

            handROI.ROI = rectROI;
            Image<Bgr, Byte> hand = new Image<Bgr, byte>(rectROI.Size);
            CvInvoke.cvCopy(handROI, hand, IntPtr.Zero);

            // Normalized to the bounding box
            ir.X = ir.X - rectROI.X;
            ir.Y = ir.Y - rectROI.Y;
            touch.X = touch.X - rectROI.X;
            touch.Y = touch.Y - rectROI.Y;

            //ImageViewer skinView = new ImageViewer();
            //skinView.Text = "Skin Image Original";
            //skinView.Image = hand;
            //skinView.ShowDialog();

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
            //ImageViewer skinView = new ImageViewer();
            //skinView.Text = "Skin Image";
            //skinView.Image = skin;
            //skinView.ShowDialog();

            float tY = touch.Y, irY = ir.Y, tX = touch.X, irX = ir.X;
            double m = (tY - irY)/(tX - irX);
            double b = tY - tX * m;
            
            double A = m;
            double B = -1;
            double C = b;

            double prob = 0;

            Image<Gray, Byte> result = new Image<Gray, byte>(skin.Width, skin.Height);

            int h = skin.Height;
            int w = skin.Width;
            double total = 0;

            byte[, ,] sdata = skin.Data;
            byte[, ,] rdata = result.Data;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    // NOTE: Check the case where the line is horizontal (m = INF)
                    double dist = 0;
                    if (Double.IsInfinity(m))
                    {
                        dist = Math.Abs(i - tY);
                    }
                    else if (m == 0)
                    {
                        dist = Math.Abs(j - tX);
                    }
                    else
                    {
                        // Perpendicular distance from a point to a line
                        // Source: http://www.intmath.com/Plane-analytic-geometry/Perpendicular-distance-point-line.php
                        dist = Math.Abs(A * j + B * i + C) / Math.Sqrt(A * A + B * B);
                    }

                    // Minimum distance has to be 1
                    dist += 1;
                    dist *= dist;

                    // Quadratically reducing weights as move away from quasi-diagonal
                    //dist *= dist;
                    prob += sdata[i,j,0] / dist;
                    rdata[i, j, 0] = (byte)(sdata[i, j, 0] / dist);
                    total += 255 / dist;
                }
            }

            //result._EqualizeHist();
            //ImageViewer view = new ImageViewer();
            //view.Text = "Weighted Probability Image";
            //Image<Bgr, Byte> resultBgr = result.Convert<Bgr, Byte>();
            //resultBgr.Draw(new LineSegment2D(new System.Drawing.Point((int)ir.X, (int)ir.Y), new System.Drawing.Point((int)touch.X, (int)touch.Y)), new Bgr(Color.Red), 3);
            //resultBgr.Draw(new LineSegment2D(new System.Drawing.Point(0, (int)b), new System.Drawing.Point((int)skin.Width-1, (int)(m*(skin.Width-1)+b))), new Bgr(Color.Blue), 1);
            //view.Image = resultBgr;
            //view.ShowDialog();

            return prob / total;
        }

        public static Image<Gray, byte> SkinDetect(Image<Bgr, byte> Img)
        {

            Image<Gray, byte> S = new Image<Gray, byte>(Img.Width, Img.Height);

            #region hide comments
            /* convert RGB color space to IRgBy color space using this formula:
            http://www.cs.hmc.edu/~fleck/naked-skin.html
            I = L(G)
            Rg = L(R) - L(G)
            By = L(B) - [L(G) +L(R)] / 2
            					
            to calculate the hue:
            hue = atan2(Rg,By) * (180 / 3.141592654f)
            Saturation = sqrt(Rg^2 + By^2)
            */
            #endregion

            byte[, ,] iData = Img.Data;
            byte[, ,] sData = S.Data;

            for (int i = S.Height - 1; i >= 0; i--)
            {
                for (int j = S.Width - 1; j >= 0; j--)
                {

                    int R = iData[i, j, 2];
                    int G = iData[i, j, 1];
                    int B = iData[i, j, 0];

                    double Rg = Math.Log(R) - Math.Log(G);
                    double By = Math.Log(B) - (Math.Log(G) + Math.Log(R)) / 2;

                    double hue_val = Math.Atan2(Rg, By) * (180 / Math.PI);
                    double sat_val = Math.Sqrt(Rg * Rg + By * By) * 255;


                    if (sat_val >= 20 && sat_val <= 130 && hue_val >= 110 && hue_val <= 180) //I simplified the naked people filter's two overlapping criteria
                    {
                        sData[i, j, 0] = 255;
                    }
                    else
                    {
                        sData[i, j,0] = 0;
                    }
                }
            }
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
