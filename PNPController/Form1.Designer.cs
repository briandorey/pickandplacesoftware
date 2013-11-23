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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorkerUpdateDRO = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerDoCommand = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorkerGetFeeder = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerChipFeeder = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxPCB = new System.Windows.Forms.PictureBox();
            this.ribbonUpDown1 = new System.Windows.Forms.RibbonUpDown();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonButtonSmallOpen = new System.Windows.Forms.RibbonButton();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonStart = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonStop = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonEStop = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTextBoxBoardOffsetX = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBoxBoardOffsetY = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBoxPCBThickness = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBoxFeedRate = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonCheckAll = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonUnCheckAll = new System.Windows.Forms.RibbonButton();
            this.ribbonPanelChipMS = new System.Windows.Forms.RibbonPanel();
            this.ribbonTextBoxChipMS = new System.Windows.Forms.RibbonTextBox();
            this.ribbonButtonChipFeederShake = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonCheckBoxLEDPicker = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBoxLEDCamera = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbonCheckBoxVACPicker1 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBoxVACPicker2 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonTab5 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanelVisionOne = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonBaseCameraOpen = new System.Windows.Forms.RibbonButton();
            this.ribbonPanelVisionTwo = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonVisionPickerCamera = new System.Windows.Forms.RibbonButton();
            this.ribbonTab6 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTextBoxDROX = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBoxDROY = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBoxDROZ = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBoxDROA = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBoxDROB = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBoxDROC = new System.Windows.Forms.RibbonTextBox();
            this.ribbonButtonDROStart = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonDROStop = new System.Windows.Forms.RibbonButton();
            this.ribbonPanelManualControlJog = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonManualJOGLeft = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonManualJOGRight = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonManualJOGUp = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonManualJOGDown = new System.Windows.Forms.RibbonButton();
            this.ribbonPanelManualP1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonManualControlPicker1Left = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonManualControlPicker1Right = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonManualControlPicker1Up = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonManualControlPicker1Down = new System.Windows.Forms.RibbonButton();
            this.ribbonPanelManualP2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonManualControlPicker2Left = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonManualControlPicker2Right = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonManualControlPicker2Up = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonManualControlPicker2Down = new System.Windows.Forms.RibbonButton();
            this.ribbonPanelManualFeederAct = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton7 = new System.Windows.Forms.RibbonButton();
            this.ribbonTabMisc = new System.Windows.Forms.RibbonTab();
            this.ribbonPanelMiscOne = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonComponentEditorOpen = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonOpen = new System.Windows.Forms.RibbonButton();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonTextBox1 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelActiveComponent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCurrentCommand = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelresultLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ribbonButton8 = new System.Windows.Forms.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPCB)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorkerUpdateDRO
            // 
            this.backgroundWorkerUpdateDRO.WorkerReportsProgress = true;
            this.backgroundWorkerUpdateDRO.WorkerSupportsCancellation = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorkerDoCommand
            // 
            this.backgroundWorkerDoCommand.WorkerReportsProgress = true;
            this.backgroundWorkerDoCommand.WorkerSupportsCancellation = true;
            this.backgroundWorkerDoCommand.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDoCommand_DoWork);
            // 
            // backgroundWorkerGetFeeder
            // 
            this.backgroundWorkerGetFeeder.WorkerSupportsCancellation = true;
            // 
            // backgroundWorkerChipFeeder
            // 
            this.backgroundWorkerChipFeeder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerChipFeeder_DoWork);
            // 
            // pictureBoxPCB
            // 
            this.pictureBoxPCB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPCB.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxPCB.InitialImage")));
            this.pictureBoxPCB.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxPCB.Name = "pictureBoxPCB";
            this.pictureBoxPCB.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxPCB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPCB.TabIndex = 21;
            this.pictureBoxPCB.TabStop = false;
            // 
            // ribbonUpDown1
            // 
            this.ribbonUpDown1.TextBoxText = "";
            this.ribbonUpDown1.TextBoxWidth = 50;
            // 
            // ribbon1
            // 
            this.ribbon1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ribbon1.BackColor = System.Drawing.SystemColors.Control;
            this.ribbon1.BorderMode = System.Windows.Forms.RibbonWindowMode.NonClientAreaCustomDrawn;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(0, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = ((System.Drawing.Image)(resources.GetObject("ribbon1.OrbImage")));
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Items.Add(this.ribbonButtonSmallOpen);
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Size = new System.Drawing.Size(1020, 174);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab4);
            this.ribbon1.Tabs.Add(this.ribbonTab5);
            this.ribbon1.Tabs.Add(this.ribbonTab6);
            this.ribbon1.Tabs.Add(this.ribbonTabMisc);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonButtonSmallOpen
            // 
            this.ribbonButtonSmallOpen.DropDownItems.Add(this.ribbonButton4);
            this.ribbonButtonSmallOpen.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonSmallOpen.Image")));
            this.ribbonButtonSmallOpen.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonSmallOpen.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonSmallOpen.SmallImage")));
            this.ribbonButtonSmallOpen.Text = "Open CSV File";
            this.ribbonButtonSmallOpen.Click += new System.EventHandler(this.ribbonButtonSmallOpen_Click);
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "ribbonButton4";
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Panels.Add(this.ribbonPanel1);
            this.ribbonTab4.Panels.Add(this.ribbonPanel2);
            this.ribbonTab4.Panels.Add(this.ribbonPanel6);
            this.ribbonTab4.Panels.Add(this.ribbonPanelChipMS);
            this.ribbonTab4.Panels.Add(this.ribbonPanel3);
            this.ribbonTab4.Panels.Add(this.ribbonPanel4);
            this.ribbonTab4.Text = "Pick and Place";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreEnabled = false;
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.ribbonButtonStart);
            this.ribbonPanel1.Items.Add(this.ribbonButtonStop);
            this.ribbonPanel1.Items.Add(this.ribbonButtonEStop);
            this.ribbonPanel1.Items.Add(this.ribbonButton6);
            this.ribbonPanel1.Text = "Run Control";
            // 
            // ribbonButtonStart
            // 
            this.ribbonButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonStart.Image")));
            this.ribbonButtonStart.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonStart.SmallImage")));
            this.ribbonButtonStart.Text = "Start";
            this.ribbonButtonStart.Click += new System.EventHandler(this.ribbonButtonStart_Click);
            // 
            // ribbonButtonStop
            // 
            this.ribbonButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonStop.Image")));
            this.ribbonButtonStop.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonStop.SmallImage")));
            this.ribbonButtonStop.Text = "Stop";
            this.ribbonButtonStop.Click += new System.EventHandler(this.buttonStopGCode_Click);
            // 
            // ribbonButtonEStop
            // 
            this.ribbonButtonEStop.DropDownItems.Add(this.ribbonButton5);
            this.ribbonButtonEStop.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonEStop.Image")));
            this.ribbonButtonEStop.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonEStop.SmallImage")));
            this.ribbonButtonEStop.Text = "E-Stop";
            this.ribbonButtonEStop.Click += new System.EventHandler(this.ribbonButtonEStop_Click_1);
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "ribbonButton5";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "Home";
            this.ribbonButton6.Click += new System.EventHandler(this.buttonHomeAll_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreEnabled = false;
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.ribbonTextBoxBoardOffsetX);
            this.ribbonPanel2.Items.Add(this.ribbonTextBoxBoardOffsetY);
            this.ribbonPanel2.Items.Add(this.ribbonTextBoxPCBThickness);
            this.ribbonPanel2.Items.Add(this.ribbonTextBoxFeedRate);
            this.ribbonPanel2.Text = "PCB";
            // 
            // ribbonTextBoxBoardOffsetX
            // 
            this.ribbonTextBoxBoardOffsetX.LabelWidth = 110;
            this.ribbonTextBoxBoardOffsetX.Text = "Board Offset X";
            this.ribbonTextBoxBoardOffsetX.TextBoxText = "36.7";
            this.ribbonTextBoxBoardOffsetX.TextBoxWidth = 50;
            this.ribbonTextBoxBoardOffsetX.ToolTip = "Change Board X Offset";
            this.ribbonTextBoxBoardOffsetX.Value = "37";
            // 
            // ribbonTextBoxBoardOffsetY
            // 
            this.ribbonTextBoxBoardOffsetY.LabelWidth = 110;
            this.ribbonTextBoxBoardOffsetY.Text = "Board Offset Y";
            this.ribbonTextBoxBoardOffsetY.TextBoxText = "74.7";
            this.ribbonTextBoxBoardOffsetY.TextBoxWidth = 50;
            this.ribbonTextBoxBoardOffsetY.Value = "74.7";
            // 
            // ribbonTextBoxPCBThickness
            // 
            this.ribbonTextBoxPCBThickness.LabelWidth = 110;
            this.ribbonTextBoxPCBThickness.Text = "PCB Thickness";
            this.ribbonTextBoxPCBThickness.TextBoxText = "1.6";
            this.ribbonTextBoxPCBThickness.TextBoxWidth = 50;
            this.ribbonTextBoxPCBThickness.ToolTip = "Set the PCB Thickness";
            this.ribbonTextBoxPCBThickness.Value = "1.6";
            // 
            // ribbonTextBoxFeedRate
            // 
            this.ribbonTextBoxFeedRate.LabelWidth = 110;
            this.ribbonTextBoxFeedRate.Text = "Feed Rate";
            this.ribbonTextBoxFeedRate.TextBoxText = "20000";
            this.ribbonTextBoxFeedRate.TextBoxWidth = 50;
            this.ribbonTextBoxFeedRate.Value = "20000";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ButtonMoreVisible = false;
            this.ribbonPanel6.Items.Add(this.ribbonButtonCheckAll);
            this.ribbonPanel6.Items.Add(this.ribbonButtonUnCheckAll);
            this.ribbonPanel6.Text = "Current PCB";
            // 
            // ribbonButtonCheckAll
            // 
            this.ribbonButtonCheckAll.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonCheckAll.Image")));
            this.ribbonButtonCheckAll.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonCheckAll.SmallImage")));
            this.ribbonButtonCheckAll.Text = "Check All";
            this.ribbonButtonCheckAll.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.ribbonButtonCheckAll.Click += new System.EventHandler(this.ribbonButtonCheckAll_Click);
            // 
            // ribbonButtonUnCheckAll
            // 
            this.ribbonButtonUnCheckAll.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonUnCheckAll.Image")));
            this.ribbonButtonUnCheckAll.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonUnCheckAll.SmallImage")));
            this.ribbonButtonUnCheckAll.Text = "Uncheck All";
            this.ribbonButtonUnCheckAll.Click += new System.EventHandler(this.ribbonButtonUnCheckAll_Click);
            // 
            // ribbonPanelChipMS
            // 
            this.ribbonPanelChipMS.ButtonMoreVisible = false;
            this.ribbonPanelChipMS.Items.Add(this.ribbonTextBoxChipMS);
            this.ribbonPanelChipMS.Items.Add(this.ribbonButtonChipFeederShake);
            this.ribbonPanelChipMS.Text = "Chip Feeder Shake";
            // 
            // ribbonTextBoxChipMS
            // 
            this.ribbonTextBoxChipMS.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonTextBoxChipMS.Text = "Time MS";
            this.ribbonTextBoxChipMS.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            this.ribbonTextBoxChipMS.TextBoxText = "750";
            this.ribbonTextBoxChipMS.TextBoxWidth = 40;
            this.ribbonTextBoxChipMS.Value = "750";
            // 
            // ribbonButtonChipFeederShake
            // 
            this.ribbonButtonChipFeederShake.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonChipFeederShake.Image")));
            this.ribbonButtonChipFeederShake.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonChipFeederShake.SmallImage")));
            this.ribbonButtonChipFeederShake.Text = "Activate";
            this.ribbonButtonChipFeederShake.ToolTip = "Activate Chip Feeder Motor";
            this.ribbonButtonChipFeederShake.Click += new System.EventHandler(this.ribbonButtonChipFeederShake_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreEnabled = false;
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.ribbonCheckBoxLEDPicker);
            this.ribbonPanel3.Items.Add(this.ribbonCheckBoxLEDCamera);
            this.ribbonPanel3.Text = "LED";
            // 
            // ribbonCheckBoxLEDPicker
            // 
            this.ribbonCheckBoxLEDPicker.Text = "Picker";
            this.ribbonCheckBoxLEDPicker.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBoxLEDPicker_CheckBoxCheckChanged);
            // 
            // ribbonCheckBoxLEDCamera
            // 
            this.ribbonCheckBoxLEDCamera.Text = "Camera";
            this.ribbonCheckBoxLEDCamera.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBoxLEDCamera_CheckBoxCheckChanged);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ButtonMoreVisible = false;
            this.ribbonPanel4.Items.Add(this.ribbonCheckBoxVACPicker1);
            this.ribbonPanel4.Items.Add(this.ribbonCheckBoxVACPicker2);
            this.ribbonPanel4.Text = "Vacuum";
            // 
            // ribbonCheckBoxVACPicker1
            // 
            this.ribbonCheckBoxVACPicker1.Text = "Picker 1";
            // 
            // ribbonCheckBoxVACPicker2
            // 
            this.ribbonCheckBoxVACPicker2.Text = "Picker 2";
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Panels.Add(this.ribbonPanelVisionOne);
            this.ribbonTab5.Panels.Add(this.ribbonPanelVisionTwo);
            this.ribbonTab5.Text = "Vision";
            // 
            // ribbonPanelVisionOne
            // 
            this.ribbonPanelVisionOne.ButtonMoreVisible = false;
            this.ribbonPanelVisionOne.Items.Add(this.ribbonButtonBaseCameraOpen);
            this.ribbonPanelVisionOne.Text = "Base Camera";
            // 
            // ribbonButtonBaseCameraOpen
            // 
            this.ribbonButtonBaseCameraOpen.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonBaseCameraOpen.Image")));
            this.ribbonButtonBaseCameraOpen.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonBaseCameraOpen.SmallImage")));
            this.ribbonButtonBaseCameraOpen.Text = "Open Camera";
            this.ribbonButtonBaseCameraOpen.Click += new System.EventHandler(this.ribbonButtonBaseCameraOpen_Click);
            // 
            // ribbonPanelVisionTwo
            // 
            this.ribbonPanelVisionTwo.ButtonMoreVisible = false;
            this.ribbonPanelVisionTwo.Items.Add(this.ribbonButtonVisionPickerCamera);
            this.ribbonPanelVisionTwo.Text = "Picker Camera";
            // 
            // ribbonButtonVisionPickerCamera
            // 
            this.ribbonButtonVisionPickerCamera.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonVisionPickerCamera.Image")));
            this.ribbonButtonVisionPickerCamera.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonVisionPickerCamera.SmallImage")));
            this.ribbonButtonVisionPickerCamera.Text = "Open Camera";
            this.ribbonButtonVisionPickerCamera.Click += new System.EventHandler(this.ribbonButtonVisionPickerCamera_Click);
            // 
            // ribbonTab6
            // 
            this.ribbonTab6.Panels.Add(this.ribbonPanel5);
            this.ribbonTab6.Panels.Add(this.ribbonPanelManualControlJog);
            this.ribbonTab6.Panels.Add(this.ribbonPanelManualP1);
            this.ribbonTab6.Panels.Add(this.ribbonPanelManualP2);
            this.ribbonTab6.Panels.Add(this.ribbonPanelManualFeederAct);
            this.ribbonTab6.Text = "Manual Control";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ButtonMoreVisible = false;
            this.ribbonPanel5.Items.Add(this.ribbonTextBoxDROX);
            this.ribbonPanel5.Items.Add(this.ribbonTextBoxDROY);
            this.ribbonPanel5.Items.Add(this.ribbonTextBoxDROZ);
            this.ribbonPanel5.Items.Add(this.ribbonTextBoxDROA);
            this.ribbonPanel5.Items.Add(this.ribbonTextBoxDROB);
            this.ribbonPanel5.Items.Add(this.ribbonTextBoxDROC);
            this.ribbonPanel5.Items.Add(this.ribbonButtonDROStart);
            this.ribbonPanel5.Items.Add(this.ribbonButtonDROStop);
            this.ribbonPanel5.Text = "DRO";
            // 
            // ribbonTextBoxDROX
            // 
            this.ribbonTextBoxDROX.AllowTextEdit = false;
            this.ribbonTextBoxDROX.LabelWidth = 50;
            this.ribbonTextBoxDROX.Text = "X Axis";
            this.ribbonTextBoxDROX.TextBoxText = "";
            this.ribbonTextBoxDROX.TextBoxWidth = 80;
            // 
            // ribbonTextBoxDROY
            // 
            this.ribbonTextBoxDROY.AllowTextEdit = false;
            this.ribbonTextBoxDROY.LabelWidth = 50;
            this.ribbonTextBoxDROY.Text = "Y Axis";
            this.ribbonTextBoxDROY.TextBoxText = "";
            this.ribbonTextBoxDROY.TextBoxWidth = 80;
            // 
            // ribbonTextBoxDROZ
            // 
            this.ribbonTextBoxDROZ.AllowTextEdit = false;
            this.ribbonTextBoxDROZ.LabelWidth = 50;
            this.ribbonTextBoxDROZ.Text = "Z Axis";
            this.ribbonTextBoxDROZ.TextBoxText = "";
            this.ribbonTextBoxDROZ.TextBoxWidth = 80;
            // 
            // ribbonTextBoxDROA
            // 
            this.ribbonTextBoxDROA.LabelWidth = 50;
            this.ribbonTextBoxDROA.Text = "A Axis";
            this.ribbonTextBoxDROA.TextBoxText = "";
            this.ribbonTextBoxDROA.TextBoxWidth = 80;
            // 
            // ribbonTextBoxDROB
            // 
            this.ribbonTextBoxDROB.AllowTextEdit = false;
            this.ribbonTextBoxDROB.LabelWidth = 50;
            this.ribbonTextBoxDROB.Text = "B Axis";
            this.ribbonTextBoxDROB.TextBoxText = "";
            this.ribbonTextBoxDROB.TextBoxWidth = 80;
            // 
            // ribbonTextBoxDROC
            // 
            this.ribbonTextBoxDROC.AllowTextEdit = false;
            this.ribbonTextBoxDROC.LabelWidth = 50;
            this.ribbonTextBoxDROC.Text = "C Axis";
            this.ribbonTextBoxDROC.TextBoxText = "";
            this.ribbonTextBoxDROC.TextBoxWidth = 80;
            // 
            // ribbonButtonDROStart
            // 
            this.ribbonButtonDROStart.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonDROStart.Image")));
            this.ribbonButtonDROStart.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonDROStart.SmallImage")));
            this.ribbonButtonDROStart.Text = "Start";
            this.ribbonButtonDROStart.Click += new System.EventHandler(this.ribbonButtonDROStart_Click);
            // 
            // ribbonButtonDROStop
            // 
            this.ribbonButtonDROStop.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonDROStop.Image")));
            this.ribbonButtonDROStop.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonDROStop.SmallImage")));
            this.ribbonButtonDROStop.Text = "Stop";
            this.ribbonButtonDROStop.Click += new System.EventHandler(this.ribbonButtonDROStop_Click);
            // 
            // ribbonPanelManualControlJog
            // 
            this.ribbonPanelManualControlJog.ButtonMoreVisible = false;
            this.ribbonPanelManualControlJog.FlowsTo = System.Windows.Forms.RibbonPanelFlowDirection.Right;
            this.ribbonPanelManualControlJog.Items.Add(this.ribbonButtonManualJOGLeft);
            this.ribbonPanelManualControlJog.Items.Add(this.ribbonButtonManualJOGRight);
            this.ribbonPanelManualControlJog.Items.Add(this.ribbonButtonManualJOGUp);
            this.ribbonPanelManualControlJog.Items.Add(this.ribbonButtonManualJOGDown);
            this.ribbonPanelManualControlJog.Text = "JOG";
            // 
            // ribbonButtonManualJOGLeft
            // 
            this.ribbonButtonManualJOGLeft.DropDownItems.Add(this.ribbonButton2);
            this.ribbonButtonManualJOGLeft.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualJOGLeft.Image")));
            this.ribbonButtonManualJOGLeft.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualJOGLeft.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualJOGLeft.SmallImage")));
            this.ribbonButtonManualJOGLeft.Text = "Left";
            this.ribbonButtonManualJOGLeft.Click += new System.EventHandler(this.ribbonButtonManualJOGLeft_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // ribbonButtonManualJOGRight
            // 
            this.ribbonButtonManualJOGRight.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualJOGRight.Image")));
            this.ribbonButtonManualJOGRight.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualJOGRight.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualJOGRight.SmallImage")));
            this.ribbonButtonManualJOGRight.Text = "Right";
            this.ribbonButtonManualJOGRight.Click += new System.EventHandler(this.ribbonButtonManualJOGRight_Click);
            // 
            // ribbonButtonManualJOGUp
            // 
            this.ribbonButtonManualJOGUp.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualJOGUp.Image")));
            this.ribbonButtonManualJOGUp.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualJOGUp.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualJOGUp.SmallImage")));
            this.ribbonButtonManualJOGUp.Text = "Up";
            this.ribbonButtonManualJOGUp.Click += new System.EventHandler(this.ribbonButtonManualJOGUp_Click);
            // 
            // ribbonButtonManualJOGDown
            // 
            this.ribbonButtonManualJOGDown.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualJOGDown.Image")));
            this.ribbonButtonManualJOGDown.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualJOGDown.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualJOGDown.SmallImage")));
            this.ribbonButtonManualJOGDown.Text = "Down";
            this.ribbonButtonManualJOGDown.Click += new System.EventHandler(this.ribbonButtonManualJOGDown_Click);
            // 
            // ribbonPanelManualP1
            // 
            this.ribbonPanelManualP1.ButtonMoreVisible = false;
            this.ribbonPanelManualP1.FlowsTo = System.Windows.Forms.RibbonPanelFlowDirection.Right;
            this.ribbonPanelManualP1.Items.Add(this.ribbonButtonManualControlPicker1Left);
            this.ribbonPanelManualP1.Items.Add(this.ribbonButtonManualControlPicker1Right);
            this.ribbonPanelManualP1.Items.Add(this.ribbonButtonManualControlPicker1Up);
            this.ribbonPanelManualP1.Items.Add(this.ribbonButtonManualControlPicker1Down);
            this.ribbonPanelManualP1.Text = "Picker 1";
            // 
            // ribbonButtonManualControlPicker1Left
            // 
            this.ribbonButtonManualControlPicker1Left.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker1Left.Image")));
            this.ribbonButtonManualControlPicker1Left.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualControlPicker1Left.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker1Left.SmallImage")));
            this.ribbonButtonManualControlPicker1Left.Text = "Left";
            // 
            // ribbonButtonManualControlPicker1Right
            // 
            this.ribbonButtonManualControlPicker1Right.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker1Right.Image")));
            this.ribbonButtonManualControlPicker1Right.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualControlPicker1Right.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker1Right.SmallImage")));
            this.ribbonButtonManualControlPicker1Right.Text = "Right";
            // 
            // ribbonButtonManualControlPicker1Up
            // 
            this.ribbonButtonManualControlPicker1Up.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker1Up.Image")));
            this.ribbonButtonManualControlPicker1Up.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualControlPicker1Up.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker1Up.SmallImage")));
            this.ribbonButtonManualControlPicker1Up.Text = "Up";
            // 
            // ribbonButtonManualControlPicker1Down
            // 
            this.ribbonButtonManualControlPicker1Down.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker1Down.Image")));
            this.ribbonButtonManualControlPicker1Down.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualControlPicker1Down.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker1Down.SmallImage")));
            this.ribbonButtonManualControlPicker1Down.Text = "Down";
            // 
            // ribbonPanelManualP2
            // 
            this.ribbonPanelManualP2.ButtonMoreVisible = false;
            this.ribbonPanelManualP2.FlowsTo = System.Windows.Forms.RibbonPanelFlowDirection.Right;
            this.ribbonPanelManualP2.Items.Add(this.ribbonButtonManualControlPicker2Left);
            this.ribbonPanelManualP2.Items.Add(this.ribbonButtonManualControlPicker2Right);
            this.ribbonPanelManualP2.Items.Add(this.ribbonButtonManualControlPicker2Up);
            this.ribbonPanelManualP2.Items.Add(this.ribbonButtonManualControlPicker2Down);
            this.ribbonPanelManualP2.Text = "Picker 2";
            // 
            // ribbonButtonManualControlPicker2Left
            // 
            this.ribbonButtonManualControlPicker2Left.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker2Left.Image")));
            this.ribbonButtonManualControlPicker2Left.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualControlPicker2Left.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker2Left.SmallImage")));
            this.ribbonButtonManualControlPicker2Left.Text = "Left";
            // 
            // ribbonButtonManualControlPicker2Right
            // 
            this.ribbonButtonManualControlPicker2Right.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker2Right.Image")));
            this.ribbonButtonManualControlPicker2Right.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualControlPicker2Right.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker2Right.SmallImage")));
            this.ribbonButtonManualControlPicker2Right.Text = "Right";
            // 
            // ribbonButtonManualControlPicker2Up
            // 
            this.ribbonButtonManualControlPicker2Up.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker2Up.Image")));
            this.ribbonButtonManualControlPicker2Up.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualControlPicker2Up.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker2Up.SmallImage")));
            this.ribbonButtonManualControlPicker2Up.Text = "Up";
            // 
            // ribbonButtonManualControlPicker2Down
            // 
            this.ribbonButtonManualControlPicker2Down.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker2Down.Image")));
            this.ribbonButtonManualControlPicker2Down.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonManualControlPicker2Down.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonManualControlPicker2Down.SmallImage")));
            this.ribbonButtonManualControlPicker2Down.Text = "Down";
            // 
            // ribbonPanelManualFeederAct
            // 
            this.ribbonPanelManualFeederAct.ButtonMoreVisible = false;
            this.ribbonPanelManualFeederAct.Items.Add(this.ribbonButton7);
            this.ribbonPanelManualFeederAct.Text = "Manual Selection";
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.Image")));
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            this.ribbonButton7.Text = "Open Selector";
            this.ribbonButton7.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            // 
            // ribbonTabMisc
            // 
            this.ribbonTabMisc.Panels.Add(this.ribbonPanelMiscOne);
            this.ribbonTabMisc.Text = "Misc";
            // 
            // ribbonPanelMiscOne
            // 
            this.ribbonPanelMiscOne.ButtonMoreVisible = false;
            this.ribbonPanelMiscOne.Items.Add(this.ribbonButtonComponentEditorOpen);
            this.ribbonPanelMiscOne.Text = "Components";
            // 
            // ribbonButtonComponentEditorOpen
            // 
            this.ribbonButtonComponentEditorOpen.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonComponentEditorOpen.Image")));
            this.ribbonButtonComponentEditorOpen.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonComponentEditorOpen.SmallImage")));
            this.ribbonButtonComponentEditorOpen.Text = "Component Editor";
            this.ribbonButtonComponentEditorOpen.Click += new System.EventHandler(this.ribbonButtonComponentEditorOpen_Click);
            // 
            // ribbonButtonOpen
            // 
            this.ribbonButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonOpen.Image")));
            this.ribbonButtonOpen.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonOpen.SmallImage")));
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Text = null;
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Text = null;
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Text = null;
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            // 
            // ribbonTextBox1
            // 
            this.ribbonTextBox1.AllowTextEdit = false;
            this.ribbonTextBox1.Text = "Board Offset X";
            this.ribbonTextBox1.TextBoxText = "37";
            this.ribbonTextBox1.TextBoxWidth = 50;
            this.ribbonTextBox1.ToolTip = "Change Board X Offset";
            this.ribbonTextBox1.Value = "37";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Camera Off";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabelActiveComponent,
            this.toolStripStatusLabelCurrentCommand,
            this.toolStripStatusLabelresultLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 808);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1020, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(0, 3, 1, 3);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabelActiveComponent
            // 
            this.toolStripStatusLabelActiveComponent.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.toolStripStatusLabelActiveComponent.Name = "toolStripStatusLabelActiveComponent";
            this.toolStripStatusLabelActiveComponent.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabelActiveComponent.Text = "Active Component:";
            // 
            // toolStripStatusLabelCurrentCommand
            // 
            this.toolStripStatusLabelCurrentCommand.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.toolStripStatusLabelCurrentCommand.Name = "toolStripStatusLabelCurrentCommand";
            this.toolStripStatusLabelCurrentCommand.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabelCurrentCommand.Text = "Current Command:";
            // 
            // toolStripStatusLabelresultLabel
            // 
            this.toolStripStatusLabelresultLabel.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.toolStripStatusLabelresultLabel.Name = "toolStripStatusLabelresultLabel";
            this.toolStripStatusLabelresultLabel.Size = new System.Drawing.Size(18, 17);
            this.toolStripStatusLabelresultLabel.Text = " - ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxPCB, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 180);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1020, 625);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(303, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(714, 619);
            this.dataGridView1.TabIndex = 22;
            // 
            // ribbonButton8
            // 
            this.ribbonButton8.DropDownItems.Add(this.ribbonButton2);
            this.ribbonButton8.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.Image")));
            this.ribbonButton8.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton8.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.SmallImage")));
            this.ribbonButton8.Text = "Left";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 830);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Pick and Place Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPCB)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdateDRO;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDoCommand;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGetFeeder;
        private System.ComponentModel.BackgroundWorker backgroundWorkerChipFeeder;
        private System.Windows.Forms.RibbonUpDown ribbonUpDown1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonButton ribbonButtonOpen;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonButton ribbonButtonSmallOpen;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab ribbonTab5;
        private System.Windows.Forms.RibbonTab ribbonTab6;
        private System.Windows.Forms.RibbonButton ribbonButtonStart;
        private System.Windows.Forms.RibbonButton ribbonButtonStop;
        private System.Windows.Forms.RibbonButton ribbonButtonEStop;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxBoardOffsetX;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxBoardOffsetY;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxPCBThickness;
        private System.Windows.Forms.RibbonTextBox ribbonTextBox1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBoxVACPicker1;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBoxLEDPicker;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBoxLEDCamera;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBoxVACPicker2;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton ribbonButton6;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxFeedRate;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton ribbonButtonCheckAll;
        private System.Windows.Forms.RibbonButton ribbonButtonUnCheckAll;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCurrentCommand;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelActiveComponent;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelresultLabel;
        private System.Windows.Forms.PictureBox pictureBoxPCB;
        private System.Windows.Forms.RibbonPanel ribbonPanelChipMS;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxChipMS;
        private System.Windows.Forms.RibbonButton ribbonButtonChipFeederShake;
        private System.Windows.Forms.RibbonTab ribbonTabMisc;
        private System.Windows.Forms.RibbonPanel ribbonPanelMiscOne;
        private System.Windows.Forms.RibbonButton ribbonButtonComponentEditorOpen;
        private System.Windows.Forms.RibbonPanel ribbonPanelVisionOne;
        private System.Windows.Forms.RibbonButton ribbonButtonBaseCameraOpen;
        private System.Windows.Forms.RibbonPanel ribbonPanelVisionTwo;
        private System.Windows.Forms.RibbonButton ribbonButtonVisionPickerCamera;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxDROX;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxDROY;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxDROZ;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxDROA;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxDROB;
        private System.Windows.Forms.RibbonTextBox ribbonTextBoxDROC;
        private System.Windows.Forms.RibbonButton ribbonButtonDROStart;
        private System.Windows.Forms.RibbonButton ribbonButtonDROStop;
        private System.Windows.Forms.RibbonPanel ribbonPanelManualControlJog;
        private System.Windows.Forms.RibbonButton ribbonButtonManualJOGLeft;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton ribbonButtonManualJOGRight;
        private System.Windows.Forms.RibbonButton ribbonButtonManualJOGUp;
        private System.Windows.Forms.RibbonButton ribbonButtonManualJOGDown;
        private System.Windows.Forms.RibbonPanel ribbonPanelManualP1;
        private System.Windows.Forms.RibbonPanel ribbonPanelManualP2;
        private System.Windows.Forms.RibbonPanel ribbonPanelManualFeederAct;
        private System.Windows.Forms.RibbonButton ribbonButton7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RibbonButton ribbonButton8;
        private System.Windows.Forms.RibbonButton ribbonButtonManualControlPicker1Left;
        private System.Windows.Forms.RibbonButton ribbonButtonManualControlPicker1Right;
        private System.Windows.Forms.RibbonButton ribbonButtonManualControlPicker1Up;
        private System.Windows.Forms.RibbonButton ribbonButtonManualControlPicker1Down;
        private System.Windows.Forms.RibbonButton ribbonButtonManualControlPicker2Left;
        private System.Windows.Forms.RibbonButton ribbonButtonManualControlPicker2Right;
        private System.Windows.Forms.RibbonButton ribbonButtonManualControlPicker2Up;
        private System.Windows.Forms.RibbonButton ribbonButtonManualControlPicker2Down;
    }
}

