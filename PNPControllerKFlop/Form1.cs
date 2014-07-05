using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;     // DLL support
using System.IO; 
using System.Text.RegularExpressions;
using System.Windows.Forms.RibbonHelpers;
using System.Net;
using System.Diagnostics;
using usbGenericHidCommunications;

namespace PNPControllerKFlop
{
    public partial class Form1 : RibbonForm
    {
        // bed settings
        public double NeedleZHeight = 35;
        public double Xoffset = -0.116;
        public double Yoffset = 0.0;

        public double NeedleXSpacing = -32.2;
        public double dblPCBThickness = 1.6;
        public int FeedRate = 20000;
        public int chipfeederms = 250;
        public double ClearHeight = 15;
        public double LowClearHeight = 15;

        public DataSet dsMain;
        public DataTable dtFeeders;
        // Add these two lines
       

       // remote control 
        HttpListener listener = new HttpListener();
        string listeningURL = "http://10.0.0.8:8080/";

        // Create an instance of the USB reference device
        private usbDevice usbController;
        byte BaseCameraPWM = 150;
        byte HeadCameraPWM = 150;
        byte VibrationMotorSpeed = 150;

        // manual picker selector
        public int currentfeeder = 0;


        private delegate void SetTextCallback(System.Windows.Forms.Control control, string text);

        private delegate void SetDROTextCallback(System.Windows.Forms.RibbonTextBox control, string text);


        private ComponentFeeders cf = new ComponentFeeders();
        private Components comp = new Components();
        private PCBLoader csvload = new PCBLoader();
        private DataToMach3 dtom3 = new DataToMach3();

        private kflop kf = new kflop();

       


        public Form1()
        {
            InitializeComponent();
              

            usbController = new usbDevice(0x04D8, 0x0042);


            usbController.usbEvent += new usbDevice.usbEventsHandler(usbEvent_receiver);

            
            usbController.findTargetDevice();


           

            InitializeBackgroundWorker();
            this.FormClosing += new FormClosingEventHandler(Form_FormClosing);

            dtFeeders = cf.POPFeedersTable();
            kf.initdevice();
            LoadSettings();


            RunBoardInit();
            Thread thrdRemote = new Thread(new ThreadStart(initRemote));
            thrdRemote.Start();
            thrdRemote.IsBackground = true;
         
           
            csvload.SetupGridView(dataGridView1);

            
            // setup manual feeder single picker list

            
            
        }

        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            timer1.Stop();
            backgroundWorkerDoCommand.CancelAsync();
            backgroundWorkerUpdateDRO.CancelAsync();
          }

        private void usbEvent_receiver(object o, EventArgs e)
        {
            // Check the status of the USB device and update the form accordingly
            if (usbController.isDeviceAttached)
            {
                // Device is currently attached
                SetResultsLabelText("USB Device is attached");

            }
            else
            {
                // Device is currently unattached

                // Update the status label
                SetResultsLabelText("USB Device is detached");
            }
        }
        /// <summary>
        ///  RunBoardInit() run self test on control board and initalise all settings
        /// </summary>
        private void RunBoardInit()
        {
            usbController.setBaseCameraPWM(byte.Parse(ribbonTextBoxBaseLedBrightness.TextBoxText));
            usbController.setHeadCameraPWM(byte.Parse(ribbonTextBoxHeadLedBrightness.TextBoxText));
           // usbController.setVibrationMotorSpeed(byte.Parse(ribbonTextBoxMotorPWM.TextBoxText));
            usbController.setVibrationMotorSpeed(250);
            usbController.setVAC1(false);
            usbController.setVAC2(false);
           // usbController.setResetFeeder();
           // SetFeederOutputs(15);
            /*
            Thread.Sleep(200);
            
            usbController.setVibrationMotor(true);
            Thread.Sleep(500);
            usbController.setVibrationMotor(false);
            usbController.setVibrationMotorSpeed(250);
            Thread.Sleep(500);
            usbController.setHeadCameraLED(true);
            Thread.Sleep(500);
            usbController.setHeadCameraLED(false);
            Thread.Sleep(500);
            usbController.setBaseCameraLED(true);
            Thread.Sleep(500);
            usbController.setBaseCameraLED(false);
            Thread.Sleep(500);
            usbController.setVAC1(true);
            Thread.Sleep(500);
            usbController.setVAC1(false);
            Thread.Sleep(500);
            usbController.setVAC2(true);
            Thread.Sleep(500);
            
             * */
        }

