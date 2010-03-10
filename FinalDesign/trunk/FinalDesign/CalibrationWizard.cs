using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using WiimoteLib;

namespace FinalSolution
{
    public partial class CalibrationWizard : Form
    {
        Capture camera;
        Wiimote wiimote;
        CalibrationPoints irCalibrationPoints = new CalibrationPoints();
        CalibrationPoints camCalibrationPoints = new CalibrationPoints();
        ColorStateSet colors = new ColorStateSet();
        Warper irToScreenWarper = new Warper();
        Warper screenToCamWarper = new Warper();
        Warper irToCamWarper = new Warper();

        public CalibrationWizard(Capture c, Wiimote w, CalibrationPoints irCP, CalibrationPoints camCP, 
            ColorStateSet cs, Warper ir2S, Warper s2Cam, Warper ir2Cam)
        {
            InitializeComponent();
            camera = c;
            wiimote = w;
            irCalibrationPoints = irCP;
            camCalibrationPoints = camCP;
            colors = cs;
            irToScreenWarper = ir2S;
            screenToCamWarper = s2Cam;
            irToCamWarper = ir2Cam;
        }
    }
}
