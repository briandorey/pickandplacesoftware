namespace PNPControllerKFlop
{
    partial class ComponentVision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentVision));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDROX = new System.Windows.Forms.TextBox();
            this.textBoxDROY = new System.Windows.Forms.TextBox();
            this.buttonXPlus = new System.Windows.Forms.Button();
            this.buttonYMinus = new System.Windows.Forms.Button();
            this.buttonYPlus = new System.Windows.Forms.Button();
            this.buttonXMinus = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerUpdateDRO = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(406, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(612, 501);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "DRO X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "DRO Y";
            // 
            // textBoxDROX
            // 
            this.textBoxDROX.Location = new System.Drawing.Point(79, 13);
            this.textBoxDROX.Name = "textBoxDROX";
            this.textBoxDROX.Size = new System.Drawing.Size(321, 20);
            this.textBoxDROX.TabIndex = 5;
            // 
            // textBoxDROY
            // 
            this.textBoxDROY.Location = new System.Drawing.Point(79, 44);
            this.textBoxDROY.Name = "textBoxDROY";
            this.textBoxDROY.Size = new System.Drawing.Size(321, 20);
            this.textBoxDROY.TabIndex = 6;
            // 
            // buttonXPlus
            // 
            this.buttonXPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXPlus.Location = new System.Drawing.Point(90, 82);
            this.buttonXPlus.Name = "buttonXPlus";
            this.buttonXPlus.Size = new System.Drawing.Size(75, 52);
            this.buttonXPlus.TabIndex = 7;
            this.buttonXPlus.Text = "X +";
            this.buttonXPlus.UseVisualStyleBackColor = true;
            this.buttonXPlus.Click += new System.EventHandler(this.buttonXPlus_Click);
            this.buttonXPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonYMinus
            // 
            this.buttonYMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonYMinus.Location = new System.Drawing.Point(16, 140);
            this.buttonYMinus.Name = "buttonYMinus";
            this.buttonYMinus.Size = new System.Drawing.Size(75, 52);
            this.buttonYMinus.TabIndex = 8;
            this.buttonYMinus.Text = "Y -";
            this.buttonYMinus.UseVisualStyleBackColor = true;
            this.buttonYMinus.Click += new System.EventHandler(this.buttonYMinus_Click);
            this.buttonYMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonYPlus
            // 
            this.buttonYPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonYPlus.Location = new System.Drawing.Point(163, 140);
            this.buttonYPlus.Name = "buttonYPlus";
            this.buttonYPlus.Size = new System.Drawing.Size(75, 52);
            this.buttonYPlus.TabIndex = 9;
            this.buttonYPlus.Text = "Y +";
            this.buttonYPlus.UseVisualStyleBackColor = true;
            this.buttonYPlus.Click += new System.EventHandler(this.buttonYPlus_Click);
            this.buttonYPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // buttonXMinus
            // 
            this.buttonXMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXMinus.Location = new System.Drawing.Point(90, 198);
            this.buttonXMinus.Name = "buttonXMinus";
            this.buttonXMinus.Size = new System.Drawing.Size(75, 52);
            this.buttonXMinus.TabIndex = 10;
            this.buttonXMinus.Text = "X -";
            this.buttonXMinus.UseVisualStyleBackColor = true;
            this.buttonXMinus.Click += new System.EventHandler(this.buttonXMinus_Click);
            this.buttonXMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 306);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(43, 17);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "100";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 329);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(43, 17);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.Text = "200";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(16, 352);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(43, 17);
            this.radioButton3.TabIndex = 13;
            this.radioButton3.Text = "300";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(16, 375);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(43, 17);
            this.radioButton4.TabIndex = 14;
            this.radioButton4.Text = "400";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(16, 398);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(43, 17);
            this.radioButton5.TabIndex = 15;
            this.radioButton5.Text = "500";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ComponentVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 501);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.buttonXMinus);
            this.Controls.Add(this.buttonYPlus);
            this.Controls.Add(this.buttonYMinus);
            this.Controls.Add(this.buttonXPlus);
            this.Controls.Add(this.textBoxDROY);
            this.Controls.Add(this.textBoxDROX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComponentVision";
            this.Text = "Component Vision";
            this.Load += new System.EventHandler(this.ComponentVision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDROX;
        private System.Windows.Forms.TextBox textBoxDROY;
        private System.Windows.Forms.Button buttonXPlus;
        private System.Windows.Forms.Button buttonYMinus;
        private System.Windows.Forms.Button buttonYPlus;
        private System.Windows.Forms.Button buttonXMinus;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Timer timer2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdateDRO;
    }
}