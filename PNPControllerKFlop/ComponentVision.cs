using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;

namespace PNPControllerKFlop
{
    public partial class ComponentVision : Form
    {
        private Capture capture;
        private kflop kf = new kflop();
        // vision 
        private Byte[] buffer = new Byte[1];
        delegate void SetTextCallback(string text);


        private void ReleaseData()
        {
            if (capture != null)
                capture.Dispose();
        }


        public ComponentVision()
        {
            InitializeComponent();

            backgroundWorkerUpdateDRO.DoWork +=
                new DoWorkEventHandler(backgroundWorkerUpdateDRO_DoWork_1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Image<Bgr, Byte> frame = capture.QueryFrame();


            if (frame != null)
            {

                // add cross hairs to image
                int totalwidth = frame.Width;
                int totalheight = frame.Height;
                PointF[] linepointshor = new PointF[] { 
                    new PointF(0, totalheight/2),
                    new PointF(totalwidth, totalheight/2)
                  
                };
                PointF[] linepointsver = new PointF[] { 
                    new PointF(totalwidth/2, 0),
                    new PointF(totalwidth/2, totalheight)
                  
                };
                frame.DrawPolyline(Array.ConvertAll<PointF, Point>(linepointshor, Point.Round), false, new Bgr(Color.AntiqueWhite), 1);
                frame.DrawPolyline(Array.ConvertAll<PointF, Point>(linepointsver, Point.Round), false, new Bgr(Color.AntiqueWhite), 1);



                pictureBox1.Image = frame.ToBitmap();
            }
        }

        private void ComponentVision_Load(object sender, EventArgs e)
        {
            //capture = new Capture(0);
           // timer1.Start();
           // timer2.Start();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBoxDROX.Text = "Radion 1";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBoxDROX.Text = "Radion 2";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                textBoxDROX.Text = "Radion 3";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                textBoxDROX.Text = "Radion 4";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                textBoxDROX.Text = "Radion 5";
            }
        }

        private void buttonXPlus_Click(object sender, EventArgs e)
        {
            kf.JogAxis("X", true);
        }
        private void buttonXMinus_Click(object sender, EventArgs e)
        {
            kf.JogAxis("X", false);
        }
        private void buttonYMinus_Click(object sender, EventArgs e)
        {
            kf.JogAxis("Y", false);
        }

        private void buttonYPlus_Click(object sender, EventArgs e)
        {
            kf.JogAxis("Y", true);
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            kf.JogAxisStop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // update dro
            if (backgroundWorkerUpdateDRO.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorkerUpdateDRO.RunWorkerAsync();
            }

        }

        private void SetTextX(string text)
        {
            if (this.textBoxDROX.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextX);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBoxDROX.Text = text;
            }
        }
        private void SetTextY(string text)
        {
            if (this.textBoxDROY.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextY);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBoxDROY.Text = text;
            }
        }

        private void backgroundWorkerUpdateDRO_DoWork_1(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;


            if (backgroundWorkerUpdateDRO.CancellationPending)
            {
                e.Cancel = true;
            }
            //SetTextX(kf.GetDROX().ToString());
            //SetTextY(kf.GetDROY().ToString());
          
        }
    }
}
