using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PNPControllerKFlop
{
    public partial class CameraHead : Form
    {
        private Capture capture;

        // vision 
        private Byte[] buffer = new Byte[1];

        private void ReleaseData()
        {
            if (capture != null)
                capture.Dispose();
        }


        public CameraHead()
        {
            InitializeComponent();
        }

        private void CameraHead_Load(object sender, EventArgs e)
        {
            capture = new Capture(0);
            timer1.Start();
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
    }
}
