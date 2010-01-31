namespace EmguCVTest
{
    partial class ColorSampleForm
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
            this.sampleImageBox = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.C1textBox = new System.Windows.Forms.TextBox();
            this.C2textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.K2textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.K1textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.K4textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.K3textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSat = new System.Windows.Forms.TextBox();
            this.textBoxHue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnYccParam = new System.Windows.Forms.Button();
            this.btnAvgHS = new System.Windows.Forms.Button();
            this.btnWPcalib = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sampleImageBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sampleImageBox
            // 
            this.sampleImageBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.sampleImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.sampleImageBox.Location = new System.Drawing.Point(0, 0);
            this.sampleImageBox.Name = "sampleImageBox";
            this.sampleImageBox.Size = new System.Drawing.Size(400, 300);
            this.sampleImageBox.TabIndex = 9;
            this.sampleImageBox.TabStop = false;
            this.sampleImageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sample_mouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(139, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mean";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(45, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "C1";
            // 
            // C1textBox
            // 
            this.C1textBox.Location = new System.Drawing.Point(73, 43);
            this.C1textBox.Name = "C1textBox";
            this.C1textBox.ReadOnly = true;
            this.C1textBox.Size = new System.Drawing.Size(57, 20);
            this.C1textBox.TabIndex = 12;
            // 
            // C2textBox
            // 
            this.C2textBox.Location = new System.Drawing.Point(198, 43);
            this.C2textBox.Name = "C2textBox";
            this.C2textBox.ReadOnly = true;
            this.C2textBox.Size = new System.Drawing.Size(57, 20);
            this.C2textBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.Location = new System.Drawing.Point(170, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "C2";
            // 
            // K2textBox
            // 
            this.K2textBox.Location = new System.Drawing.Point(198, 110);
            this.K2textBox.Name = "K2textBox";
            this.K2textBox.ReadOnly = true;
            this.K2textBox.Size = new System.Drawing.Size(57, 20);
            this.K2textBox.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(170, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "K2";
            // 
            // K1textBox
            // 
            this.K1textBox.Location = new System.Drawing.Point(73, 110);
            this.K1textBox.Name = "K1textBox";
            this.K1textBox.ReadOnly = true;
            this.K1textBox.Size = new System.Drawing.Size(57, 20);
            this.K1textBox.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.Location = new System.Drawing.Point(45, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "K1";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label6.Location = new System.Drawing.Point(128, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "CoVariance";
            // 
            // K4textBox
            // 
            this.K4textBox.Location = new System.Drawing.Point(198, 156);
            this.K4textBox.Name = "K4textBox";
            this.K4textBox.ReadOnly = true;
            this.K4textBox.Size = new System.Drawing.Size(57, 20);
            this.K4textBox.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label7.Location = new System.Drawing.Point(170, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "K4";
            // 
            // K3textBox
            // 
            this.K3textBox.Location = new System.Drawing.Point(73, 156);
            this.K3textBox.Name = "K3textBox";
            this.K3textBox.ReadOnly = true;
            this.K3textBox.Size = new System.Drawing.Size(57, 20);
            this.K3textBox.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label8.Location = new System.Drawing.Point(45, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "K3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.K4textBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.K3textBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.K2textBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.K1textBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.C2textBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.C1textBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.groupBox1.Location = new System.Drawing.Point(406, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 200);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CbCr Param";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSat);
            this.groupBox2.Controls.Add(this.textBoxHue);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.groupBox2.Location = new System.Drawing.Point(411, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 72);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Avg. Hue and Sat.";
            // 
            // textBoxSat
            // 
            this.textBoxSat.Location = new System.Drawing.Point(193, 35);
            this.textBoxSat.Name = "textBoxSat";
            this.textBoxSat.ReadOnly = true;
            this.textBoxSat.Size = new System.Drawing.Size(57, 20);
            this.textBoxSat.TabIndex = 27;
            // 
            // textBoxHue
            // 
            this.textBoxHue.Location = new System.Drawing.Point(68, 35);
            this.textBoxHue.Name = "textBoxHue";
            this.textBoxHue.ReadOnly = true;
            this.textBoxHue.Size = new System.Drawing.Size(57, 20);
            this.textBoxHue.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label9.Location = new System.Drawing.Point(165, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Sat";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label10.Location = new System.Drawing.Point(40, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Hue";
            // 
            // btnYccParam
            // 
            this.btnYccParam.Location = new System.Drawing.Point(1, 304);
            this.btnYccParam.Name = "btnYccParam";
            this.btnYccParam.Size = new System.Drawing.Size(93, 34);
            this.btnYccParam.TabIndex = 26;
            this.btnYccParam.Text = "YCbCr Param";
            this.btnYccParam.UseVisualStyleBackColor = true;
            this.btnYccParam.Click += new System.EventHandler(this.btnYccParam_Click);
            // 
            // btnAvgHS
            // 
            this.btnAvgHS.Location = new System.Drawing.Point(100, 304);
            this.btnAvgHS.Name = "btnAvgHS";
            this.btnAvgHS.Size = new System.Drawing.Size(112, 33);
            this.btnAvgHS.TabIndex = 27;
            this.btnAvgHS.Text = "Avg. Hue and Sat";
            this.btnAvgHS.UseVisualStyleBackColor = true;
            this.btnAvgHS.Click += new System.EventHandler(this.btnAvgHS_Click);
            // 
            // btnWPcalib
            // 
            this.btnWPcalib.Location = new System.Drawing.Point(215, 306);
            this.btnWPcalib.Name = "btnWPcalib";
            this.btnWPcalib.Size = new System.Drawing.Size(95, 30);
            this.btnWPcalib.TabIndex = 28;
            this.btnWPcalib.Text = "WP calibration";
            this.btnWPcalib.UseVisualStyleBackColor = true;
            this.btnWPcalib.Click += new System.EventHandler(this.btnWPcalib_Click);
            // 
            // ColorSampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 339);
            this.Controls.Add(this.btnWPcalib);
            this.Controls.Add(this.btnAvgHS);
            this.Controls.Add(this.btnYccParam);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sampleImageBox);
            this.Name = "ColorSampleForm";
            this.Text = "ColorSampleForm";
            ((System.ComponentModel.ISupportInitialize)(this.sampleImageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox sampleImageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox C1textBox;
        private System.Windows.Forms.TextBox C2textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox K2textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox K1textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox K4textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox K3textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxSat;
        private System.Windows.Forms.TextBox textBoxHue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnYccParam;
        private System.Windows.Forms.Button btnAvgHS;
        private System.Windows.Forms.Button btnWPcalib;
    }
}