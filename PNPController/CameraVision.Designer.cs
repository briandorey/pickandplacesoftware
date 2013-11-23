namespace PNPController
{
    partial class CameraVision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraVision));
            this.buttonStartupCamera = new System.Windows.Forms.Button();
            this.labelDebug2 = new System.Windows.Forms.Label();
            this.labelDebug = new System.Windows.Forms.Label();
            this.labelImgHeight = new System.Windows.Forms.Label();
            this.labelImgWidth = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxDeg = new System.Windows.Forms.TextBox();
            this.textBoxImageY = new System.Windows.Forms.TextBox();
            this.textBoxImageX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonVideoStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartupCamera
            // 
            this.buttonStartupCamera.Location = new System.Drawing.Point(16, 348);
            this.buttonStartupCamera.Name = "buttonStartupCamera";
            this.buttonStartupCamera.Size = new System.Drawing.Size(116, 23);
            this.buttonStartupCamera.TabIndex = 81;
            this.buttonStartupCamera.Text = "Startup Camera";
            this.buttonStartupCamera.UseVisualStyleBackColor = true;
            this.buttonStartupCamera.Click += new System.EventHandler(this.buttonStartupCamera_Click);
            // 
            // labelDebug2
            // 
            this.labelDebug2.AutoSize = true;
            this.labelDebug2.Location = new System.Drawing.Point(880, 422);
            this.labelDebug2.Name = "labelDebug2";
            this.labelDebug2.Size = new System.Drawing.Size(65, 13);
            this.labelDebug2.TabIndex = 80;
            this.labelDebug2.Text = "Debug Data";
            // 
            // labelDebug
            // 
            this.labelDebug.AutoSize = true;
            this.labelDebug.Location = new System.Drawing.Point(881, 406);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(65, 13);
            this.labelDebug.TabIndex = 79;
            this.labelDebug.Text = "Debug Data";
            // 
            // labelImgHeight
            // 
            this.labelImgHeight.AutoSize = true;
            this.labelImgHeight.Location = new System.Drawing.Point(956, 383);
            this.labelImgHeight.Name = "labelImgHeight";
            this.labelImgHeight.Size = new System.Drawing.Size(22, 13);
            this.labelImgHeight.TabIndex = 78;
            this.labelImgHeight.Text = "0.0";
            // 
            // labelImgWidth
            // 
            this.labelImgWidth.AutoSize = true;
            this.labelImgWidth.Location = new System.Drawing.Point(956, 358);
            this.labelImgWidth.Name = "labelImgWidth";
            this.labelImgWidth.Size = new System.Drawing.Size(22, 13);
            this.labelImgWidth.TabIndex = 77;
            this.labelImgWidth.Text = "0.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(880, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 76;
            this.label8.Text = "Image Height";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(880, 358);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 75;
            this.label9.Text = "Image Width";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(501, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(483, 330);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 74;
            this.pictureBox2.TabStop = false;
            // 
            // textBoxDeg
            // 
            this.textBoxDeg.Location = new System.Drawing.Point(369, 383);
            this.textBoxDeg.Name = "textBoxDeg";
            this.textBoxDeg.Size = new System.Drawing.Size(230, 20);
            this.textBoxDeg.TabIndex = 73;
            // 
            // textBoxImageY
            // 
            this.textBoxImageY.Location = new System.Drawing.Point(645, 358);
            this.textBoxImageY.Name = "textBoxImageY";
            this.textBoxImageY.Size = new System.Drawing.Size(167, 20);
            this.textBoxImageY.TabIndex = 72;
            // 
            // textBoxImageX
            // 
            this.textBoxImageX.Location = new System.Drawing.Point(369, 358);
            this.textBoxImageX.Name = "textBoxImageX";
            this.textBoxImageX.Size = new System.Drawing.Size(230, 20);
            this.textBoxImageX.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(329, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 70;
            this.label10.Text = "Deg";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(605, 358);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 69;
            this.label11.Text = "Y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(329, 358);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 68;
            this.label12.Text = "X";
            // 
            // buttonVideoStart
            // 
            this.buttonVideoStart.Location = new System.Drawing.Point(143, 348);
            this.buttonVideoStart.Name = "buttonVideoStart";
            this.buttonVideoStart.Size = new System.Drawing.Size(139, 23);
            this.buttonVideoStart.TabIndex = 67;
            this.buttonVideoStart.Text = "Capture Chip";
            this.buttonVideoStart.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(483, 330);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CameraVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 612);
            this.Controls.Add(this.buttonStartupCamera);
            this.Controls.Add(this.labelDebug2);
            this.Controls.Add(this.labelDebug);
            this.Controls.Add(this.labelImgHeight);
            this.Controls.Add(this.labelImgWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxDeg);
            this.Controls.Add(this.textBoxImageY);
            this.Controls.Add(this.textBoxImageX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonVideoStart);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CameraVision";
            this.Text = "Camera Vision";
            this.Load += new System.EventHandler(this.CameraVision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartupCamera;
        private System.Windows.Forms.Label labelDebug2;
        private System.Windows.Forms.Label labelDebug;
        private System.Windows.Forms.Label labelImgHeight;
        private System.Windows.Forms.Label labelImgWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxDeg;
        private System.Windows.Forms.TextBox textBoxImageY;
        private System.Windows.Forms.TextBox textBoxImageX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonVideoStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}