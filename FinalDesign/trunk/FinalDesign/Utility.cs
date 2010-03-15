using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WiimoteLib;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace FinalSolution
{
    class Utility
    {
        //this overloaded version will take two points, 
        //and return a rectangle of given width and the height that is the vertical difference of the two points.
        public static Rectangle getROI(WiimoteLib.PointF one, WiimoteLib.PointF two, double width)
        {
            int x = (int)(((one.X+two.X)/2)-width/2); // avg b/w the 2 x co-ords gives the middle of the 2 points, subtract 1/2 the desired width to get the left edge.
            int y = (int) Math.Min(one.Y, two.Y);
            int w = (int)width;
            int h = (int) Math.Abs(one.Y-two.Y);
            return new Rectangle(x, y, w, h);
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
