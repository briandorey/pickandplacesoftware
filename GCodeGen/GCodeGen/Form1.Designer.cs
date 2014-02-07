namespace PNPController
{
    partial class Form1
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
            this.resultLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBoardFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFeedersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedersToolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStartGode = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonSaveGCode = new System.Windows.Forms.Button();
            this.textBoxBoardOffsetY = new System.Windows.Forms.TextBox();
            this.textBoxBoardOffsetX = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxGCode = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewFeeders = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBoxRunSpeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeeders)).BeginInit();
            this.SuspendLayout();
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.resultLabel.Location = new System.Drawing.Point(3, 3);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(39, 13);
            this.resultLabel.TabIndex = 13;
            this.resultLabel.Text = "Debug";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBoardFileToolStripMenuItem,
            this.saveFeedersListToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openBoardFileToolStripMenuItem
            // 
            this.openBoardFileToolStripMenuItem.Name = "openBoardFileToolStripMenuItem";
            this.openBoardFileToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openBoardFileToolStripMenuItem.Text = "Open CSV Board File";
            this.openBoardFileToolStripMenuItem.Click += new System.EventHandler(this.openBoardFileToolStripMenuItem_Click);
            // 
            // saveFeedersListToolStripMenuItem
            // 
            this.saveFeedersListToolStripMenuItem.Name = "saveFeedersListToolStripMenuItem";
            this.saveFeedersListToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveFeedersListToolStripMenuItem.Text = "Save Feeders List";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.feedersToolStripMenuItemAdd});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.settingsToolStripMenuItem.Text = "Feeder Management";
            // 
            // feedersToolStripMenuItemAdd
            // 
            this.feedersToolStripMenuItemAdd.Name = "feedersToolStripMenuItemAdd";
            this.feedersToolStripMenuItemAdd.Size = new System.Drawing.Size(194, 22);
            this.feedersToolStripMenuItemAdd.Text = "Add / Update Changes";
            this.feedersToolStripMenuItemAdd.Click += new System.EventHandler(this.feedersToolStripMenuItemAdd_Click);
            // 
            // buttonStartGode
            // 
            this.buttonStartGode.Location = new System.Drawing.Point(13, 160);
            this.buttonStartGode.Name = "buttonStartGode";
            this.buttonStartGode.Size = new System.Drawing.Size(148, 84);
            this.buttonStartGode.TabIndex = 17;
            this.buttonStartGode.Text = "Gen GCode";
            this.buttonStartGode.UseVisualStyleBackColor = true;
            this.buttonStartGode.Click += new System.EventHandler(this.buttonStartGode_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 687);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxRunSpeed);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonSaveGCode);
            this.tabPage1.Controls.Add(this.textBoxBoardOffsetY);
            this.tabPage1.Controls.Add(this.textBoxBoardOffsetX);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.textBoxGCode);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.resultLabel);
            this.tabPage1.Controls.Add(this.buttonStartGode);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 661);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Job";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonSaveGCode
            // 
            this.buttonSaveGCode.Location = new System.Drawing.Point(13, 250);
            this.buttonSaveGCode.Name = "buttonSaveGCode";
            this.buttonSaveGCode.Size = new System.Drawing.Size(148, 84);
            this.buttonSaveGCode.TabIndex = 26;
            this.buttonSaveGCode.Text = "Save GCode";
            this.buttonSaveGCode.UseVisualStyleBackColor = true;
            this.buttonSaveGCode.Click += new System.EventHandler(this.buttonSaveGCode_Click);
            // 
            // textBoxBoardOffsetY
            // 
            this.textBoxBoardOffsetY.Location = new System.Drawing.Point(13, 80);
            this.textBoxBoardOffsetY.Name = "textBoxBoardOffsetY";
            this.textBoxBoardOffsetY.Size = new System.Drawing.Size(139, 20);
            this.textBoxBoardOffsetY.TabIndex = 25;
            this.textBoxBoardOffsetY.Text = "90";
            // 
            // textBoxBoardOffsetX
            // 
            this.textBoxBoardOffsetX.Location = new System.Drawing.Point(13, 41);
            this.textBoxBoardOffsetX.Name = "textBoxBoardOffsetX";
            this.textBoxBoardOffsetX.Size = new System.Drawing.Size(139, 20);
            this.textBoxBoardOffsetX.TabIndex = 24;
            this.textBoxBoardOffsetX.Text = "10";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Board Offset Y";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Board Offset X";
            // 
            // textBoxGCode
            // 
            this.textBoxGCode.Location = new System.Drawing.Point(5, 340);
            this.textBoxGCode.Multiline = true;
            this.textBoxGCode.Name = "textBoxGCode";
            this.textBoxGCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxGCode.Size = new System.Drawing.Size(989, 313);
            this.textBoxGCode.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(179, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(813, 282);
            this.dataGridView1.TabIndex = 20;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewFeeders);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1000, 661);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Component Feeders";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFeeders
            // 
            this.dataGridViewFeeders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFeeders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFeeders.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewFeeders.Name = "dataGridViewFeeders";
            this.dataGridViewFeeders.Size = new System.Drawing.Size(994, 655);
            this.dataGridViewFeeders.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // textBoxRunSpeed
            // 
            this.textBoxRunSpeed.Location = new System.Drawing.Point(13, 119);
            this.textBoxRunSpeed.Name = "textBoxRunSpeed";
            this.textBoxRunSpeed.Size = new System.Drawing.Size(139, 20);
            this.textBoxRunSpeed.TabIndex = 28;
            this.textBoxRunSpeed.Text = "20000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Speed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 711);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Pick and Place Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeeders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBoardFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedersToolStripMenuItemAdd;
        private System.Windows.Forms.Button buttonStartGode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem saveFeedersListToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewFeeders;
        private System.Windows.Forms.TextBox textBoxGCode;
        private System.Windows.Forms.TextBox textBoxBoardOffsetY;
        private System.Windows.Forms.TextBox textBoxBoardOffsetX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonSaveGCode;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBoxRunSpeed;
        private System.Windows.Forms.Label label1;
    }
}

