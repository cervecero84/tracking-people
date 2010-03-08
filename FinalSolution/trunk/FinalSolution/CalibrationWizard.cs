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
        Warper screenToCamWarper = new Warper();
        Warper irToCamWarper = new Warper();

        public CalibrationWizard(CalibrationPoints irCP, CalibrationPoints camCP, ColorStateSet cs, 
            Warper ir2S, Warper s2Cam, Warper ir2Cam)
        {
            InitializeComponent();
            irCalibrationPoints = irCP;
            camCalibrationPoints = camCP;
            colors = cs;
            irToScreenWarper = ir2S;
            screenToCamWarper = s2Cam;
            irToCamWarper = ir2Cam;
        }
    }
}