        public double CalcAZHeight(double targetheight)
        {
            return NeedleZHeight - targetheight;
           // return targetheight;
        }
        public double CalcAZPlaceHeight(double targetheight)
        {
            return (NeedleZHeight - targetheight) - dblPCBThickness;
        }

        public double CalcXwithNeedleSpacing(double target)
        {
            return (NeedleXSpacing + target);
        }


       // Thread safe updating of control's text property
        public void SetText(System.Windows.Forms.Control control, string text)
        {
            try
            {
                if (control.InvokeRequired)
                {

                    SetTextCallback d = new SetTextCallback(SetText);
                    Invoke(d, new object[] { control, text });

                }
                else
                {
                    control.Text = text;
                }
            }
            catch { }
        }
        
        public void SetDROText(System.Windows.Forms.RibbonTextBox control, string text)
        {
            try
            {
                if (this.ribbon1.InvokeRequired)
                {

                    SetDROTextCallback d = new SetDROTextCallback(SetDROText);
                    Invoke(d, new object[] { control, text });

                }
                else
                {
                    control.TextBoxText = text;
                }
            }
            catch { }
        }
        
        private void StetActiveComponentText(string text)
        {
            text = "Current Component: " + text;
            if (this.statusStrip1.InvokeRequired)
                this.statusStrip1.Invoke(
                                       new MethodInvoker(() => this.toolStripStatusLabelCurrentCommand.Text = text));
            else this.toolStripStatusLabelCurrentCommand.Text = text;
        }

        private void SetCurrentCommandText(string text)
        {
            text = "Active Command: " + text;
            if (this.statusStrip1.InvokeRequired)
                this.statusStrip1.Invoke(
                                       new MethodInvoker(() => this.toolStripStatusLabelActiveComponent.Text = text));
            else this.toolStripStatusLabelActiveComponent.Text = text;
        }
        private void SetRemoteIPText(string text)
        {
            text = "Remote IP: " + text;
            if (this.statusStrip1.InvokeRequired)
                this.statusStrip1.Invoke(
                                       new MethodInvoker(() => this.toolStripStatusLabelIP.Text = text));
            else this.toolStripStatusLabelIP.Text = text;
        }


        private void SetResultsLabelText(string text)
        {
            if (this.statusStrip1.InvokeRequired)
                this.statusStrip1.Invoke(
                                       new MethodInvoker(() => this.toolStripStatusLabelresultLabel.Text = text));
            else this.toolStripStatusLabelresultLabel.Text = text;
        } 

        


