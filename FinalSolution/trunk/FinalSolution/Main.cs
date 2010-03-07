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
        Capture camera;
        Wiimote wiimote;

        public Main()
        {
            InitializeComponent();
            comm.TouchReceived += new Communicator.TouchReceivedHandler(comm_TouchReceived);
        }

        private void comm_TouchReceived(object sender, TouchEventArgs t)
        {
            TouchInfo currTouch = t.Touch;
        }
    }
}
