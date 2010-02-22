using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using WiimoteLib;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace IdeaTester
{
    public partial class Main : Form
    {
        Wiimote wm = new Wiimote();
        private Bitmap _irViewAreaBitmap = new Bitmap(400, 300, PixelFormat.Format24bppRgb);
        private Graphics _irViewAreaGraphics;
        private Stopwatch _videoProcessingTimer;

        private Image<Bgr, Byte> _imgOutput = new Image<Bgr,byte>(400, 300);
        private Image<Bgr, Byte> _imgSource = new Image<Bgr, byte>(400, 300);

        //private Bitmap _cameraViewAreaBitmap = new Bitmap(400, 300, PixelFormat.Format24bppRgb);
        private Graphics _cameraViewAreaGraphics;

        Warper _irWarper = new Warper();
        Warper _cameraWarper = new Warper();
        Warper _cameraReverseWarper = new Warper();

        Capture _camera;
        int _msPerFrame = (int)(1000.0 / 30);
        
        int _screenWidth = 1024;
        int _screenHeight = 768;

        // States 0 - 3: indicate point number (TL, TR, BL, BR)
        // Anything else means program is in non-calibration mode
        int _irCalibrationState = 4;
        int _camCalibrationState = 4;
        WiimoteLib.PointF[] _webCameraSrcPoints = new WiimoteLib.PointF[4];
        WiimoteLib.PointF[] _irCameraSrcPoints = new WiimoteLib.PointF[4];
        bool _calibrated = false;
        Mutex mut = new Mutex();

        public Main()
        {
            InitializeComponent();

            _irViewAreaGraphics = Graphics.FromImage(_irViewAreaBitmap);
            _videoProcessingTimer = new Stopwatch();
            //_cameraViewAreaGraphics = Graphics.FromImage(_cameraViewAreaBitmap);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Activate the camera
            btnCamera_Click(sender, e);
            
            #region Wiimote Connection and setup
            try
            {
                //connect to wii remote
                wm.Connect();
                wm.WiimoteChanged += wm_WiimoteChanged; 

                //set what features you want to enable for the remote, look at Wiimote.InputReport for options
                wm.SetReportType(InputReport.IRAccel, true);

                //set wiiremote LEDs with this enumerated ID
                wm.SetLEDs(false, false, false, true);
            }
            catch (Exception x)
            {
                MessageBox.Show("Exception: " + x.Message);
                this.Close();
            }
            #endregion
        }

        #region Wiimote processing
        void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            //mut.WaitOne();
            
            WiimoteState ws = args.WiimoteState;

            lock (_irViewAreaGraphics) _irViewAreaGraphics.Clear(Color.Black);

            // Draw the calibration markers
            for (int i = 0; i < Math.Min(_irCalibrationState, 4); i++)
            {
                _irViewAreaGraphics.DrawEllipse(new Pen(Color.Cyan), 
                    _irCameraSrcPoints[i].X,
                    _irCameraSrcPoints[i].Y, 
                    2,
                    2
                    );
            }
            
            UpdateIR(ws.IRState.IRSensors[0], Color.Red);
            UpdateIR(ws.IRState.IRSensors[1], Color.Wheat);
            UpdateIR(ws.IRState.IRSensors[2], Color.Yellow);
            UpdateIR(ws.IRState.IRSensors[3], Color.Orange);

            _imgOutput.Bitmap = _irViewAreaBitmap;
            ibxOutput.Image = _imgOutput;
            //pictureBox1.Image = _irViewAreaBitmap;
            //mut.ReleaseMutex();
        }

        public void irDrawEllipse(Color color, int x, int y, int size)
        {
            _irViewAreaGraphics.DrawEllipse(new Pen(color), x, y, size, size);
        }

        private void UpdateIR(IRSensor irSensor, Color color)
        {
            if (irSensor.Found)
            {
                //BeginInvoke((MethodInvoker)delegate() { lblStatus.Text = "IR source found with color = " + color.ToString(); });
                lock (_irViewAreaGraphics) _irViewAreaGraphics.DrawEllipse(new Pen(color),
                    (int)(irSensor.RawPosition.X * 400 / 1024),
                    (int)(irSensor.RawPosition.Y * 300 / 768),
                    irSensor.Size + 1,
                    irSensor.Size + 1);

                WiimoteLib.PointF dst = new WiimoteLib.PointF();

                // Compute normalized coordinates
                dst = _irWarper.warp(irSensor.RawPosition.X * 400 / 1024, irSensor.RawPosition.Y * 300 / 768);
                
                showIRPointInCam(color, dst);
            }
        }
        #endregion

        #region Wiimote calibration
        private void btnWiimoteCalibrate_Click(object sender, EventArgs e)
        {
            _irCalibrationState = 0;
            lblStatus.Text = "IR Calibration: Click TL point";
        }

        private void ibxOutput_MouseClick(object sender, MouseEventArgs e)
        {
            // Select point (0,0)
            // Select point (screenWidth, 0)
            // Select point (0, screenHeight)
            // Select point (screenWidth, screenHeight)

            // Draw the calibration screen markers
            //if (_irCalibrationState >= 0 && _irCalibrationState <= 3)
            //{
            //    lock (_irViewAreaGraphics) _irViewAreaGraphics.DrawEllipse(new Pen(Color.Cyan), new Rectangle(new System.Drawing.Point(e.X, e.Y), new Size(2, 2)));
            //}

            switch (_irCalibrationState)
            {
                case 0:
                    _irCameraSrcPoints[0].X = e.X;
                    _irCameraSrcPoints[0].Y = e.Y;
                    _irCalibrationState += 1;
                    lblStatus.Text = "IR Calibration: Click TR point";
                    break;
                case 1:
                    _irCameraSrcPoints[1].X = e.X;
                    _irCameraSrcPoints[1].Y = e.Y;
                    _irCalibrationState += 1;
                    lblStatus.Text = "IR Calibration: Click BL point";
                    break;
                case 2:
                    _irCameraSrcPoints[2].X = e.X;
                    _irCameraSrcPoints[2].Y = e.Y;
                    _irCalibrationState += 1;
                    lblStatus.Text = "IR Calibration: Click BR point";
                    break;
                case 3:
                    _irCameraSrcPoints[3].X = e.X;
                    _irCameraSrcPoints[3].Y = e.Y;
                    _irCalibrationState += 1;
                    // Save a copy of the image with the calibration markers - create a new object using Clone
                    lblStatus.Text = "IR Calibration: Complete";
                    // Calibration data acquired. Compute warp
                    _irWarper.setDestination(0, 0, _screenWidth, 0, 0, _screenHeight, _screenWidth, _screenHeight);
                    _irWarper.setSource(_irCameraSrcPoints[0].X, _irCameraSrcPoints[0].Y,
                        _irCameraSrcPoints[1].X, _irCameraSrcPoints[1].Y,
                        _irCameraSrcPoints[2].X, _irCameraSrcPoints[2].Y,
                        _irCameraSrcPoints[3].X, _irCameraSrcPoints[3].Y);
                    _irWarper.computeWarp();
                    _calibrated = true;
                    lblStatus.Text = "IR Calibration: Complete - Warp computed";
                    break;
                default:
                    if (_calibrated)
                    {
                        lblStatus.Text = "IR Clicked @ " + DateTime.Now.ToShortTimeString(); 
                        // Compute normalized coordinate
                        WiimoteLib.PointF dst = _irWarper.warp(e.X, e.Y);
                        lblStatus.Text += " in (" + e.X.ToString() + ", " + e.Y.ToString() + ")";
                        lblStatus.Text += " => " + dst.ToString();

                        showIRPointInCam(Color.PeachPuff, dst);
                    }
                    break;
            }
        }
        #endregion

        public void showIRPointInCam(Color c, WiimoteLib.PointF dst)
        {
            if (_camCalibrationState > 3)
            {
                WiimoteLib.PointF camDst = _cameraReverseWarper.warp(dst.X, dst.Y);
                _cameraViewAreaGraphics.DrawEllipse(new Pen(c),
                    camDst.X,
                    camDst.Y,
                    5,
                    5);
            }
        }

        #region Video Processing
        private void btnVideo_Click(object sender, EventArgs e)
        {
            String videoSourceFileName = "";
            if (ofdSourceVideo.ShowDialog() == DialogResult.OK)
            {
                videoSourceFileName = ofdSourceVideo.FileName;
                Capture tmp = _camera;
                try
                {
                    tmp = new Capture(videoSourceFileName);
                }
                catch (NullReferenceException)
                {
                    // This exception happens when the file that was tried to be opened
                    // was not a readable video file
                    MessageBox.Show("Unreadable video file. No action done.");
                }
                _camera = tmp;
                lblVideoSource.Text = "File";
            }
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            _camera = new Capture(0);
            lblVideoSource.Text = "Camera";
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            ibxSource.Image = _camera.QueryFrame().Resize(400, 300, INTER.CV_INTER_CUBIC);
        }

        private void cbxVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxVideo.Checked)
            {
                Application.Idle += new EventHandler(processFrame);
            }
            else
            {
                Application.Idle -= new EventHandler(processFrame);
            }
        }

        private void processFrame(object sender, EventArgs e)
        {
            //DateTime curr = DateTime.Now;
            _videoProcessingTimer.Reset();
            _videoProcessingTimer.Start();
            performOperation();
            _videoProcessingTimer.Stop();
            lblFPS.Text = (1000 / (_videoProcessingTimer.ElapsedMilliseconds + 1)).ToString() + " fps";
            //Thread.Sleep( (_msPerFrame > currTime.Milliseconds) ? _msPerFrame - currTime.Milliseconds : 0);
        }

        /// <summary>
        /// This is the ONLY function you would require to modify, you could add other helper functions,
        /// but the other existing functions can stay the way they are
        /// 
        /// All the image processing goes in here
        /// </summary>
        private void performOperation()
        {
            Image<Bgr, Byte> source = _camera.QueryFrame();
            
            // Reached the last frame in the source - happens in video files
            if (source == null)
            {
                cbxVideo.Checked = false;
                return;
            }

            source = source.Resize(400, 300, INTER.CV_INTER_CUBIC);

            _cameraViewAreaGraphics = Graphics.FromImage(source.Bitmap);

            // Draw the calibration markers
            for (int i = 0; i < Math.Min(_camCalibrationState, 4); i++)
            {
                _cameraViewAreaGraphics.DrawEllipse(new Pen(Color.Cyan),
                    _webCameraSrcPoints[i].X,
                    _webCameraSrcPoints[i].Y,
                    2,
                    2
                    );
            }

            ibxSource.Image = source;
            //ibxOutput.Image = source.Convert<Gray, Byte>();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            processFrame(sender, e);
        }

        private void cbxFlipHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFlipHorizontal.Checked)
            {
                _camera.FlipHorizontal = true;
            }
            else
            {
                _camera.FlipHorizontal = false;
            }
        }
        #endregion

        private void ibxSource_MouseClick(object sender, MouseEventArgs e)
        {
            // Select point (0,0)
            // Select point (screenWidth, 0)
            // Select point (0, screenHeight)
            // Select point (screenWidth, screenHeight)

            // Draw the calibration screen markers
            if (_camCalibrationState >= 0 && _camCalibrationState <= 3)
            {
                _cameraViewAreaGraphics.DrawEllipse(new Pen(Color.Cyan), new Rectangle(new System.Drawing.Point(e.X, e.Y), new Size(2, 2)));
            }

            switch (_camCalibrationState)
            {
                case 0:
                    _webCameraSrcPoints[0].X = e.X;
                    _webCameraSrcPoints[0].Y = e.Y;
                    _camCalibrationState += 1;
                    lblStatus.Text = "WebCam Calibration: Click TR point";
                    break;
                case 1:
                    _webCameraSrcPoints[1].X = e.X;
                    _webCameraSrcPoints[1].Y = e.Y;
                    _camCalibrationState += 1;
                    lblStatus.Text = "WebCam Calibration: Click BL point";
                    break;
                case 2:
                    _webCameraSrcPoints[2].X = e.X;
                    _webCameraSrcPoints[2].Y = e.Y;
                    _camCalibrationState += 1;
                    lblStatus.Text = "WebCam Calibration: Click BR point";
                    break;
                case 3:
                    _webCameraSrcPoints[3].X = e.X;
                    _webCameraSrcPoints[3].Y = e.Y;
                    _camCalibrationState += 1;
                    lblStatus.Text = "WebCam Calibration: Complete";
                    // Calibration data acquired. Compute warp for camera
                    _cameraWarper.setDestination(0, 0, _screenWidth, 0, 0, _screenHeight, _screenWidth, _screenHeight);
                    _cameraWarper.setSource(_webCameraSrcPoints[0].X, _webCameraSrcPoints[0].Y,
                        _webCameraSrcPoints[1].X, _webCameraSrcPoints[1].Y,
                        _webCameraSrcPoints[2].X, _webCameraSrcPoints[2].Y,
                        _webCameraSrcPoints[3].X, _webCameraSrcPoints[3].Y);
                    _cameraWarper.computeWarp();
                    // Calculate the reverse warp matrix
                    _cameraReverseWarper.setDestination(_webCameraSrcPoints[0].X, _webCameraSrcPoints[0].Y,
                        _webCameraSrcPoints[1].X, _webCameraSrcPoints[1].Y,
                        _webCameraSrcPoints[2].X, _webCameraSrcPoints[2].Y,
                        _webCameraSrcPoints[3].X, _webCameraSrcPoints[3].Y);
                    _cameraReverseWarper.setSource(0, 0, _screenWidth, 0, 0, _screenHeight, _screenWidth, _screenHeight);
                    _cameraReverseWarper.computeWarp();

                    _calibrated = true;
                    lblStatus.Text = "WebCam Calibration: Complete - Warp computed";
                    break;
                default:
                    if (_calibrated)
                    {
                        lblStatus.Text = "WebCam Viewer Clicked @ " + DateTime.Now.ToLongTimeString();
                        WiimoteLib.PointF dst = _cameraWarper.warp(e.X, e.Y);
                        lblStatus.Text += " in (" + e.X.ToString() + ", " + e.Y.ToString() + ")";
                        lblStatus.Text += " => " + dst.ToString();
                    }
                    break;
            }
        }

        private void btnCameraCalibrate_Click(object sender, EventArgs e)
        {
            _camCalibrationState = 0;
            lblStatus.Text = "WebCam Calibration: Click TL point";
        }
    }
}
