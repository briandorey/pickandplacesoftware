namespace PNPControllerKFlop
{
    partial class ManualPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualPicker));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonActiveandPick = new System.Windows.Forms.Button();
            this.buttonPickerDown = new System.Windows.Forms.Button();
            this.buttonPickerUP = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Feeder";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(55, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(70, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // buttonActiveandPick
            // 
            this.buttonActiveandPick.Location = new System.Drawing.Point(12, 46);
            this.buttonActiveandPick.Name = "buttonActiveandPick";
            this.buttonActiveandPick.Size = new System.Drawing.Size(121, 23);
            this.buttonActiveandPick.TabIndex = 2;
            this.buttonActiveandPick.Text = "Activate and Pick";
            this.buttonActiveandPick.UseVisualStyleBackColor = true;
            this.buttonActiveandPick.Click += new System.EventHandler(this.buttonActiveandPick_Click);
            // 
            // buttonPickerDown
            // 
            this.buttonPickerDown.Location = new System.Drawing.Point(6, 48);
            this.buttonPickerDown.Name = "buttonPickerDown";
            this.buttonPickerDown.Size = new System.Drawing.Size(97, 23);
            this.buttonPickerDown.TabIndex = 3;
            this.buttonPickerDown.Text = "Picker Down";
            this.buttonPickerDown.UseVisualStyleBackColor = true;
            this.buttonPickerDown.Click += new System.EventHandler(this.buttonPickerDown_Click);
            // 
            // buttonPickerUP
            // 
            this.buttonPickerUP.Location = new System.Drawing.Point(6, 19);
            this.buttonPickerUP.Name = "buttonPickerUP";
            this.buttonPickerUP.Size = new System.Drawing.Size(97, 23);
            this.buttonPickerUP.TabIndex = 4;
            this.buttonPickerUP.Text = "Picker Up";
            this.buttonPickerUP.UseVisualStyleBackColor = true;
            this.buttonPickerUP.Click += new System.EventHandler(this.buttonPickerUP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonActiveandPick);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 114);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select and Pick";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonReset);
            this.groupBox2.Controls.Add(this.buttonPickerUP);
            this.groupBox2.Controls.Add(this.buttonPickerDown);
            this.groupBox2.Location = new System.Drawing.Point(164, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 113);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual Control";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(6, 77);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(97, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset Picker";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // ManualPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 141);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManualPicker";
            this.Text = "Feeder Selector";
            this.Load += new System.EventHandler(this.ManualPicker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonActiveandPick;
        private System.Windows.Forms.Button buttonPickerDown;
        private System.Windows.Forms.Button buttonPickerUP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonReset;
    }
}