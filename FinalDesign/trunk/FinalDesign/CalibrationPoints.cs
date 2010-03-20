using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinalSolution
{
    [Serializable()]
    public class CalibrationPoints
    {
        //PointF _tl;
        //PointF _tr;
        //PointF _bl;
        //PointF _br;

        private PointF getPoint(int idx)
        {
            PointF c;
            switch (idx)
            {
                case 0:
                    c = TL;
                    break;
                case 1:
                    c = TR;
                    break;
                case 2:
                    c = BL;
                    break;
                case 3:
                    c = BR;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("idx can only be between 0 and 3. Only 4 Points exist in CalibrationPoints");
            }
            return c;
        }

        public PointF this[int i]
        {
            get { return getPoint(i); }
            set { PointF p = getPoint(i); p = value; }
        }

        public PointF TL { get; set; }
        public PointF TR { get; set; }
        public PointF BL { get; set; }
        public PointF BR { get; set; }
    }
}
