namespace FinalSolution
{
    partial class CalibrationWizard
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
            this.wiiCalibOutput = new Emgu.CV.UI.ImageBox();
            this.cameraCalibOutput = new Emgu.CV.UI.ImageBox();
            this.btnLearnRed = new System.Windows.Forms.Button();
            this.btnLearnGreen = new System.Windows.Forms.Button();
            this.btnLearnOrange = new System.Windows.Forms.Button();
            this.btnLearnBlue = new System.Windows.Forms.Button();
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
            this.cbxShowBlue = new System.Windows.Forms.CheckBox();
            this.cbxShowOrange = new System.Windows.Forms.CheckBox();
            this.cbxShowGreen = new System.Windows.Forms.CheckBox();
            this.cbxShowRed = new System.Windows.Forms.CheckBox();
            this.btnSaveHistograms = new System.Windows.Forms.Button();
            this.ckbThreshold = new System.Windows.Forms.CheckBox();
            this.ckbDilate = new System.Windows.Forms.CheckBox();
            this.ckbErosion = new System.Windows.Forms.CheckBox();
            this.cbxDrawCalibrationMarkers = new System.Windows.Forms.CheckBox();
            this.cbxDrawIRPoints = new System.Windows.Forms.CheckBox();
            this.btnCameraCalibrate = new System.Windows.Forms.Button();
            this.btnWiimoteCalibrate = new System.Windows.Forms.Button();
            this.btnCalibWizard = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wiiCalibOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraCalibOutput)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueDilation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueErosion)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeDilation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeErosion)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenDilation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenErosion)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedDilation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedErosion)).BeginInit();
            this.SuspendLayout();
            // 
            // wiiCalibOutput
            // 
            this.wiiCalibOutput.BackColor = System.Drawing.SystemColors.ControlText;
            this.wiiCalibOutput.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.wiiCalibOutput.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.wiiCalibOutput.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.wiiCalibOutput.Location = new System.Drawing.Point(435, 39);
            this.wiiCalibOutput.Name = "wiiCalibOutput";
            this.wiiCalibOutput.Size = new System.Drawing.Size(400, 300);
            this.wiiCalibOutput.TabIndex = 11;
            this.wiiCalibOutput.TabStop = false;
            this.wiiCalibOutput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.wiiCalibOutput_MouseClick);
            // 
            // cameraCalibOutput
            // 
            this.cameraCalibOutput.BackColor = System.Drawing.SystemColors.ControlText;
            this.cameraCalibOutput.Cursor = System.Windows.Forms.Cursors.Cross;
            this.cameraCalibOutput.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.cameraCalibOutput.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.cameraCalibOutput.Location = new System.Drawing.Point(13, 39);
            this.cameraCalibOutput.Name = "cameraCalibOutput";
            this.cameraCalibOutput.Size = new System.Drawing.Size(400, 300);
            this.cameraCalibOutput.TabIndex = 10;
            this.cameraCalibOutput.TabStop = false;
            // 
            // btnLearnRed
            // 
            this.btnLearnRed.Location = new System.Drawing.Point(12, 441);
            this.btnLearnRed.Name = "btnLearnRed";
            this.btnLearnRed.Size = new System.Drawing.Size(88, 23);
            this.btnLearnRed.TabIndex = 12;
            this.btnLearnRed.Text = "Learn Red";
            this.btnLearnRed.UseVisualStyleBackColor = true;
            // 
            // btnLearnGreen
            // 
            this.btnLearnGreen.Location = new System.Drawing.Point(218, 441);
            this.btnLearnGreen.Name = "btnLearnGreen";
            this.btnLearnGreen.Size = new System.Drawing.Size(88, 23);
            this.btnLearnGreen.TabIndex = 13;
            this.btnLearnGreen.Text = "Learn Green";
            this.btnLearnGreen.UseVisualStyleBackColor = true;
            // 
            // btnLearnOrange
            // 
            this.btnLearnOrange.Location = new System.Drawing.Point(424, 441);
            this.btnLearnOrange.Name = "btnLearnOrange";
            this.btnLearnOrange.Size = new System.Drawing.Size(88, 23);
            this.btnLearnOrange.TabIndex = 14;
            this.btnLearnOrange.Text = "Learn Orange";
            this.btnLearnOrange.UseVisualStyleBackColor = true;
            // 
            // btnLearnBlue
            // 
            this.btnLearnBlue.Location = new System.Drawing.Point(630, 441);
            this.btnLearnBlue.Name = "btnLearnBlue";
            this.btnLearnBlue.Size = new System.Drawing.Size(88, 23);
            this.btnLearnBlue.TabIndex = 15;
            this.btnLearnBlue.Text = "Learn Blue";
            this.btnLearnBlue.UseVisualStyleBackColor = true;
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
            this.groupBox4.Location = new System.Drawing.Point(630, 470);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 148);
            this.groupBox4.TabIndex = 24;
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
            this.tkbBlueThreshold.Size = new System.Drawing.Size(104, 42);
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
            this.tkbBlueDilation.Size = new System.Drawing.Size(104, 42);
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
            this.tkbBlueErosion.Size = new System.Drawing.Size(104, 42);
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
            this.groupBox3.Location = new System.Drawing.Point(424, 470);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 148);
            this.groupBox3.TabIndex = 26;
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
            this.tkbOrangeThreshold.Size = new System.Drawing.Size(104, 42);
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
            this.tkbOrangeDilation.Size = new System.Drawing.Size(104, 42);
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
            this.tkbOrangeErosion.Size = new System.Drawing.Size(104, 42);
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
            this.groupBox2.Location = new System.Drawing.Point(218, 470);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 148);
            this.groupBox2.TabIndex = 25;
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
            this.tkbGreenThreshold.Size = new System.Drawing.Size(104, 42);
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
            this.tkbGreenDilation.Size = new System.Drawing.Size(104, 42);
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
            this.tkbGreenErosion.Size = new System.Drawing.Size(104, 42);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 470);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 148);
            this.groupBox1.TabIndex = 23;
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
            this.tkbRedThreshold.Size = new System.Drawing.Size(104, 42);
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
            this.tkbRedDilation.Size = new System.Drawing.Size(104, 42);
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
            this.tkbRedErosion.Size = new System.Drawing.Size(104, 42);
            this.tkbRedErosion.TabIndex = 0;
            this.tkbRedErosion.Value = 1;
            this.tkbRedErosion.Scroll += new System.EventHandler(this.tkbRedErosion_Scroll);
            // 
            // cbxShowBlue
            // 
            this.cbxShowBlue.AutoSize = true;
            this.cbxShowBlue.Location = new System.Drawing.Point(724, 447);
            this.cbxShowBlue.Name = "cbxShowBlue";
            this.cbxShowBlue.Size = new System.Drawing.Size(59, 17);
            this.cbxShowBlue.TabIndex = 37;
            this.cbxShowBlue.Text = "Enable";
            this.cbxShowBlue.UseVisualStyleBackColor = true;
            // 
            // cbxShowOrange
            // 
            this.cbxShowOrange.AutoSize = true;
            this.cbxShowOrange.Location = new System.Drawing.Point(518, 447);
            this.cbxShowOrange.Name = "cbxShowOrange";
            this.cbxShowOrange.Size = new System.Drawing.Size(59, 17);
            this.cbxShowOrange.TabIndex = 36;
            this.cbxShowOrange.Text = "Enable";
            this.cbxShowOrange.UseVisualStyleBackColor = true;
            // 
            // cbxShowGreen
            // 
            this.cbxShowGreen.AutoSize = true;
            this.cbxShowGreen.Location = new System.Drawing.Point(312, 447);
            this.cbxShowGreen.Name = "cbxShowGreen";
            this.cbxShowGreen.Size = new System.Drawing.Size(59, 17);
            this.cbxShowGreen.TabIndex = 35;
            this.cbxShowGreen.Text = "Enable";
            this.cbxShowGreen.UseVisualStyleBackColor = true;
            // 
            // cbxShowRed
            // 
            this.cbxShowRed.AutoSize = true;
            this.cbxShowRed.Location = new System.Drawing.Point(106, 447);
            this.cbxShowRed.Name = "cbxShowRed";
            this.cbxShowRed.Size = new System.Drawing.Size(59, 17);
            this.cbxShowRed.TabIndex = 34;
            this.cbxShowRed.Text = "Enable";
            this.cbxShowRed.UseVisualStyleBackColor = true;
            // 
            // btnSaveHistograms
            // 
            this.btnSaveHistograms.Location = new System.Drawing.Point(711, 624);
            this.btnSaveHistograms.Name = "btnSaveHistograms";
            this.btnSaveHistograms.Size = new System.Drawing.Size(119, 35);
            this.btnSaveHistograms.TabIndex = 38;
            this.btnSaveHistograms.Text = "Save Learning";
            this.btnSaveHistograms.UseVisualStyleBackColor = true;
            // 
            // ckbThreshold
            // 
            this.ckbThreshold.AutoSize = true;
            this.ckbThreshold.Location = new System.Drawing.Point(435, 370);
            this.ckbThreshold.Name = "ckbThreshold";
            this.ckbThreshold.Size = new System.Drawing.Size(79, 17);
            this.ckbThreshold.TabIndex = 41;
            this.ckbThreshold.Text = "Threshold?";
            this.ckbThreshold.UseVisualStyleBackColor = true;
            // 
            // ckbDilate
            // 
            this.ckbDilate.AutoSize = true;
            this.ckbDilate.Location = new System.Drawing.Point(585, 370);
            this.ckbDilate.Name = "ckbDilate";
            this.ckbDilate.Size = new System.Drawing.Size(59, 17);
            this.ckbDilate.TabIndex = 40;
            this.ckbDilate.Text = "Dilate?";
            this.ckbDilate.UseVisualStyleBackColor = true;
            // 
            // ckbErosion
            // 
            this.ckbErosion.AutoSize = true;
            this.ckbErosion.Location = new System.Drawing.Point(519, 370);
            this.ckbErosion.Name = "ckbErosion";
            this.ckbErosion.Size = new System.Drawing.Size(60, 17);
            this.ckbErosion.TabIndex = 39;
            this.ckbErosion.Text = "Erode?";
            this.ckbErosion.UseVisualStyleBackColor = true;
            // 
            // cbxDrawCalibrationMarkers
            // 
            this.cbxDrawCalibrationMarkers.AutoSize = true;
            this.cbxDrawCalibrationMarkers.Location = new System.Drawing.Point(174, 408);
            this.cbxDrawCalibrationMarkers.Name = "cbxDrawCalibrationMarkers";
            this.cbxDrawCalibrationMarkers.Size = new System.Drawing.Size(144, 17);
            this.cbxDrawCalibrationMarkers.TabIndex = 45;
            this.cbxDrawCalibrationMarkers.Text = "Draw Calibration Markers";
            this.cbxDrawCalibrationMarkers.UseVisualStyleBackColor = true;
            // 
            // cbxDrawIRPoints
            // 
            this.cbxDrawIRPoints.AutoSize = true;
            this.cbxDrawIRPoints.Location = new System.Drawing.Point(173, 370);
            this.cbxDrawIRPoints.Name = "cbxDrawIRPoints";
            this.cbxDrawIRPoints.Size = new System.Drawing.Size(97, 17);
            this.cbxDrawIRPoints.TabIndex = 44;
            this.cbxDrawIRPoints.Text = "Draw IR Points";
            this.cbxDrawIRPoints.UseVisualStyleBackColor = true;
            // 
            // btnCameraCalibrate
            // 
            this.btnCameraCalibrate.Location = new System.Drawing.Point(12, 393);
            this.btnCameraCalibrate.Name = "btnCameraCalibrate";
            this.btnCameraCalibrate.Size = new System.Drawing.Size(156, 32);
            this.btnCameraCalibrate.TabIndex = 43;
            this.btnCameraCalibrate.Text = "Camera Coordinate Calibrate";
            this.btnCameraCalibrate.UseVisualStyleBackColor = true;
            // 
            // btnWiimoteCalibrate
            // 
            this.btnWiimoteCalibrate.Location = new System.Drawing.Point(12, 355);
            this.btnWiimoteCalibrate.Name = "btnWiimoteCalibrate";
            this.btnWiimoteCalibrate.Size = new System.Drawing.Size(156, 32);
            this.btnWiimoteCalibrate.TabIndex = 42;
            this.btnWiimoteCalibrate.Text = "Wiimote IR Calibrate";
            this.btnWiimoteCalibrate.UseVisualStyleBackColor = true;
            this.btnWiimoteCalibrate.Click += new System.EventHandler(this.btnWiimoteCalibrate_Click);
            // 
            // btnCalibWizard
            // 
            this.btnCalibWizard.Location = new System.Drawing.Point(13, 10);
            this.btnCalibWizard.Name = "btnCalibWizard";
            this.btnCalibWizard.Size = new System.Drawing.Size(75, 23);
            this.btnCalibWizard.TabIndex = 46;
            this.btnCalibWizard.Text = "Run Wizard";
            this.btnCalibWizard.UseVisualStyleBackColor = true;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(103, 20);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(100, 13);
            this.lblInstructions.TabIndex = 47;
            this.lblInstructions.Text = "Instructions go here";
            // 
            // CalibrationWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 668);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnCalibWizard);
            this.Controls.Add(this.cbxDrawCalibrationMarkers);
            this.Controls.Add(this.cbxDrawIRPoints);
            this.Controls.Add(this.btnCameraCalibrate);
            this.Controls.Add(this.btnWiimoteCalibrate);
            this.Controls.Add(this.ckbThreshold);
            this.Controls.Add(this.ckbDilate);
            this.Controls.Add(this.ckbErosion);
            this.Controls.Add(this.btnSaveHistograms);
            this.Controls.Add(this.cbxShowBlue);
            this.Controls.Add(this.cbxShowOrange);
            this.Controls.Add(this.cbxShowGreen);
            this.Controls.Add(this.cbxShowRed);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLearnBlue);
            this.Controls.Add(this.btnLearnOrange);
            this.Controls.Add(this.btnLearnGreen);
            this.Controls.Add(this.btnLearnRed);
            this.Controls.Add(this.wiiCalibOutput);
            this.Controls.Add(this.cameraCalibOutput);
            this.Name = "CalibrationWizard";
            this.Text = "CalibrationWizard";
            ((System.ComponentModel.ISupportInitialize)(this.wiiCalibOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraCalibOutput)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueDilation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlueErosion)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeDilation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbOrangeErosion)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenDilation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreenErosion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedDilation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRedErosion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox wiiCalibOutput;
        private Emgu.CV.UI.ImageBox cameraCalibOutput;
        private System.Windows.Forms.Button btnLearnRed;
        private System.Windows.Forms.Button btnLearnGreen;
        private System.Windows.Forms.Button btnLearnOrange;
        private System.Windows.Forms.Button btnLearnBlue;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblBlueThreshold;
        private System.Windows.Forms.Label lblBlueThresholdLabel;
        private System.Windows.Forms.TrackBar tkbBlueThreshold;
        private System.Windows.Forms.Label lblBlueDilation;
        private System.Windows.Forms.Label lblBlueErosion;
        private System.Windows.Forms.TrackBar tkbBlueDilation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar tkbBlueErosion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblOrangeThreshold;
        private System.Windows.Forms.Label lblOrangeThresholdLabel;
        private System.Windows.Forms.TrackBar tkbOrangeThreshold;
        private System.Windows.Forms.Label lblOrangeDilation;
        private System.Windows.Forms.Label lblOrangeErosion;
        private System.Windows.Forms.TrackBar tkbOrangeDilation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tkbOrangeErosion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblGreenThreshold;
        private System.Windows.Forms.Label lblGreenThresholdLabel;
        private System.Windows.Forms.TrackBar tkbGreenThreshold;
        private System.Windows.Forms.Label lblGreenDilation;
        private System.Windows.Forms.Label lblGreenErosion;
        private System.Windows.Forms.TrackBar tkbGreenDilation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tkbGreenErosion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRedThreshold;
        private System.Windows.Forms.Label lblRedThresholdLabel;
        private System.Windows.Forms.TrackBar tkbRedThreshold;
        private System.Windows.Forms.Label lblRedDilation;
        private System.Windows.Forms.Label lblRedErosion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tkbRedDilation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tkbRedErosion;
        private System.Windows.Forms.CheckBox cbxShowBlue;
        private System.Windows.Forms.CheckBox cbxShowOrange;
        private System.Windows.Forms.CheckBox cbxShowGreen;
        private System.Windows.Forms.CheckBox cbxShowRed;
        private System.Windows.Forms.Button btnSaveHistograms;
        private System.Windows.Forms.CheckBox ckbThreshold;
        private System.Windows.Forms.CheckBox ckbDilate;
        private System.Windows.Forms.CheckBox ckbErosion;
        private System.Windows.Forms.CheckBox cbxDrawCalibrationMarkers;
        private System.Windows.Forms.CheckBox cbxDrawIRPoints;
        private System.Windows.Forms.Button btnCameraCalibrate;
        private System.Windows.Forms.Button btnWiimoteCalibrate;
        private System.Windows.Forms.Button btnCalibWizard;
        private System.Windows.Forms.Label lblInstructions;
    }
}