namespace PNPController
{
    partial class FormBoardMultiplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBoardMultiplier));
            this.buttonSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.textBoxBoardOffsetY = new System.Windows.Forms.TextBox();
            this.textBoxBoardOffsetX = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBoxPCBY = new System.Windows.Forms.TextBox();
            this.textBoxPCBX = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(256, 11);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 75);
            this.buttonSave.TabIndex = 48;
            this.buttonSave.Text = "Save Multi XML";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Num PCB Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Num PCB X";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 11);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 75);
            this.buttonLoad.TabIndex = 45;
            this.buttonLoad.Text = "Load XML";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxBoardOffsetY
            // 
            this.textBoxBoardOffsetY.Location = new System.Drawing.Point(93, 66);
            this.textBoxBoardOffsetY.Name = "textBoxBoardOffsetY";
            this.textBoxBoardOffsetY.Size = new System.Drawing.Size(75, 20);
            this.textBoxBoardOffsetY.TabIndex = 44;
            this.textBoxBoardOffsetY.Text = "10";
            // 
            // textBoxBoardOffsetX
            // 
            this.textBoxBoardOffsetX.Location = new System.Drawing.Point(93, 27);
            this.textBoxBoardOffsetX.Name = "textBoxBoardOffsetX";
            this.textBoxBoardOffsetX.Size = new System.Drawing.Size(75, 20);
            this.textBoxBoardOffsetX.TabIndex = 43;
            this.textBoxBoardOffsetX.Text = "10";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(93, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "Board Offset Y";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(93, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "Board Offset X";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // textBoxPCBY
            // 
            this.textBoxPCBY.Location = new System.Drawing.Point(175, 66);
            this.textBoxPCBY.Name = "textBoxPCBY";
            this.textBoxPCBY.Size = new System.Drawing.Size(75, 20);
            this.textBoxPCBY.TabIndex = 52;
            this.textBoxPCBY.Text = "1";
            // 
            // textBoxPCBX
            // 
            this.textBoxPCBX.Location = new System.Drawing.Point(175, 29);
            this.textBoxPCBX.Name = "textBoxPCBX";
            this.textBoxPCBX.Size = new System.Drawing.Size(75, 20);
            this.textBoxPCBX.TabIndex = 51;
            this.textBoxPCBX.Text = "1";
            // 
            // FormBoardMultiplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 94);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxBoardOffsetY);
            this.Controls.Add(this.textBoxBoardOffsetX);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxPCBY);
            this.Controls.Add(this.textBoxPCBX);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBoardMultiplier";
            this.Text = "Board Multiplier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TextBox textBoxBoardOffsetY;
        private System.Windows.Forms.TextBox textBoxBoardOffsetX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBoxPCBY;
        private System.Windows.Forms.TextBox textBoxPCBX;
    }
}