namespace EmguCVTest
{
    partial class AffineTransform
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
            this.btnCapture = new System.Windows.Forms.Button();
            this.imgImageBox = new Emgu.CV.UI.ImageBox();
            this.imageBoxPers = new Emgu.CV.UI.ImageBox();
            this.btnDrawPnt = new System.Windows.Forms.Button();
            this.btnTransform = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCurrentPoint = new System.Windows.Forms.Label();
            this.sd = new GroupLab.Networking.SharedDictionary(this.components);
            this.subscription1 = new GroupLab.Networking.Subscription(this.components);
            this.subscription2 = new GroupLab.Networking.Subscription(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.lblBL = new System.Windows.Forms.Label();
            this.lblTL = new System.Windows.Forms.Label();
            this.lblTR = new System.Windows.Forms.Label();
            this.lblBR = new System.Windows.Forms.Label();
            this.lblTouchPt = new System.Windows.Forms.Label();
            this.txtPtX = new System.Windows.Forms.TextBox();
            this.txtPtY = new System.Windows.Forms.TextBox();
            this.btnDrawPt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxPers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subscription1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subscription2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(12, 12);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // imgImageBox
            // 
            this.imgImageBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.imgImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imgImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgImageBox.Location = new System.Drawing.Point(12, 41);
            this.imgImageBox.Name = "imgImageBox";
            this.imgImageBox.Size = new System.Drawing.Size(400, 300);
            this.imgImageBox.TabIndex = 7;
            this.imgImageBox.TabStop = false;
            this.imgImageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imgImageBox_MouseClick);
            // 
            // imageBoxPers
            // 
            this.imageBoxPers.BackColor = System.Drawing.SystemColors.ControlText;
            this.imageBoxPers.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imageBoxPers.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxPers.Location = new System.Drawing.Point(418, 41);
            this.imageBoxPers.Name = "imageBoxPers";
            this.imageBoxPers.Size = new System.Drawing.Size(400, 300);
            this.imageBoxPers.TabIndex = 8;
            this.imageBoxPers.TabStop = false;
            this.imageBoxPers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageBoxPers_MouseClick);
            // 
            // btnDrawPnt
            // 
            this.btnDrawPnt.Location = new System.Drawing.Point(174, 12);
            this.btnDrawPnt.Name = "btnDrawPnt";
            this.btnDrawPnt.Size = new System.Drawing.Size(75, 23);
            this.btnDrawPnt.TabIndex = 9;
            this.btnDrawPnt.Text = "Draw Points";
            this.btnDrawPnt.UseVisualStyleBackColor = true;
            this.btnDrawPnt.Click += new System.EventHandler(this.btnDrawPnt_Click);
            // 
            // btnTransform
            // 
            this.btnTransform.Location = new System.Drawing.Point(93, 12);
            this.btnTransform.Name = "btnTransform";
            this.btnTransform.Size = new System.Drawing.Size(75, 23);
            this.btnTransform.TabIndex = 10;
            this.btnTransform.Text = "Transform";
            this.btnTransform.UseVisualStyleBackColor = true;
            this.btnTransform.Click += new System.EventHandler(this.btnTransform_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(790, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(26, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lblCurrentPoint
            // 
            this.lblCurrentPoint.AutoSize = true;
            this.lblCurrentPoint.Location = new System.Drawing.Point(353, 13);
            this.lblCurrentPoint.Name = "lblCurrentPoint";
            this.lblCurrentPoint.Size = new System.Drawing.Size(59, 13);
            this.lblCurrentPoint.TabIndex = 12;
            this.lblCurrentPoint.Text = "Draw Point";
            // 
            // sd
            // 
            this.sd.SynchronizingObject = this;
            this.sd.Url = "tcp://localhost:shareD";
            this.sd.Opened += new System.EventHandler(this.sd_Opened);
            // 
            // subscription1
            // 
            this.subscription1.Dictionary = this.sd;
            this.subscription1.Pattern = "/coordinates/pts";
            this.subscription1.Notified += new GroupLab.Networking.SubscriptionEventHandler(this.subscription1_Notified);
            // 
            // subscription2
            // 
            this.subscription2.Dictionary = this.sd;
            this.subscription2.Pattern = "/coordinates";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(256, 13);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(75, 23);
            this.btnOpenImage.TabIndex = 13;
            this.btnOpenImage.Text = "Open Image";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // lblBL
            // 
            this.lblBL.AutoSize = true;
            this.lblBL.Location = new System.Drawing.Point(498, 22);
            this.lblBL.Name = "lblBL";
            this.lblBL.Size = new System.Drawing.Size(20, 13);
            this.lblBL.TabIndex = 14;
            this.lblBL.Text = "BL";
            // 
            // lblTL
            // 
            this.lblTL.AutoSize = true;
            this.lblTL.Location = new System.Drawing.Point(498, 6);
            this.lblTL.Name = "lblTL";
            this.lblTL.Size = new System.Drawing.Size(20, 13);
            this.lblTL.TabIndex = 15;
            this.lblTL.Text = "TL";
            // 
            // lblTR
            // 
            this.lblTR.AutoSize = true;
            this.lblTR.Location = new System.Drawing.Point(564, 6);
            this.lblTR.Name = "lblTR";
            this.lblTR.Size = new System.Drawing.Size(22, 13);
            this.lblTR.TabIndex = 16;
            this.lblTR.Text = "TR";
            // 
            // lblBR
            // 
            this.lblBR.AutoSize = true;
            this.lblBR.Location = new System.Drawing.Point(564, 22);
            this.lblBR.Name = "lblBR";
            this.lblBR.Size = new System.Drawing.Size(22, 13);
            this.lblBR.TabIndex = 17;
            this.lblBR.Text = "BR";
            // 
            // lblTouchPt
            // 
            this.lblTouchPt.AutoSize = true;
            this.lblTouchPt.Location = new System.Drawing.Point(626, 6);
            this.lblTouchPt.Name = "lblTouchPt";
            this.lblTouchPt.Size = new System.Drawing.Size(51, 13);
            this.lblTouchPt.TabIndex = 18;
            this.lblTouchPt.Text = "Touch Pt";
            // 
            // txtPtX
            // 
            this.txtPtX.Location = new System.Drawing.Point(629, 19);
            this.txtPtX.Name = "txtPtX";
            this.txtPtX.Size = new System.Drawing.Size(26, 20);
            this.txtPtX.TabIndex = 19;
            // 
            // txtPtY
            // 
            this.txtPtY.Location = new System.Drawing.Point(661, 19);
            this.txtPtY.Name = "txtPtY";
            this.txtPtY.Size = new System.Drawing.Size(26, 20);
            this.txtPtY.TabIndex = 20;
            // 
            // btnDrawPt
            // 
            this.btnDrawPt.Location = new System.Drawing.Point(693, 16);
            this.btnDrawPt.Name = "btnDrawPt";
            this.btnDrawPt.Size = new System.Drawing.Size(75, 23);
            this.btnDrawPt.TabIndex = 21;
            this.btnDrawPt.Text = "Draw Pt";
            this.btnDrawPt.UseVisualStyleBackColor = true;
            this.btnDrawPt.Click += new System.EventHandler(this.btnDrawPt_Click);
            // 
            // AffineTransform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 348);
            this.Controls.Add(this.btnDrawPt);
            this.Controls.Add(this.txtPtY);
            this.Controls.Add(this.txtPtX);
            this.Controls.Add(this.lblTouchPt);
            this.Controls.Add(this.lblBR);
            this.Controls.Add(this.lblTR);
            this.Controls.Add(this.lblTL);
            this.Controls.Add(this.lblBL);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.lblCurrentPoint);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnTransform);
            this.Controls.Add(this.btnDrawPnt);
            this.Controls.Add(this.imageBoxPers);
            this.Controls.Add(this.imgImageBox);
            this.Controls.Add(this.btnCapture);
            this.Name = "AffineTransform";
            this.Text = "AffineTransform";
            this.Load += new System.EventHandler(this.AffineTransform_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AffineTransform_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.imgImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxPers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subscription1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subscription2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCapture;
        private Emgu.CV.UI.ImageBox imgImageBox;
        private Emgu.CV.UI.ImageBox imageBoxPers;
        private System.Windows.Forms.Button btnDrawPnt;
        private System.Windows.Forms.Button btnTransform;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCurrentPoint;
        private GroupLab.Networking.SharedDictionary sd;
        private GroupLab.Networking.Subscription subscription1;
        private GroupLab.Networking.Subscription subscription2;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblBL;
        private System.Windows.Forms.Label lblTouchPt;
        private System.Windows.Forms.Label lblBR;
        private System.Windows.Forms.Label lblTR;
        private System.Windows.Forms.Label lblTL;
        private System.Windows.Forms.TextBox txtPtY;
        private System.Windows.Forms.TextBox txtPtX;
        private System.Windows.Forms.Button btnDrawPt;
    }
}