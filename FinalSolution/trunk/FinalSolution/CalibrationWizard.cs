using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalSolution
{
    public partial class CalibrationWizard : Form
    {
        CalibrationPoints irCalibrationPoints = new CalibrationPoints();
        CalibrationPoints camCalibrationPoints = new CalibrationPoints();
        ColorStateSet colors = new ColorStateSet();
        Warper irToScreenWarper = new Warper();
        Warper camToScreenWarper = new Warper();
        Warper irToCamWarper = new Warper();

        public CalibrationWizard(CalibrationPoints irCP, CalibrationPoints camCP, ColorStateSet cs, 
            Warper ir2S, Warper cam2S, Warper ir2Cam)
        {
            InitializeComponent();
            irCalibrationPoints = irCP;
            camCalibrationPoints = camCP;
            colors = cs;
            irToScreenWarper = ir2S;
            camToScreenWarper = cam2S;
            irToCamWarper = ir2Cam;
        }
    }
}
