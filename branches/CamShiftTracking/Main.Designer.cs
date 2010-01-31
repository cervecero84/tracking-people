namespace IdeaTester
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.ofdSourceVideo = new System.Windows.Forms.OpenFileDialog();
            this.lblPlayingFrom = new System.Windows.Forms.Label();
            this.lblVideoSource = new System.Windows.Forms.Label();
            this.btnCamera = new System.Windows.Forms.Button();
            this.ibxSource = new Emgu.CV.UI.ImageBox();
            this.ibxOutput = new Emgu.CV.UI.ImageBox();
            this.cbxVideo = new System.Windows.Forms.CheckBox();
            this.txtFrameLimit = new System.Windows.Forms.TextBox();
            this.btnSetFrameLimit = new System.Windows.Forms.Button();
            this.txtParameter1 = new System.Windows.Forms.TextBox();
            this.txtParameter2 = new System.Windows.Forms.TextBox();
            this.txtParameter3 = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbxFilterType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRedThreshold = new System.Windows.Forms.Label();
            this.lblRedThresholdLabel = new System.Windows.Forms.Label();
            this.tkbRedThreshold = new System.Windows.Forms.TrackBar();
            this.lblRedDilation = new System.Windows.Forms.Label();
            this.lblRedErosion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tkbRedDilation = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.tkbRedErosion = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblGreenThreshold = new System.Windows.Forms.Label();
            this.lblGreenThresholdLabel = new System.Windows.Forms.Label();
            this.tkbGreenThreshold = new System.Windows.Forms.TrackBar();
            this.lblGreenDilation = new System.Windows.Forms.Label();
            this.lblGreenErosion = new System.Windows.Forms.Label();
            this.tkbGreenDilation = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tkbGreenErosion = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblOrangeThreshold = new System.Windows.Forms.Label();
            this.lblOrangeThresholdLabel = new System.Windows.Forms.Label();
            this.tkbOrangeThreshold = new System.Windows.Forms.TrackBar();
            this.lblOrangeDilation = new System.Windows.Forms.Label();
            this.lblOrangeErosion = new System.Windows.Forms.Label();
            this.tkbOrangeDilation = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.tkbOrangeErosion = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblBlueThreshold = new System.Windows.Forms.Label();
            this.lblBlueThresholdLabel = new System.Windows.Forms.Label();
            this.tkbBlueThreshold = new System.Windows.Forms.TrackBar();
            this.lblBlueDilation = new System.Windows.Forms.Label();
            this.lblBlueErosion = new System.Windows.Forms.Label();
            this.tkbBlueDilation = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.tkbBlueErosion = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.ckbErosion = new System.Windows.Forms.CheckBox();
            this.ckbDilate = new System.Windows.Forms.CheckBox();
            this.ckbThreshold = new System.Windows.Forms.CheckBox();
            this.lblFPS = new System.Windows.Forms.Label();
            this.ckbSwitchCamera = new System.Windows.Forms.CheckBox();
            this.btnLearnBandColors = new System.Windows.Forms.Button();
            this.ckbFlipHorizontal = new System.Windows.Forms.CheckBox();
            this.cbxShowRed = new System.Windows.Forms.CheckBox();
            this.cbxShowGreen = new System.Windows.Forms.CheckBox();
            this.cbxShowOrange = new System.Windows.Forms.CheckBox();
            this.cbxShowBlue = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibxSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibxOutput)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedDilation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedErosion)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenDilation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenErosion)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeDilation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeErosion)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueDilation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueErosion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(403, 395);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(156, 32);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Capture + Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.Location = new System.Drawing.Point(782, 318);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(75, 32);
            this.btnVideo.TabIndex = 4;
            this.btnVideo.Text = "Video (...)";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // ofdSourceVideo
            // 
            this.ofdSourceVideo.FileName = "openFileDialog1";
            // 
            // lblPlayingFrom
            // 
            this.lblPlayingFrom.AutoSize = true;
            this.lblPlayingFrom.Location = new System.Drawing.Point(454, 328);
            this.lblPlayingFrom.Name = "lblPlayingFrom";
            this.lblPlayingFrom.Size = new System.Drawing.Size(70, 13);
            this.lblPlayingFrom.TabIndex = 5;
            this.lblPlayingFrom.Text = "Playing from: ";
            // 
            // lblVideoSource
            // 
            this.lblVideoSource.AutoSize = true;
            this.lblVideoSource.Location = new System.Drawing.Point(530, 328);
            this.lblVideoSource.Name = "lblVideoSource";
            this.lblVideoSource.Size = new System.Drawing.Size(43, 13);
            this.lblVideoSource.TabIndex = 6;
            this.lblVideoSource.Text = "Camera";
            // 
            // btnCamera
            // 
            this.btnCamera.Location = new System.Drawing.Point(701, 318);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(75, 32);
            this.btnCamera.TabIndex = 7;
            this.btnCamera.Text = "Camera";
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // ibxSource
            // 
            this.ibxSource.BackColor = System.Drawing.SystemColors.ControlText;
            this.ibxSource.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ibxSource.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.ibxSource.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.ibxSource.Location = new System.Drawing.Point(21, 12);
            this.ibxSource.Name = "ibxSource";
            this.ibxSource.Size = new System.Drawing.Size(400, 300);
            this.ibxSource.TabIndex = 8;
            this.ibxSource.TabStop = false;
            this.ibxSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ibxSource_MouseMove);
            this.ibxSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ibxSource_MouseDown);
            this.ibxSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ibxSource_MouseUp);
            // 
            // ibxOutput
            // 
            this.ibxOutput.BackColor = System.Drawing.SystemColors.ControlText;
            this.ibxOutput.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ibxOutput.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.ibxOutput.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.ibxOutput.Location = new System.Drawing.Point(457, 12);
            this.ibxOutput.Name = "ibxOutput";
            this.ibxOutput.Size = new System.Drawing.Size(400, 300);
            this.ibxOutput.TabIndex = 9;
            this.ibxOutput.TabStop = false;
            // 
            // cbxVideo
            // 
            this.cbxVideo.AutoSize = true;
            this.cbxVideo.Location = new System.Drawing.Point(21, 327);
            this.cbxVideo.Name = "cbxVideo";
            this.cbxVideo.Size = new System.Drawing.Size(119, 17);
            this.cbxVideo.TabIndex = 10;
            this.cbxVideo.Text = "Continuous Capture";
            this.cbxVideo.UseVisualStyleBackColor = true;
            this.cbxVideo.CheckedChanged += new System.EventHandler(this.cbxVideo_CheckedChanged);
            // 
            // txtFrameLimit
            // 
            this.txtFrameLimit.Location = new System.Drawing.Point(146, 325);
            this.txtFrameLimit.Name = "txtFrameLimit";
            this.txtFrameLimit.Size = new System.Drawing.Size(32, 20);
            this.txtFrameLimit.TabIndex = 11;
            // 
            // btnSetFrameLimit
            // 
            this.btnSetFrameLimit.Location = new System.Drawing.Point(184, 318);
            this.btnSetFrameLimit.Name = "btnSetFrameLimit";
            this.btnSetFrameLimit.Size = new System.Drawing.Size(75, 32);
            this.btnSetFrameLimit.TabIndex = 12;
            this.btnSetFrameLimit.Text = "Set F. Limit";
            this.btnSetFrameLimit.UseVisualStyleBackColor = true;
            this.btnSetFrameLimit.Click += new System.EventHandler(this.btnSetFrameLimit_Click);
            // 
            // txtParameter1
            // 
            this.txtParameter1.Location = new System.Drawing.Point(250, 402);
            this.txtParameter1.Name = "txtParameter1";
            this.txtParameter1.Size = new System.Drawing.Size(45, 20);
            this.txtParameter1.TabIndex = 13;
            // 
            // txtParameter2
            // 
            this.txtParameter2.Location = new System.Drawing.Point(301, 402);
            this.txtParameter2.Name = "txtParameter2";
            this.txtParameter2.Size = new System.Drawing.Size(45, 20);
            this.txtParameter2.TabIndex = 14;
            // 
            // txtParameter3
            // 
            this.txtParameter3.Location = new System.Drawing.Point(352, 402);
            this.txtParameter3.Name = "txtParameter3";
            this.txtParameter3.Size = new System.Drawing.Size(45, 20);
            this.txtParameter3.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(573, 361);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(126, 13);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Status messages go here";
            // 
            // cbxFilterType
            // 
            this.cbxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilterType.Items.AddRange(new object[] {
            "None",
            "Blur",
            "Gaussian",
            "Median",
            "Bilateral"});
            this.cbxFilterType.Location = new System.Drawing.Point(265, 323);
            this.cbxFilterType.Name = "cbxFilterType";
            this.cbxFilterType.Size = new System.Drawing.Size(74, 21);
            this.cbxFilterType.TabIndex = 20;
            this.cbxFilterType.SelectedIndexChanged += new System.EventHandler(this.cbxFilterType_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRedThreshold);
            this.groupBox1.Controls.Add(this.lblRedThresholdLabel);
            this.groupBox1.Controls.Add(this.tkbRedThreshold);
            this.groupBox1.Controls.Add(this.lblRedDilation);
            this.groupBox1.Controls.Add(this.lblRedErosion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tkbRedDilation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tkbRedErosion);
            this.groupBox1.Location = new System.Drawing.Point(20, 431);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 148);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Red";
            // 
            // lblRedThreshold
            // 
            this.lblRedThreshold.AutoSize = true;
            this.lblRedThreshold.Location = new System.Drawing.Point(170, 100);
            this.lblRedThreshold.Name = "lblRedThreshold";
            this.lblRedThreshold.Size = new System.Drawing.Size(10, 13);
            this.lblRedThreshold.TabIndex = 8;
            this.lblRedThreshold.Text = "I";
            // 
            // lblRedThresholdLabel
            // 
            this.lblRedThresholdLabel.AutoSize = true;
            this.lblRedThresholdLabel.Location = new System.Drawing.Point(10, 100);
            this.lblRedThresholdLabel.Name = "lblRedThresholdLabel";
            this.lblRedThresholdLabel.Size = new System.Drawing.Size(54, 13);
            this.lblRedThresholdLabel.TabIndex = 7;
            this.lblRedThresholdLabel.Text = "Threshold";
            // 
            // tkbRedThreshold
            // 
            this.tkbRedThreshold.Location = new System.Drawing.Point(60, 91);
            this.tkbRedThreshold.Maximum = 255;
            this.tkbRedThreshold.Minimum = 200;
            this.tkbRedThreshold.Name = "tkbRedThreshold";
            this.tkbRedThreshold.Size = new System.Drawing.Size(104, 45);
            this.tkbRedThreshold.TabIndex = 6;
            this.tkbRedThreshold.Value = 200;
            this.tkbRedThreshold.Scroll += new System.EventHandler(this.tkbRedThreshold_Scroll);
            // 
            // lblRedDilation
            // 
            this.lblRedDilation.AutoSize = true;
            this.lblRedDilation.Location = new System.Drawing.Point(170, 64);
            this.lblRedDilation.Name = "lblRedDilation";
            this.lblRedDilation.Size = new System.Drawing.Size(10, 13);
            this.lblRedDilation.TabIndex = 5;
            this.lblRedDilation.Text = "I";
            // 
            // lblRedErosion
            // 
            this.lblRedErosion.AutoSize = true;
            this.lblRedErosion.Location = new System.Drawing.Point(170, 28);
            this.lblRedErosion.Name = "lblRedErosion";
            this.lblRedErosion.Size = new System.Drawing.Size(10, 13);
            this.lblRedErosion.TabIndex = 4;
            this.lblRedErosion.Text = "I";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Dilation";
            // 
            // tkbRedDilation
            // 
            this.tkbRedDilation.Location = new System.Drawing.Point(60, 55);
            this.tkbRedDilation.Maximum = 6;
            this.tkbRedDilation.Name = "tkbRedDilation";
            this.tkbRedDilation.Size = new System.Drawing.Size(104, 45);
            this.tkbRedDilation.TabIndex = 2;
            this.tkbRedDilation.Value = 1;
            this.tkbRedDilation.Scroll += new System.EventHandler(this.tkbRedDilation_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Eroision";
            // 
            // tkbRedErosion
            // 
            this.tkbRedErosion.LargeChange = 1;
            this.tkbRedErosion.Location = new System.Drawing.Point(60, 19);
            this.tkbRedErosion.Maximum = 6;
            this.tkbRedErosion.Name = "tkbRedErosion";
            this.tkbRedErosion.Size = new System.Drawing.Size(104, 45);
            this.tkbRedErosion.TabIndex = 0;
            this.tkbRedErosion.Value = 1;
            this.tkbRedErosion.Scroll += new System.EventHandler(this.tkbRedErosion_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblGreenThreshold);
            this.groupBox2.Controls.Add(this.lblGreenThresholdLabel);
            this.groupBox2.Controls.Add(this.tkbGreenThreshold);
            this.groupBox2.Controls.Add(this.lblGreenDilation);
            this.groupBox2.Controls.Add(this.lblGreenErosion);
            this.groupBox2.Controls.Add(this.tkbGreenDilation);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tkbGreenErosion);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(226, 431);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 148);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Green";
            // 
            // lblGreenThreshold
            // 
            this.lblGreenThreshold.AutoSize = true;
            this.lblGreenThreshold.Location = new System.Drawing.Point(170, 100);
            this.lblGreenThreshold.Name = "lblGreenThreshold";
            this.lblGreenThreshold.Size = new System.Drawing.Size(10, 13);
            this.lblGreenThreshold.TabIndex = 13;
            this.lblGreenThreshold.Text = "I";
            // 
            // lblGreenThresholdLabel
            // 
            this.lblGreenThresholdLabel.AutoSize = true;
            this.lblGreenThresholdLabel.Location = new System.Drawing.Point(10, 100);
            this.lblGreenThresholdLabel.Name = "lblGreenThresholdLabel";
            this.lblGreenThresholdLabel.Size = new System.Drawing.Size(54, 13);
            this.lblGreenThresholdLabel.TabIndex = 12;
            this.lblGreenThresholdLabel.Text = "Threshold";
            // 
            // tkbGreenThreshold
            // 
            this.tkbGreenThreshold.Location = new System.Drawing.Point(60, 91);
            this.tkbGreenThreshold.Maximum = 255;
            this.tkbGreenThreshold.Minimum = 200;
            this.tkbGreenThreshold.Name = "tkbGreenThreshold";
            this.tkbGreenThreshold.Size = new System.Drawing.Size(104, 45);
            this.tkbGreenThreshold.TabIndex = 11;
            this.tkbGreenThreshold.Value = 200;
            this.tkbGreenThreshold.Scroll += new System.EventHandler(this.tkbGreenThreshold_Scroll);
            // 
            // lblGreenDilation
            // 
            this.lblGreenDilation.AutoSize = true;
            this.lblGreenDilation.Location = new System.Drawing.Point(170, 64);
            this.lblGreenDilation.Name = "lblGreenDilation";
            this.lblGreenDilation.Size = new System.Drawing.Size(10, 13);
            this.lblGreenDilation.TabIndex = 10;
            this.lblGreenDilation.Text = "I";
            // 
            // lblGreenErosion
            // 
            this.lblGreenErosion.AutoSize = true;
            this.lblGreenErosion.Location = new System.Drawing.Point(170, 28);
            this.lblGreenErosion.Name = "lblGreenErosion";
            this.lblGreenErosion.Size = new System.Drawing.Size(10, 13);
            this.lblGreenErosion.TabIndex = 9;
            this.lblGreenErosion.Text = "I";
            // 
            // tkbGreenDilation
            // 
            this.tkbGreenDilation.Location = new System.Drawing.Point(60, 55);
            this.tkbGreenDilation.Maximum = 6;
            this.tkbGreenDilation.Name = "tkbGreenDilation";
            this.tkbGreenDilation.Size = new System.Drawing.Size(104, 45);
            this.tkbGreenDilation.TabIndex = 8;
            this.tkbGreenDilation.Value = 1;
            this.tkbGreenDilation.Scroll += new System.EventHandler(this.tkbGreenDilation_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Dilation";
            // 
            // tkbGreenErosion
            // 
            this.tkbGreenErosion.Location = new System.Drawing.Point(60, 19);
            this.tkbGreenErosion.Maximum = 6;
            this.tkbGreenErosion.Name = "tkbGreenErosion";
            this.tkbGreenErosion.Size = new System.Drawing.Size(104, 45);
            this.tkbGreenErosion.TabIndex = 4;
            this.tkbGreenErosion.Value = 1;
            this.tkbGreenErosion.Scroll += new System.EventHandler(this.tkbGreenErosion_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Eroision";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblOrangeThreshold);
            this.groupBox3.Controls.Add(this.lblOrangeThresholdLabel);
            this.groupBox3.Controls.Add(this.tkbOrangeThreshold);
            this.groupBox3.Controls.Add(this.lblOrangeDilation);
            this.groupBox3.Controls.Add(this.lblOrangeErosion);
            this.groupBox3.Controls.Add(this.tkbOrangeDilation);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tkbOrangeErosion);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(432, 431);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 148);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Orange";
            // 
            // lblOrangeThreshold
            // 
            this.lblOrangeThreshold.AutoSize = true;
            this.lblOrangeThreshold.Location = new System.Drawing.Point(176, 100);
            this.lblOrangeThreshold.Name = "lblOrangeThreshold";
            this.lblOrangeThreshold.Size = new System.Drawing.Size(10, 13);
            this.lblOrangeThreshold.TabIndex = 15;
            this.lblOrangeThreshold.Text = "I";
            // 
            // lblOrangeThresholdLabel
            // 
            this.lblOrangeThresholdLabel.AutoSize = true;
            this.lblOrangeThresholdLabel.Location = new System.Drawing.Point(16, 100);
            this.lblOrangeThresholdLabel.Name = "lblOrangeThresholdLabel";
            this.lblOrangeThresholdLabel.Size = new System.Drawing.Size(54, 13);
            this.lblOrangeThresholdLabel.TabIndex = 14;
            this.lblOrangeThresholdLabel.Text = "Threshold";
            // 
            // tkbOrangeThreshold
            // 
            this.tkbOrangeThreshold.Location = new System.Drawing.Point(66, 91);
            this.tkbOrangeThreshold.Maximum = 255;
            this.tkbOrangeThreshold.Minimum = 200;
            this.tkbOrangeThreshold.Name = "tkbOrangeThreshold";
            this.tkbOrangeThreshold.Size = new System.Drawing.Size(104, 45);
            this.tkbOrangeThreshold.TabIndex = 13;
            this.tkbOrangeThreshold.Value = 200;
            this.tkbOrangeThreshold.Scroll += new System.EventHandler(this.tkbOrangeThreshold_Scroll);
            // 
            // lblOrangeDilation
            // 
            this.lblOrangeDilation.AutoSize = true;
            this.lblOrangeDilation.Location = new System.Drawing.Point(176, 64);
            this.lblOrangeDilation.Name = "lblOrangeDilation";
            this.lblOrangeDilation.Size = new System.Drawing.Size(10, 13);
            this.lblOrangeDilation.TabIndex = 12;
            this.lblOrangeDilation.Text = "I";
            // 
            // lblOrangeErosion
            // 
            this.lblOrangeErosion.AutoSize = true;
            this.lblOrangeErosion.Location = new System.Drawing.Point(176, 28);
            this.lblOrangeErosion.Name = "lblOrangeErosion";
            this.lblOrangeErosion.Size = new System.Drawing.Size(10, 13);
            this.lblOrangeErosion.TabIndex = 11;
            this.lblOrangeErosion.Text = "I";
            // 
            // tkbOrangeDilation
            // 
            this.tkbOrangeDilation.Location = new System.Drawing.Point(66, 55);
            this.tkbOrangeDilation.Maximum = 6;
            this.tkbOrangeDilation.Name = "tkbOrangeDilation";
            this.tkbOrangeDilation.Size = new System.Drawing.Size(104, 45);
            this.tkbOrangeDilation.TabIndex = 12;
            this.tkbOrangeDilation.Value = 1;
            this.tkbOrangeDilation.Scroll += new System.EventHandler(this.tkbOrangeDilation_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Dilation";
            // 
            // tkbOrangeErosion
            // 
            this.tkbOrangeErosion.Location = new System.Drawing.Point(66, 19);
            this.tkbOrangeErosion.Maximum = 6;
            this.tkbOrangeErosion.Name = "tkbOrangeErosion";
            this.tkbOrangeErosion.Size = new System.Drawing.Size(104, 45);
            this.tkbOrangeErosion.TabIndex = 8;
            this.tkbOrangeErosion.Value = 1;
            this.tkbOrangeErosion.Scroll += new System.EventHandler(this.tkbOrangeErosion_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Eroision";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblBlueThreshold);
            this.groupBox4.Controls.Add(this.lblBlueThresholdLabel);
            this.groupBox4.Controls.Add(this.tkbBlueThreshold);
            this.groupBox4.Controls.Add(this.lblBlueDilation);
            this.groupBox4.Controls.Add(this.lblBlueErosion);
            this.groupBox4.Controls.Add(this.tkbBlueDilation);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.tkbBlueErosion);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(638, 431);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 148);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Blue";
            // 
            // lblBlueThreshold
            // 
            this.lblBlueThreshold.AutoSize = true;
            this.lblBlueThreshold.Location = new System.Drawing.Point(179, 100);
            this.lblBlueThreshold.Name = "lblBlueThreshold";
            this.lblBlueThreshold.Size = new System.Drawing.Size(10, 13);
            this.lblBlueThreshold.TabIndex = 19;
            this.lblBlueThreshold.Text = "I";
            // 
            // lblBlueThresholdLabel
            // 
            this.lblBlueThresholdLabel.AutoSize = true;
            this.lblBlueThresholdLabel.Location = new System.Drawing.Point(19, 100);
            this.lblBlueThresholdLabel.Name = "lblBlueThresholdLabel";
            this.lblBlueThresholdLabel.Size = new System.Drawing.Size(54, 13);
            this.lblBlueThresholdLabel.TabIndex = 18;
            this.lblBlueThresholdLabel.Text = "Threshold";
            // 
            // tkbBlueThreshold
            // 
            this.tkbBlueThreshold.Location = new System.Drawing.Point(69, 91);
            this.tkbBlueThreshold.Maximum = 255;
            this.tkbBlueThreshold.Minimum = 200;
            this.tkbBlueThreshold.Name = "tkbBlueThreshold";
            this.tkbBlueThreshold.Size = new System.Drawing.Size(104, 45);
            this.tkbBlueThreshold.TabIndex = 17;
            this.tkbBlueThreshold.Value = 200;
            this.tkbBlueThreshold.Scroll += new System.EventHandler(this.tkbBlueThreshold_Scroll);
            // 
            // lblBlueDilation
            // 
            this.lblBlueDilation.AutoSize = true;
            this.lblBlueDilation.Location = new System.Drawing.Point(179, 64);
            this.lblBlueDilation.Name = "lblBlueDilation";
            this.lblBlueDilation.Size = new System.Drawing.Size(10, 13);
            this.lblBlueDilation.TabIndex = 14;
            this.lblBlueDilation.Text = "I";
            // 
            // lblBlueErosion
            // 
            this.lblBlueErosion.AutoSize = true;
            this.lblBlueErosion.Location = new System.Drawing.Point(179, 28);
            this.lblBlueErosion.Name = "lblBlueErosion";
            this.lblBlueErosion.Size = new System.Drawing.Size(10, 13);
            this.lblBlueErosion.TabIndex = 13;
            this.lblBlueErosion.Text = "I";
            // 
            // tkbBlueDilation
            // 
            this.tkbBlueDilation.Location = new System.Drawing.Point(69, 55);
            this.tkbBlueDilation.Maximum = 6;
            this.tkbBlueDilation.Name = "tkbBlueDilation";
            this.tkbBlueDilation.Size = new System.Drawing.Size(104, 45);
            this.tkbBlueDilation.TabIndex = 16;
            this.tkbBlueDilation.Value = 1;
            this.tkbBlueDilation.Scroll += new System.EventHandler(this.tkbBlueDilation_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Dilation";
            // 
            // tkbBlueErosion
            // 
            this.tkbBlueErosion.Location = new System.Drawing.Point(69, 19);
            this.tkbBlueErosion.Maximum = 6;
            this.tkbBlueErosion.Name = "tkbBlueErosion";
            this.tkbBlueErosion.Size = new System.Drawing.Size(104, 45);
            this.tkbBlueErosion.TabIndex = 12;
            this.tkbBlueErosion.Value = 1;
            this.tkbBlueErosion.Scroll += new System.EventHandler(this.tkbBlueErosion_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Eroision";
            // 
            // ckbErosion
            // 
            this.ckbErosion.AutoSize = true;
            this.ckbErosion.Location = new System.Drawing.Point(106, 404);
            this.ckbErosion.Name = "ckbErosion";
            this.ckbErosion.Size = new System.Drawing.Size(60, 17);
            this.ckbErosion.TabIndex = 23;
            this.ckbErosion.Text = "Erode?";
            this.ckbErosion.UseVisualStyleBackColor = true;
            // 
            // ckbDilate
            // 
            this.ckbDilate.AutoSize = true;
            this.ckbDilate.Location = new System.Drawing.Point(172, 404);
            this.ckbDilate.Name = "ckbDilate";
            this.ckbDilate.Size = new System.Drawing.Size(59, 17);
            this.ckbDilate.TabIndex = 24;
            this.ckbDilate.Text = "Dilate?";
            this.ckbDilate.UseVisualStyleBackColor = true;
            // 
            // ckbThreshold
            // 
            this.ckbThreshold.AutoSize = true;
            this.ckbThreshold.Location = new System.Drawing.Point(21, 402);
            this.ckbThreshold.Name = "ckbThreshold";
            this.ckbThreshold.Size = new System.Drawing.Size(79, 17);
            this.ckbThreshold.TabIndex = 25;
            this.ckbThreshold.Text = "Threshold?";
            this.ckbThreshold.UseVisualStyleBackColor = true;
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.Location = new System.Drawing.Point(359, 328);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(32, 13);
            this.lblFPS.TabIndex = 26;
            this.lblFPS.Text = "N fps";
            // 
            // ckbSwitchCamera
            // 
            this.ckbSwitchCamera.AutoSize = true;
            this.ckbSwitchCamera.Location = new System.Drawing.Point(590, 327);
            this.ckbSwitchCamera.Name = "ckbSwitchCamera";
            this.ckbSwitchCamera.Size = new System.Drawing.Size(71, 17);
            this.ckbSwitchCamera.TabIndex = 27;
            this.ckbSwitchCamera.Text = "Camera 1";
            this.ckbSwitchCamera.UseVisualStyleBackColor = true;
            this.ckbSwitchCamera.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnLearnBandColors
            // 
            this.btnLearnBandColors.Location = new System.Drawing.Point(21, 350);
            this.btnLearnBandColors.Name = "btnLearnBandColors";
            this.btnLearnBandColors.Size = new System.Drawing.Size(119, 35);
            this.btnLearnBandColors.TabIndex = 28;
            this.btnLearnBandColors.Text = "Learn Red";
            this.btnLearnBandColors.UseVisualStyleBackColor = true;
            this.btnLearnBandColors.Click += new System.EventHandler(this.btnPickBandRegion_Click);
            // 
            // ckbFlipHorizontal
            // 
            this.ckbFlipHorizontal.AutoSize = true;
            this.ckbFlipHorizontal.Location = new System.Drawing.Point(146, 360);
            this.ckbFlipHorizontal.Name = "ckbFlipHorizontal";
            this.ckbFlipHorizontal.Size = new System.Drawing.Size(92, 17);
            this.ckbFlipHorizontal.TabIndex = 29;
            this.ckbFlipHorizontal.Text = "Flip Horizontal";
            this.ckbFlipHorizontal.UseVisualStyleBackColor = true;
            this.ckbFlipHorizontal.CheckedChanged += new System.EventHandler(this.ckbFlipHorizontal_CheckedChanged);
            // 
            // cbxShowRed
            // 
            this.cbxShowRed.AutoSize = true;
            this.cbxShowRed.Location = new System.Drawing.Point(263, 360);
            this.cbxShowRed.Name = "cbxShowRed";
            this.cbxShowRed.Size = new System.Drawing.Size(46, 17);
            this.cbxShowRed.TabIndex = 30;
            this.cbxShowRed.Text = "Red";
            this.cbxShowRed.UseVisualStyleBackColor = true;
            // 
            // cbxShowGreen
            // 
            this.cbxShowGreen.AutoSize = true;
            this.cbxShowGreen.Location = new System.Drawing.Point(315, 360);
            this.cbxShowGreen.Name = "cbxShowGreen";
            this.cbxShowGreen.Size = new System.Drawing.Size(55, 17);
            this.cbxShowGreen.TabIndex = 31;
            this.cbxShowGreen.Text = "Green";
            this.cbxShowGreen.UseVisualStyleBackColor = true;
            // 
            // cbxShowOrange
            // 
            this.cbxShowOrange.AutoSize = true;
            this.cbxShowOrange.Location = new System.Drawing.Point(376, 360);
            this.cbxShowOrange.Name = "cbxShowOrange";
            this.cbxShowOrange.Size = new System.Drawing.Size(61, 17);
            this.cbxShowOrange.TabIndex = 32;
            this.cbxShowOrange.Text = "Orange";
            this.cbxShowOrange.UseVisualStyleBackColor = true;
            // 
            // cbxShowBlue
            // 
            this.cbxShowBlue.AutoSize = true;
            this.cbxShowBlue.Location = new System.Drawing.Point(443, 360);
            this.cbxShowBlue.Name = "cbxShowBlue";
            this.cbxShowBlue.Size = new System.Drawing.Size(47, 17);
            this.cbxShowBlue.TabIndex = 33;
            this.cbxShowBlue.Text = "Blue";
            this.cbxShowBlue.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 591);
            this.Controls.Add(this.cbxShowBlue);
            this.Controls.Add(this.cbxShowOrange);
            this.Controls.Add(this.cbxShowGreen);
            this.Controls.Add(this.cbxShowRed);
            this.Controls.Add(this.ckbFlipHorizontal);
            this.Controls.Add(this.btnLearnBandColors);
            this.Controls.Add(this.ckbSwitchCamera);
            this.Controls.Add(this.lblFPS);
            this.Controls.Add(this.ckbThreshold);
            this.Controls.Add(this.ckbDilate);
            this.Controls.Add(this.ckbErosion);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbxFilterType);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtParameter3);
            this.Controls.Add(this.txtParameter2);
            this.Controls.Add(this.txtParameter1);
            this.Controls.Add(this.btnSetFrameLimit);
            this.Controls.Add(this.txtFrameLimit);
            this.Controls.Add(this.cbxVideo);
            this.Controls.Add(this.ibxOutput);
            this.Controls.Add(this.ibxSource);
            this.Controls.Add(this.btnCamera);
            this.Controls.Add(this.lblVideoSource);
            this.Controls.Add(this.lblPlayingFrom);
            this.Controls.Add(this.btnVideo);
            this.Controls.Add(this.btnProcess);
            this.Name = "Main";
            this.Text = "Idea Tester";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ibxSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibxOutput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedDilation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedErosion)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenDilation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenErosion)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeDilation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeErosion)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueDilation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueErosion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.OpenFileDialog ofdSourceVideo;
        private System.Windows.Forms.Label lblPlayingFrom;
        private System.Windows.Forms.Label lblVideoSource;
        private System.Windows.Forms.Button btnCamera;
        private Emgu.CV.UI.ImageBox ibxSource;
        private Emgu.CV.UI.ImageBox ibxOutput;
        private System.Windows.Forms.CheckBox cbxVideo;
        private System.Windows.Forms.TextBox txtFrameLimit;
        private System.Windows.Forms.Button btnSetFrameLimit;
        private System.Windows.Forms.TextBox txtParameter1;
        private System.Windows.Forms.TextBox txtParameter2;
        private System.Windows.Forms.TextBox txtParameter3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tkbRedDilation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tkbRedErosion;
        private System.Windows.Forms.TrackBar tkbGreenDilation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tkbGreenErosion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tkbOrangeDilation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tkbOrangeErosion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar tkbBlueDilation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar tkbBlueErosion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblRedDilation;
        private System.Windows.Forms.Label lblRedErosion;
        private System.Windows.Forms.Label lblGreenDilation;
        private System.Windows.Forms.Label lblGreenErosion;
        private System.Windows.Forms.Label lblOrangeDilation;
        private System.Windows.Forms.Label lblOrangeErosion;
        private System.Windows.Forms.Label lblBlueDilation;
        private System.Windows.Forms.Label lblBlueErosion;
        private System.Windows.Forms.CheckBox ckbErosion;
        private System.Windows.Forms.CheckBox ckbDilate;
        private System.Windows.Forms.CheckBox ckbThreshold;
        private System.Windows.Forms.ComboBox cbxFilterType;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.CheckBox ckbSwitchCamera;
        private System.Windows.Forms.Button btnLearnBandColors;
        private System.Windows.Forms.CheckBox ckbFlipHorizontal;
        private System.Windows.Forms.Label lblRedThreshold;
        private System.Windows.Forms.Label lblRedThresholdLabel;
        private System.Windows.Forms.TrackBar tkbRedThreshold;
        private System.Windows.Forms.Label lblGreenThreshold;
        private System.Windows.Forms.Label lblGreenThresholdLabel;
        private System.Windows.Forms.TrackBar tkbGreenThreshold;
        private System.Windows.Forms.Label lblOrangeThreshold;
        private System.Windows.Forms.Label lblOrangeThresholdLabel;
        private System.Windows.Forms.TrackBar tkbOrangeThreshold;
        private System.Windows.Forms.Label lblBlueThreshold;
        private System.Windows.Forms.Label lblBlueThresholdLabel;
        private System.Windows.Forms.TrackBar tkbBlueThreshold;
        private System.Windows.Forms.CheckBox cbxShowRed;
        private System.Windows.Forms.CheckBox cbxShowGreen;
        private System.Windows.Forms.CheckBox cbxShowOrange;
        private System.Windows.Forms.CheckBox cbxShowBlue;
    }
}

