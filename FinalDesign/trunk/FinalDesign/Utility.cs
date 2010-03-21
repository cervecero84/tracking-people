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
        public static Rectangle getBoundingBox(WiimoteLib.PointF touch, WiimoteLib.PointF ir)
        {
            Rectangle r = new Rectangle();

            WiimoteLib.PointF topPoint = touch.Y > ir.Y ? touch : ir;
            WiimoteLib.PointF bottomPoint = touch.Y > ir.Y ? ir : touch;

            //double angle = HandProb.getOrientation(ir, touch);

            double deltaX = topPoint.X - bottomPoint.X;
            double deltaY = topPoint.Y - bottomPoint.Y;

            if (deltaY == 0)
            {
                r.X = (int) (topPoint.X + deltaX / 2);
                r.Y = (int) Math.Min(topPoint.Y, bottomPoint.Y);
                r.Width = (int)deltaX;
                r.Height = (int)(2 * deltaX);
                return r;
            }

            double dist = Math.Pow(deltaX * deltaX + deltaY * deltaY, 0.5);
            double m =  - deltaX / deltaY;

            double dx = Math.Pow(dist * dist / (4 * (m * m + 1)), 0.5);
            double dy = m*dx;

            WiimoteLib.PointF midPoint = new WiimoteLib.PointF();
            WiimoteLib.PointF leftPoint = new WiimoteLib.PointF();
            WiimoteLib.PointF rightPoint = new WiimoteLib.PointF();

            midPoint.X = (float)(bottomPoint.X + deltaX / 2);
            midPoint.Y = (float)(bottomPoint.Y + deltaY / 2);
            
            leftPoint.X = (float)(midPoint.X + dx);
            leftPoint.Y = (float)(midPoint.Y + dy);

            rightPoint.X = (float)(midPoint.X - dx);
            rightPoint.Y = (float)(midPoint.Y - dy);

            r.X = (int)Math.Min(Math.Min(topPoint.X, bottomPoint.X), Math.Min(leftPoint.X, rightPoint.X));
            r.Y = (int)Math.Min(Math.Min(topPoint.Y, bottomPoint.Y), Math.Min(leftPoint.Y, rightPoint.Y));

            r.Width = (int)Math.Max(Math.Max(topPoint.X, bottomPoint.X), Math.Max(leftPoint.X, rightPoint.X)) - r.X;
            r.Height = (int)Math.Max(Math.Max(topPoint.Y, bottomPoint.Y), Math.Max(leftPoint.Y, rightPoint.Y)) - r.Y;
            
            return r;
        }

        public static Rectangle getBoundingBoxForColor(WiimoteLib.PointF ir)
        {
            Rectangle r = new Rectangle();
            r.X = (int)(ir.X - 10);
            r.Y = (int)(ir.Y - 10);
            r.Width = r.Height = 20;
            return r;
        }

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

        public class ResolvedIRPoints
        {
            public WiimoteLib.PointF IRPoint { get; set; }
            public WiimoteLib.PointF TouchPoint { get; set; }
            public BandColor Color { get; set; }
            public double SkinProbability { get; set; }

            public ResolvedIRPoints(WiimoteLib.PointF irP, WiimoteLib.PointF tP, BandColor c, double sP)
            {
                IRPoint = irP;
                TouchPoint = tP;
                Color = c;
                SkinProbability = sP;
            }
        }

        public static WiimoteLib.PointF Normalize(WiimoteLib.PointF p, Size s)
        {
            if (p.X < 0) p.X = 0;
            if (p.Y < 0) p.Y = 0;
            if (p.X >= s.Width) p.X = s.Width - 1;
            if (p.Y >= s.Height) p.Y = s.Height - 1;
            return p;
        }

        public static Rectangle Normalize(Rectangle r, Size s)
        {
            if (r.X < 0) r.X = 0;
            if (r.Y < 0) r.Y = 0;
            if (r.X + r.Width > s.Width) r.Width = s.Width - 1;
            if (r.Y + r.Height > s.Height) r.Height = s.Height - 1;
            return r;
        }
    }
}