        private void InitializeBackgroundWorker()
        {
            backgroundWorkerUpdateDRO.DoWork +=
                new DoWorkEventHandler(backgroundWorkerUpdateDRO_DoWork_1);
            backgroundWorkerUpdateDRO.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorkerUpdateDRO_RunWorkerCompleted);
            backgroundWorkerUpdateDRO.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorkerUpdateDRO_ProgressChanged);




            backgroundWorkerDoCommand.DoWork +=
                new DoWorkEventHandler(backgroundWorkerDoCommand_DoWork);
            backgroundWorkerDoCommand.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorkerDoCommand_RunWorkerCompleted);
            backgroundWorkerDoCommand.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorkerDoCommand_ProgressChanged);
            
                        
            backgroundWorkerGetFeeder.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorkerGetFeeder_RunWorkerCompleted);
            backgroundWorkerGetFeeder.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorkerGetFeeder_ProgressChanged);




            backgroundWorkerChipFeeder.DoWork +=
                new DoWorkEventHandler(backgroundWorkerChipFeeder_DoWork);
        }






        private void backgroundWorkerUpdateDRO_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabelresultLabel.Text = "Running!";
        }
        private void backgroundWorkerDoCommand_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabelresultLabel.Text = "Running!";
        }
        private void backgroundWorkerGetFeeder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabelresultLabel.Text = "Running!";
        }

        // This event handler deals with the results of the background operation. 
        private void backgroundWorkerUpdateDRO_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                toolStripStatusLabelresultLabel.Text = "Cancelled!";
            }
            else if (e.Error != null)
            {
                toolStripStatusLabelresultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                toolStripStatusLabelresultLabel.Text = "Done!";
            }
        }
        private void backgroundWorkerDoCommand_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                toolStripStatusLabelresultLabel.Text = "Canceled!";
               
            }
            else if (e.Error != null)
            {
                toolStripStatusLabelresultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                toolStripStatusLabelresultLabel.Text = "Done!";
            }
        }

        private void backgroundWorkerGetFeeder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                toolStripStatusLabelresultLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                toolStripStatusLabelresultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                toolStripStatusLabelresultLabel.Text = "Done!";
            }
        }

        private void CheckFeederReady()
        {
            while (!usbController.getFeederReadyStatus())
            {
                Thread.Sleep(50);
            }
        }

        
        private void backgroundWorkerUpdateDRO_DoWork_1(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;


            if (backgroundWorkerUpdateDRO.CancellationPending)
            {
                e.Cancel = true;
            }
            double x, y, z, a, b, c = 0;
            kf.GetDRO(out x, out y, out z, out a, out b, out c);

            SetDROText(ribbonTextBoxDROX, x.ToString());
            SetDROText(ribbonTextBoxDROY, y.ToString());
            SetDROText(ribbonTextBoxDROZ, z.ToString());
            SetDROText(ribbonTextBoxDROA, a.ToString());
            SetDROText(ribbonTextBoxDROB, b.ToString());
            SetDROText(ribbonTextBoxDROC, c.ToString());
            worker.ReportProgress(100);
        }
        private void backgroundWorkerDoCommand_DoWork(object sender, DoWorkEventArgs e)
        {
           
            BackgroundWorker worker = sender as BackgroundWorker;
            DataView rundata = new DataView();
            rundata = dtom3.ConvertToGCode(dataGridView1, Double.Parse(ribbonTextBoxBoardOffsetX.TextBoxText), Double.Parse(ribbonTextBoxBoardOffsetY.TextBoxText));
             double feedrate = double.Parse(ribbonTextBoxFeedRate.TextBoxText);
            
            int currentrow = 0;
            int totalrows = rundata.Count;
            if (totalrows > 0)
            {
                // MessageBox.Show(totalrows.ToString());
              //  RunMach3Command(Script, "G01 B0 C0");

                /* table columns
                 RefDes
                    Type
                    PosX
                    PosY
                    ComponentRotation
                    ComponentValue
                    feederNumber
                    Code


                    ComponentHeight
                    DefaultRotation
                    VerifywithCamera
                    TapeFeeder


                    feederPosX
                    feederPosY
                    feederPosZ
                    PickPlusChipHeight
                 * */

                double progresspert = 0;
                double progresspertcalc = 100 / totalrows;

                double feederPosX = 0;
                double feederPosY = 0;
                double feederPosZ = 0;
                double placePosX = 0;
                double placePosY = 0;
            
                double ComponentRotation = 0;
                double DefaultRotation = 0;
                double componentHeight = 0;
                double newrotation = 0;
                while (currentrow < totalrows)
                {

                    if (backgroundWorkerDoCommand.CancellationPending)
                    {
                        e.Cancel = true;
                        SetCurrentCommandText("Stopped");


                        rundata.Dispose();
                        break;
                    }

                    feederPosX = double.Parse(rundata[currentrow]["feederPosX"].ToString()) + Xoffset;
                    feederPosY = double.Parse(rundata[currentrow]["feederPosY"].ToString()) + Yoffset;
                    feederPosZ = double.Parse(rundata[currentrow]["feederPosZ"].ToString());
                    placePosX = double.Parse(rundata[currentrow]["PosX"].ToString()) + Xoffset;
                    placePosY = double.Parse(rundata[currentrow]["PosY"].ToString()) + Yoffset;
                   
                    ComponentRotation = double.Parse(rundata[currentrow]["ComponentRotation"].ToString());
                    DefaultRotation = double.Parse(rundata[currentrow]["DefaultRotation"].ToString());

                    componentHeight = double.Parse(rundata[currentrow]["ComponentHeight"].ToString());


                    if (currentrow == 0)
                    {
                        SetFeederOutputs(Int32.Parse(rundata[currentrow]["FeederNumber"].ToString())); // send feeder to position
                    }
                    SetCurrentCommandText("Feeder Activate");
                    SetCurrentCommandText(rundata[currentrow]["RefDes"].ToString());
                    StetActiveComponentText(rundata[currentrow]["RefDes"].ToString());



                    kf.MoveSingleFeed(feedrate, feederPosX, feederPosY, ClearHeight, ClearHeight, 0, 0);

                    SetCurrentCommandText("Picking Component");
                    if (rundata[currentrow]["TapeFeeder"].ToString().Equals("True"))
                    {

                        while (!usbController.getFeederReadyStatus())
                        {
                            Thread.Sleep(10);
                        }
                        Thread.Sleep(150);
                        // use picker 1
                        kf.MoveSingleFeed(feedrate, feederPosX, feederPosY, CalcAZHeight(feederPosZ), ClearHeight, 0, 0);
                       
                        // go down and turn on suction
                        ChangeVacOutput(1, true);
                        Thread.Sleep(200);
                        kf.MoveSingleFeed(feedrate, feederPosX, feederPosY, ClearHeight, ClearHeight, 0, 0);

                    }
                    else
                    {
                        // use picker 2
                        kf.MoveSingleFeed(feedrate, feederPosX, feederPosY, ClearHeight, CalcAZHeight(feederPosZ), 0, 0);

                        ChangeVacOutput(2, true);
                        //Thread.Sleep(500);
                        Thread.Sleep(200);
                        kf.MoveSingleFeed(feedrate, feederPosX, feederPosY, ClearHeight, ClearHeight, 0, 0);
                    }
                    // send picker to pick next item
                    if (currentrow >= 0 && (currentrow + 1) < totalrows)
                    {
                        Thread.Sleep(100);
                        SetFeederOutputs(Int32.Parse(rundata[currentrow + 1]["FeederNumber"].ToString())); // send feeder to position
                    }

                    // rotate head
                 

                    SetResultsLabelText("Placing Component");
                    if (rundata[currentrow]["TapeFeeder"].ToString().Equals("True"))
                    {
                        // use picker 1
                        if (DefaultRotation != ComponentRotation)
                        {
                            newrotation = DefaultRotation + ComponentRotation;
                            if (ComponentRotation == 0)
                            {
                                newrotation = DefaultRotation;

                            }
                            kf.MoveSingleFeed(feedrate, placePosX, placePosY, ClearHeight, ClearHeight, 0, newrotation);
                        }
                        else
                        {
                            kf.MoveSingleFeed(feedrate, placePosX, placePosY, ClearHeight, ClearHeight, 0, 0);
                        }
                        SetResultsLabelText("ComponentHeight: " + CalcAZPlaceHeight(componentHeight).ToString());
                        kf.MoveSingleFeed(feedrate, placePosX, placePosY, CalcAZPlaceHeight(componentHeight), ClearHeight, 0, newrotation);
                        Thread.Sleep(100);
                        ChangeVacOutput(1, false);
                        Thread.Sleep(200);
                        kf.MoveSingleFeed(feedrate, placePosX, placePosY, ClearHeight, ClearHeight, 0, newrotation);
                       
                    }
                    else
                    {
                        // use picker 2  CalcXwithNeedleSpacing
                        if (DefaultRotation != ComponentRotation)
                        {

                            newrotation = DefaultRotation + ComponentRotation;
                            if (ComponentRotation == 0)
                            {
                                newrotation = DefaultRotation;

                            }
                            kf.MoveSingleFeed(feedrate, CalcXwithNeedleSpacing(placePosX), placePosY, ClearHeight, ClearHeight, newrotation, 0);

                            kf.MoveSingleFeed(feedrate, CalcXwithNeedleSpacing(placePosX), placePosY, ClearHeight, CalcAZPlaceHeight(componentHeight), newrotation, 0);
                            // go down and turn off suction
                            ChangeVacOutput(2, false);
                            Thread.Sleep(200);
                            kf.MoveSingleFeed(feedrate, CalcXwithNeedleSpacing(placePosX), placePosY, ClearHeight, ClearHeight, newrotation, 0);
                        }
                        else
                        {
                            kf.MoveSingleFeed(feedrate, CalcXwithNeedleSpacing(placePosX), placePosY, ClearHeight, ClearHeight, 0, 0);
                            kf.MoveSingleFeed(feedrate, CalcXwithNeedleSpacing(placePosX), placePosY, ClearHeight, CalcAZPlaceHeight(componentHeight), 0, 0);
                            ChangeVacOutput(2, false);
                            Thread.Sleep(200);
                            kf.MoveSingleFeed(feedrate, CalcXwithNeedleSpacing(placePosX), placePosY, ClearHeight, ClearHeight, 0, 0);
                        }

                      
                    }







                    currentrow++;
                    progresspert = currentrow * progresspertcalc;
                    worker.ReportProgress(Int32.Parse(progresspert.ToString()));
                }
                rundata.Dispose();
                

            }
            else
            {
                MessageBox.Show("Board file not loaded");
            }
            backgroundWorkerDoCommand.CancelAsync();
           
            worker.ReportProgress(100);
            // home all axis and zero
            SetResultsLabelText("Home and Reset");
            //kf.HomeAll();

            //Thread thrd = new Thread(new ThreadStart(DoHomeAll));
            //thrd.Start();
           // thrd.IsBackground = true;
        }
       
        
        public void ChangeVacOutput(int vac, bool turnon)
        {
           
            if (vac == 1)
            {
                if (turnon)
                {
                    usbController.setVAC1(true);
                    Thread.Sleep(100);
                }
                else
                {
                    usbController.setVAC1(false);
                }

            }
            else
            {
                if (turnon)
                {
                    usbController.setVAC2(true);
                    Thread.Sleep(200);
                }
                else
                {
                    usbController.setVAC2(false);
                    Thread.Sleep(100);
                }
            }
            // Thread.Sleep(50);


        }
        public void SetFeederOutputs(int feedercommand)
        {
            usbController.setGotoFeeder(Byte.Parse(feedercommand.ToString()));

            // check if on main feeder rack
            if (feedercommand == 98)
            {
                // command set, now toggle interupt pin
                usbController.setResetFeeder();
            }

            if (feedercommand > 20 && feedercommand < 30)
            {
                chipfeederms = Int32.Parse(ribbonTextBoxChipMS.TextBoxText);
                if (backgroundWorkerChipFeeder.IsBusy != true)
                {
                    backgroundWorkerChipFeeder.RunWorkerAsync();
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // update the DRO screen with current position
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (backgroundWorkerUpdateDRO.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorkerUpdateDRO.RunWorkerAsync();
            }
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // LoadCamera(pictureBox1, "Video Camera", 4, cam, true);
            // LoadCamera(pictureBox2, "USB Camera", 4, cam2, false);
        }

        private void buttonStopGCode_Click(object sender, EventArgs e)
        {
            backgroundWorkerDoCommand.CancelAsync();
        }

        private void buttonChipFeederGo_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value = 0;
           // currentfeeder = Int32.Parse(comboBoxManualReelFeeder.SelectedValue.ToString());
            if (backgroundWorkerGetFeeder.IsBusy != true)
            {
                backgroundWorkerGetFeeder.RunWorkerAsync();
            }
        }

        private void buttonChipFeeder_Click(object sender, EventArgs e)
        {
            chipfeederms = Int32.Parse(ribbonTextBoxChipMS.TextBoxText);
            if (backgroundWorkerChipFeeder.IsBusy != true)
            {
                backgroundWorkerChipFeeder.RunWorkerAsync();
            }
        }

        private void backgroundWorkerChipFeeder_DoWork(object sender, DoWorkEventArgs e)
        {
            usbController.setVibrationMotorSpeed(250);
            usbController.setVibrationMotor(true);
            int i = 0;
            while (i < chipfeederms)
            {
                Thread.Sleep(10);
                i = i + 10;
            }
            
            usbController.setVibrationMotor(false);
            usbController.setVibrationMotorSpeed(250);
        }

       


        private void ribbonButtonSmallOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML files|*.xml";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                   // string imagefile = file.Replace(".xml", ".jpg");
                  //  if (System.IO.File.Exists(imagefile))
                  //  {
                  //      pictureBoxPCB.Image = new Bitmap(imagefile);
                        
                  //  }
                    try
                    {
                        dsMain.Clear();
                    }
                    catch { }
                    


                    dsMain = csvload.LoadPCB(file, dataGridView1);

                    // data loaded, now set board defaults
                    ribbonTextBoxBoardOffsetX.TextBoxText = dsMain.Tables["Settings"].Rows[0]["BoardOffsetX"].ToString(); //double

                    ribbonTextBoxBoardOffsetY.TextBoxText = dsMain.Tables["Settings"].Rows[0]["BoardOffsetY"].ToString(); //double

                    ribbonTextBoxPCBThickness.TextBoxText = dsMain.Tables["Settings"].Rows[0]["PCBThickness"].ToString(); //double //double dblPCBThickness

                    ribbonTextBoxFeedRate.TextBoxText = dsMain.Tables["Settings"].Rows[0]["FeedRate"].ToString();  //int FeedRate

                    ribbonTextBoxChipMS.TextBoxText = dsMain.Tables["Settings"].Rows[0]["chipfeederms"].ToString();  //int chipfeederms

                    dblPCBThickness = Double.Parse(dsMain.Tables["Settings"].Rows[0]["PCBThickness"].ToString());
                    FeedRate = Int32.Parse(dsMain.Tables["Settings"].Rows[0]["FeedRate"].ToString());
                    chipfeederms = Int32.Parse(dsMain.Tables["Settings"].Rows[0]["chipfeederms"].ToString());

                    DrawComponents();

                 }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
        }

        private void DrawComponents()
        {
            if (pictureBoxPCB.Image == null)
            {
                    pictureBoxPCB.Image = new Bitmap(pictureBoxPCB.Width, 
                            pictureBoxPCB.Height);
            }
            else
            {

                pictureBoxPCB.InitialImage = null;
                pictureBoxPCB.Image = new Bitmap(pictureBoxPCB.Width,
                            pictureBoxPCB.Height);
            }
            using (Graphics g = Graphics.FromImage(pictureBoxPCB.Image))
            {
                // draw black background
                g.Clear(Color.White);

                DataTable dt = dsMain.Tables["Component"];

                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        int newx = Convert.ToInt32(Double.Parse(row["PosX"].ToString()) * 2.5);
                        int newy = Convert.ToInt32(Double.Parse(row["PosY"].ToString()) * 2.5);
                        //MessageBox.Show(newx.ToString() + " - " + newy.ToString());

                        switch (row["RefDes"].ToString().Substring(0, 1).ToLower())
                        {
                            case "r":
                                Rectangle rectres = new Rectangle(newx, newy, 2, 2);
                                g.DrawRectangle(Pens.Black, rectres);
                                break;
                            case "c":
                                Rectangle rectcap = new Rectangle(newx, newy, 2, 2);
                                g.DrawRectangle(Pens.Orange, rectcap);
                                break;
                            case "U":
                                Rectangle rectic = new Rectangle(newx, newy, 2, 2);
                                g.DrawRectangle(Pens.Gray, rectic);
                                break;
                            default:
                                Rectangle rect = new Rectangle(newx, newy, 2, 2);
                                g.DrawRectangle(Pens.Red, rect);
                                break;
                        }
                        
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                    
                }



                
                
            }
            pictureBoxPCB.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            pictureBoxPCB.Invalidate();

        }
     
        private void ribbonButtonStart_Click(object sender, EventArgs e)
        {
            kf.setAlltoZero();
             SaveSettings();
            FeedRate = Int32.Parse(ribbonTextBoxFeedRate.TextBoxText);


            DataView rundata = new DataView();
            rundata = dtom3.ConvertToGCode(dataGridView1, Double.Parse(ribbonTextBoxBoardOffsetX.TextBoxText), Double.Parse(ribbonTextBoxBoardOffsetY.TextBoxText));

            if (backgroundWorkerDoCommand.IsBusy != true)
            {
                backgroundWorkerDoCommand.RunWorkerAsync();
            }
        }

        private void ribbonButtonEStop_Click_1(object sender, EventArgs e)
        {
            backgroundWorkerDoCommand.CancelAsync();
            Thread thrd = new Thread(new ThreadStart(DoEStop));
            thrd.Start();
            thrd.IsBackground = true;
            kf.initdevicesettings();
           
        }
        private void DoEStop()
        {
            kf.EStop();
        
        }


        private void buttonHomeAll_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(new ThreadStart(DoHomeAll));
            thrd.Start();
            thrd.IsBackground = true;
        }


        private void DoHomeAll()
        {
            SetFeederOutputs(98);
            kf.HomeAll();
           
            
            
        }

        
        private void ribbonButtonCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Pick"].Value = true;
            }
        }

        private void ribbonButtonUnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Pick"].Value = false;
            }
        }

        private void ribbonButtonChipFeederShake_Click(object sender, EventArgs e)
        {
            chipfeederms = Int32.Parse(ribbonTextBoxChipMS.TextBoxText);
            if (backgroundWorkerChipFeeder.IsBusy != true)
            {
                backgroundWorkerChipFeeder.RunWorkerAsync();
            }
        }

        private void ribbonCheckBoxLEDPicker_CheckBoxCheckChanged(object sender, EventArgs e)
        {
           
            if (ribbonCheckBoxLEDPicker.Checked)
            {
                usbController.setHeadCameraLED(true);
            }
            else
            {
                usbController.setHeadCameraLED(false);
            }
        }

        private void ribbonCheckBoxLEDCamera_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (ribbonCheckBoxLEDCamera.Checked)
            {
                usbController.setBaseCameraLED(true);
            } else {
                usbController.setBaseCameraLED(false);
            }
        }

        private void ribbonButtonComponentEditorOpen_Click(object sender, EventArgs e)
        {
            ComponentEditor cm = new ComponentEditor();
            cm.Show(this);
        }

        private void ribbonButtonBaseCameraOpen_Click(object sender, EventArgs e)
        {
            CameraVision camvis = new CameraVision();
            camvis.Show(this);
        }

        private void ribbonButtonVisionPickerCamera_Click(object sender, EventArgs e)
        {
            CameraHead camhead = new CameraHead();
            camhead.Show(this);
        }

        private void ribbonButtonDROStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void ribbonButtonDROStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void ribbonButtonManualJOGLeft_Click(object sender, EventArgs e)
        {
            kf.JogAxis("Y", false);
        }
        private void ribbonButtonManualJOGRight_Click(object sender, EventArgs e)
        {
            kf.JogAxis("Y", true);
        }
        
        private void ribbonButtonManualJOGUp_Click(object sender, EventArgs e)
        {
            kf.JogAxis("X", true);
           
        }
        private void ribbonButtonManualJOGDown_Click(object sender, EventArgs e)
        {
            kf.JogAxis("X", false);
        }
        
        private void LoadSettings() {

         ribbonTextBoxBoardOffsetX.TextBoxText = Properties.Settings.Default.Properties["SettingBoardOffsetX"].DefaultValue.ToString(); // double

         ribbonTextBoxBoardOffsetY.TextBoxText  = Properties.Settings.Default.Properties["SettingBoardOffsetY"].DefaultValue.ToString(); //double

         ribbonTextBoxPCBThickness.TextBoxText  = Properties.Settings.Default.Properties["SettingPCBThickness"].DefaultValue.ToString(); //double //double dblPCBThickness

         ribbonTextBoxFeedRate.TextBoxText = Properties.Settings.Default.Properties["SettingFeedRate"].DefaultValue.ToString();  //int FeedRate

         ribbonTextBoxChipMS.TextBoxText = Properties.Settings.Default.Properties["SettingTimeMS"].DefaultValue.ToString();  //int chipfeederms

         ribbonTextBoxHeadLedBrightness.TextBoxText = Properties.Settings.Default.Properties["HeadLedBrightness"].DefaultValue.ToString();  //byte chipfeederms
         ribbonTextBoxBaseLedBrightness.TextBoxText = Properties.Settings.Default.Properties["BaseLedBrightness"].DefaultValue.ToString();  //byte chipfeederms
         ribbonTextBoxMotorPWM.TextBoxText = Properties.Settings.Default.Properties["MotorPWM"].DefaultValue.ToString();  //byte chipfeederms




         dblPCBThickness = Double.Parse(Properties.Settings.Default.Properties["SettingPCBThickness"].DefaultValue.ToString());
         FeedRate = Int32.Parse(Properties.Settings.Default.Properties["SettingFeedRate"].DefaultValue.ToString());
         chipfeederms = Int32.Parse(Properties.Settings.Default.Properties["SettingTimeMS"].DefaultValue.ToString());
        
     }
     private void SaveSettings()
     {
         Properties.Settings.Default.SettingBoardOffsetX = Double.Parse(ribbonTextBoxBoardOffsetX.TextBoxText);
         Properties.Settings.Default.SettingBoardOffsetY = Double.Parse(ribbonTextBoxBoardOffsetY.TextBoxText);
         Properties.Settings.Default.SettingPCBThickness = Double.Parse(ribbonTextBoxPCBThickness.TextBoxText);

         Properties.Settings.Default.SettingFeedRate = Int32.Parse(ribbonTextBoxFeedRate.TextBoxText);
         Properties.Settings.Default.SettingTimeMS = Int32.Parse(ribbonTextBoxChipMS.TextBoxText);

         Properties.Settings.Default.HeadLedBrightness = byte.Parse(ribbonTextBoxHeadLedBrightness.TextBoxText);
         Properties.Settings.Default.BaseLedBrightness = byte.Parse(ribbonTextBoxBaseLedBrightness.TextBoxText);
         Properties.Settings.Default.MotorPWM = byte.Parse(ribbonTextBoxMotorPWM.TextBoxText);


         // Save settings
         Properties.Settings.Default.Save();
     }

     private void ribbonButtonCSVtoXML_Click(object sender, EventArgs e)
     {
         FormCSVtoXML csvcml = new FormCSVtoXML();
         csvcml.Show(this);

        
     }

     private void ribbonButtonBoardMultiplier_Click(object sender, EventArgs e)
     {
         FormBoardMultiplier boardmult = new FormBoardMultiplier();
         boardmult.Show(this);
     }

     private void ribbonButtonManualControlPicker1Left_Click(object sender, EventArgs e)
     {
         kf.JogAxis("B", false);
     }

     private void ribbonButtonManualControlPicker1Right_Click(object sender, EventArgs e)
     {
         kf.JogAxis("B", true);
     }

     private void ribbonButtonManualControlPicker1Up_Click(object sender, EventArgs e)
     {
         kf.JogAxis("A", false);
     }

     private void ribbonButtonManualControlPicker1Down_Click(object sender, EventArgs e)
     {
         kf.JogAxis("A", true);
     }

     private void ribbonButtonManualControlPicker2Left_Click(object sender, EventArgs e)
     {
         kf.JogAxis("C", false);
     }

     private void ribbonButtonManualControlPicker2Right_Click(object sender, EventArgs e)
     {
         kf.JogAxis("C", true);
     }

     private void ribbonButtonManualControlPicker2Up_Click(object sender, EventArgs e)
     {
         kf.JogAxis("Z", false);
     }

     private void ribbonButtonManualControlPicker2Down_Click(object sender, EventArgs e)
     {
         kf.JogAxis("Z", true);
     }

     private void ribbonButton7_Click(object sender, EventArgs e)
     {
         ManualPicker mp = new ManualPicker();
         mp.Show();
     }


        // remote control for http remote access

     public void stopRemote()
     {
         if (listener.IsListening)
         {
             listener.Stop();
         }
     }

     protected string GetIP()   //get IP address
     {
        // IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
         //IPAddress ipAddr = ipHost.AddressList[0];
         //return ipAddr.ToString();

         string strHostName = System.Net.Dns.GetHostName();

         IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

         foreach (IPAddress ipAddress in ipEntry.AddressList)
         {
             if (ipAddress.AddressFamily.ToString() == "InterNetwork")
             {
                 return ipAddress.ToString();
             }
         }

         return "-";

     }


     public void initRemote()
     {

         SetRemoteIPText(GetIP() + ":8080");
         listeningURL = "http://" + GetIP() + ":8080/";
         listener.Prefixes.Add(listeningURL);
         listener.Start();

         while (listener.IsListening)
         {
             HttpListenerContext context = listener.GetContext();
             try
             {
                 Thread t = new Thread(() =>
                 {
                     var request = context.Request;
                     switch (request.QueryString["command"].ToString())
                     {
                         case "start":
                            SaveSettings();
	                        FeedRate = Int32.Parse(ribbonTextBoxFeedRate.TextBoxText);
	                        DataView rundata = new DataView();
	                        rundata = dtom3.ConvertToGCode(dataGridView1, Double.Parse(ribbonTextBoxBoardOffsetX.TextBoxText), Double.Parse(ribbonTextBoxBoardOffsetY.TextBoxText));
	    
	                            if (backgroundWorkerDoCommand.IsBusy != true)
	                            {
	                                backgroundWorkerDoCommand.RunWorkerAsync();
                                }
                             break;
                         case "stop":
                             backgroundWorkerDoCommand.CancelAsync();
                             break;
                         
                         case "homeall":
                             Thread thrd2 = new Thread(new ThreadStart(DoHomeAll));
                             thrd2.Start();
                             thrd2.IsBackground = true;
                             break;
                         case "estop":
                             Thread thrdestop = new Thread(new ThreadStart(DoEStop));
                             thrdestop.Start();
                             thrdestop.IsBackground = true;
                             break;
                     }
                    
                     byte[] Buffer = System.Text.Encoding.UTF8.GetBytes("OK" + Environment.NewLine);
                     context.Response.ContentType = "text/html; charset=utf-8";
                     context.Response.OutputStream.Write(Buffer, 0, Buffer.Length);
                     context.Response.Close();
                     //writing the sent message into the console
                    
                    
                 });
                 t.Start();
             }
             catch (Exception e)
             {
                 Debug.WriteLine(e.Message);
             }


         }

     }

     private void ribbonButtonInit_Click(object sender, EventArgs e)
     {
         RunBoardInit();
     }

     private void ribbonCheckBoxVACPicker1_CheckBoxCheckChanged(object sender, EventArgs e)
     {
         if (ribbonCheckBoxVACPicker1.Checked)
         {
             usbController.setVAC1(true);
         }
         else
         {
             usbController.setVAC1(false);
         }
     }

     private void ribbonCheckBoxVACPicker2_CheckBoxCheckChanged(object sender, EventArgs e)
     {
         if (ribbonCheckBoxVACPicker2.Checked)
         {
             usbController.setVAC2(true);
         }
         else
         {
             usbController.setVAC2(false);
         }
     }

     private void JogStop(object sender, MouseEventArgs e)
     {
         kf.JogAxisStop();
     }

     private void ribbonButtonCameraComponentVision_Click(object sender, EventArgs e)
     {
         
         ComponentVision cmv = new ComponentVision();
         cmv.Show(this);
     }

    
    }

    


}