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
    public partial class CameraVision : Form
    {
        private Capture capture;

        public bool CameraIsRunning = false;


        public CameraVision()
        {
            InitializeComponent();
        }
        // vision 
        private Byte[] buffer = new Byte[1];

        private void ReleaseData()
        {
            if (capture != null)
                capture.Dispose();
        }

        private void CameraVision_Load(object sender, EventArgs e)
        {
            capture = new Capture(0);
            // capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_AUTO_EXPOSURE, 1);

            // capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_BRIGHTNESS, 33);
            // capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_CONTRAST, 54);
            //  capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_EXPOSURE, -7);
            
        }

        private void buttonStartupCamera_Click(object sender, EventArgs e)
        {
            if (CameraIsRunning)
            {
                buttonStartupCamera.Text = "Start";
                timer1.Stop();
                CameraIsRunning = false;
            }
            else
            {
                buttonStartupCamera.Text = "Stop";
                timer1.Start();
                CameraIsRunning = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            Image<Bgr, Byte> frame = capture.QueryFrame();
            // Image<Bgr, Byte> frame = new Image<Bgr, Byte>("Captureclose.jpg");

            if (frame != null)
            {
                pictureBox1.Image = frame.ToBitmap();
                Image<Gray, Byte> gray = frame.Convert<Gray, Byte>();
               
                //convert the image to hsv
                Image<Hsv, Byte> hsvimg = frame.Convert<Hsv, Byte>();
                //extract the hue and value channels
                Image<Gray, Byte>[] channels = hsvimg.Split();  //split into components
                Image<Gray, Byte> imghue = channels[0];            //hsv, so channels[0] is hue.
                Image<Gray, Byte> imgval = channels[2];            //hsv, so channels[2] is value.

                //filter out all but "the color you want"...seems to be 0 to 128 ?
                Image<Gray, byte> huefilter = imghue.InRange(new Gray(0), new Gray(128));

                //use the value channel to filter out all but brighter colors
                Image<Gray, byte> valfilter = imgval.InRange(new Gray(120), new Gray(255));

                //now and the two to get the parts of the imaged that are colored and above some brightness.
                Image<Gray, byte> colordetimg = huefilter.And(valfilter);
                pictureBox1.Image = colordetimg.ToBitmap();
                
             double cannyThreshold = 150.0;
            double circleAccumulatorThreshold = 120;
           
          
           
            double cannyThresholdLinking = 1.0;
            Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
            LineSegment2D[] lines = cannyEdges.HoughLinesBinary(
                1, //Distance resolution in pixel-related units
                Math.PI / 90.0, //Angle resolution measured in radians.
                20, //threshold
                2, //min Line width
                2 //gap between lines
                )[0]; //Get the lines from the first channel
        

           
           
            List<Triangle2DF> triangleList = new List<Triangle2DF>();
            List<MCvBox2D> boxList = new List<MCvBox2D>(); //a box is a rotated rectangle
            using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
               for (
                  Contour<Point> contours = cannyEdges.FindContours(
                     Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                     Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST,
                     storage);
                  contours != null;
                  contours = contours.HNext)
               {
                  Contour<Point> currentContour = contours.ApproxPoly(0.005, storage);

                  if (currentContour.Area > 250 ) //only consider contours with area greater than 250
                  {
                      if (currentContour.Total == 4) //The contour has 4 vertices.
                     {
                       
                        bool isRectangle = true;
                        Point[] pts = currentContour.ToArray();
                        LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                        for (int i = 0; i < edges.Length; i++)
                        {
                           double angle = Math.Abs(
                              edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                           if (angle < 80 || angle > 100)
                           {
                              isRectangle = false;
                              break;
                           }

                           
                        }


                        
                       
                        if (isRectangle) boxList.Add(currentContour.GetMinAreaRect());
                     }
                  }
               }
           
         

            pictureBox1.Image = frame.ToBitmap();
           // this.Text = msgBuilder.ToString();

            #region draw triangles and rectangles
            Image<Bgr, Byte> triangleRectangleImage = frame.CopyBlank();
            foreach (Triangle2DF triangle in triangleList)
               triangleRectangleImage.Draw(triangle, new Bgr(Color.DarkBlue), 2);
            foreach (MCvBox2D box in boxList)
            {
               textBoxDeg.Text = box.angle.ToString();
                textBoxImageX.Text = box.center.X.ToString();
                textBoxImageY.Text = box.center.Y.ToString();
                triangleRectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);
            }
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
            triangleRectangleImage.DrawPolyline(Array.ConvertAll<PointF, Point>(linepointshor, Point.Round), false, new Bgr(Color.AntiqueWhite), 1);
            triangleRectangleImage.DrawPolyline(Array.ConvertAll<PointF, Point>(linepointsver, Point.Round), false, new Bgr(Color.AntiqueWhite), 1);
             pictureBox2.Image = triangleRectangleImage.ToBitmap();
            #endregion
            //pictureBox3.Image = gray.ToBitmap();
          
/*
            #region draw lines
            Image<Bgr, Byte> lineImage = frame.CopyBlank();
            foreach (LineSegment2D line in lines)
               lineImage.Draw(line, new Bgr(Color.Green), 2);


            pictureBox2.Image = lineImage.ToBitmap();
            #endregion
              */
            }


            //   pictureBox2.Image = gray.ToBitmap();






        }

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
         //   capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_BRIGHTNESS, trackBarBrightness.Value);
          //  labelBrightness.Text = trackBarBrightness.Value.ToString();
        }

        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {

          //  capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_CONTRAST, trackBarContrast.Value);
          //  labelContrast.Text = trackBarContrast.Value.ToString();
        }
        private void trackBarExposure_Scroll(object sender, EventArgs e)
        {
            //   capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_AUTO_EXPOSURE, 0);
           // capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_EXPOSURE, trackBarExposure.Value);
           // labelExposure.Text = trackBarExposure.Value.ToString();
        }
    }
}
