using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace FinalSolution
{
    class Utility
    {
        public static Rectangle getROI(PointF one, PointF two)
        {
            int x = (int)Math.Min(one.X, two.X);
            int y = (int)Math.Min(one.Y, two.Y);
            int width = (int)Math.Max(one.X, two.X) - x;
            int height = (int)Math.Max(one.Y, two.Y) - y;
            return new Rectangle(x, y, width, height);
        }

        public static Rectangle getROI(WiimoteLib.PointF one, WiimoteLib.PointF two)
        {
            int x = (int)Math.Min(one.X, two.X);
            int y = (int)Math.Min(one.Y, two.Y);
            int width = (int)Math.Max(one.X, two.X) - x;
            int height = (int)Math.Max(one.Y, two.Y) - y;
            return new Rectangle(x, y, width, height);
        }

        // TODO: Complete this
        public static int ComputeOrientation(WiimoteLib.PointF one, WiimoteLib.PointF two)
        {
            return 0;
        }

        public class ResolvedIRPoints
        {
            public WiimoteLib.PointF IRPoint { get; set; }
            public WiimoteLib.PointF TouchPoint { get; set; }
            public double Distance { get; set; }
            public BandColor Color { get; set; }
            public double SkinProbability { get; set; }

            public ResolvedIRPoints(WiimoteLib.PointF irP, WiimoteLib.PointF tP, double d, BandColor c, double sP)
            {
                IRPoint = irP;
                TouchPoint = tP;
                Distance = d;
                Color = c;
                SkinProbability = sP;
            }
        }
    }
}
