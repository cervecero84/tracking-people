using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TableTopCommunicator;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using WiimoteLib;

namespace FinalSolution
{
    public partial class Main : Form
    {
        Communicator comm = new Communicator();
        Capture camera = new Capture();
        Wiimote wiimote = new Wiimote();

        // Calibration Information
        CalibrationPoints irCalibrationPoints = new CalibrationPoints();
        CalibrationPoints camCalibrationPoints = new CalibrationPoints();
        ColorStateSet colors = new ColorStateSet();
        Warper irToScreenWarper = new Warper();
        Warper camToScreenWarper = new Warper();
        Warper irToCamWarper = new Warper();

        public Main()
        {
            InitializeComponent();
            comm.TouchReceived += new Communicator.TouchReceivedHandler(comm_TouchReceived);
            try
            {
                wiimote.Connect();
                wiimote.SetReportType(InputReport.IRAccel, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                this.Close();
            }
        }

        private void comm_TouchReceived(object sender, TouchEventArgs t)
        {
            TouchInfo currTouch = t.Touch;
            Image<Bgr, Byte> cameraImage = camera.QueryFrame();
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            CalibrationWizard wizard = new CalibrationWizard(irCalibrationPoints, camCalibrationPoints, colors,
                irToScreenWarper, camToScreenWarper, irToCamWarper);
            wizard.Show();
        }
    }
}
