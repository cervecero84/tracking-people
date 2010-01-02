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
            ((System.ComponentModel.ISupportInitialize)(this.imgImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxPers)).BeginInit();
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
            this.btnClear.Location = new System.Drawing.Point(742, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lblCurrentPoint
            // 
            this.lblCurrentPoint.AutoSize = true;
            this.lblCurrentPoint.Location = new System.Drawing.Point(418, 12);
            this.lblCurrentPoint.Name = "lblCurrentPoint";
            this.lblCurrentPoint.Size = new System.Drawing.Size(59, 13);
            this.lblCurrentPoint.TabIndex = 12;
            this.lblCurrentPoint.Text = "Draw Point";
            // 
            // AffineTransform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 348);
            this.Controls.Add(this.lblCurrentPoint);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnTransform);
            this.Controls.Add(this.btnDrawPnt);
            this.Controls.Add(this.imageBoxPers);
            this.Controls.Add(this.imgImageBox);
            this.Controls.Add(this.btnCapture);
            this.Name = "AffineTransform";
            this.Text = "AffineTransform";
            ((System.ComponentModel.ISupportInitialize)(this.imgImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxPers)).EndInit();
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
    }
}