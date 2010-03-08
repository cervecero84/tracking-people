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
    }
}
