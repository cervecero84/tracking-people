using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalSolution
{
    public class ColorStateSet
    {
        public ColorStateSet()
        {
            Red = new ColorState();
            Green = new ColorState();
            Yellow = new ColorState();
            Blue = new ColorState();
        }

        public ColorState Red { get; set; }
        public ColorState Green { get; set; }
        public ColorState Yellow { get; set; }
        public ColorState Blue { get; set; }
    }
}
