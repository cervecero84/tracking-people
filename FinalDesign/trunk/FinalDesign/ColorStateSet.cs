using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalSolution
{
    [Serializable()]
    public class ColorStateSet
    {
        public ColorStateSet()
        {
            Red = new ColorState();
            Green = new ColorState();
            Yellow = new ColorState();
            Blue = new ColorState();
        }

        private ColorState getColor(int idx)
        {
            ColorState c;
            switch (idx)
            {
                case 0:
                    c = Red;
                    break;
                case 1:
                    c = Green;
                    break;
                case 2:
                    c = Yellow;
                    break;
                case 3:
                    c = Blue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("idx can only be between 0 and 3. Only 4 Colors exist in ColorStateSet");
            }
            return c;
        }

        public ColorState this[int i]
        {
            get { return getColor(i); }
            set { ColorState c = getColor(i); c = value; }
        }

        public ColorState Red { get; set; }
        public ColorState Green { get; set; }
        public ColorState Yellow { get; set; }
        public ColorState Blue { get; set; }
    }
}
