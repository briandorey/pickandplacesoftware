using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// vision system
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;


namespace PNPControllerKFlop
{
   public class VideoProcessing
    {
       // work in progress
        // camera init
        private Emgu.CV.Capture capture;

        public bool CameraHasData = false;
       Form1 frm = new Form1();

       public void StartCamera() {
            capture = new Emgu.CV.Capture();
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_AUTO_EXPOSURE, 0);

            capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_BRIGHTNESS, 33);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_CONTRAST, 54);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_EXPOSURE, -7);
       }
        public bool GetVideoData(System.Windows.Forms.PictureBox picturebox1, System.Windows.Forms.PictureBox picturebox2)
        {
            CameraHasData = false;
            frm.SetText(frm.Controls["textBoxImageY"], "0");
            frm.SetText(frm.Controls["textBoxDeg"], "0");
            frm.SetText(frm.Controls["textBoxImageX"], "0");
           
            capture.Start();
            int cappturecounter = 1;
            while (!CameraHasData || cappturecounter <= 20)
            {
                GetCameraXY(picturebox1, picturebox2);
                cappturecounter++;
            }
            capture.Stop();
            return true;
        }

       private void GetCameraXY(System.Windows.Forms.PictureBox picturebox1, System.Windows.Forms.PictureBox picturebox2) {


            Image<Bgr, Byte> frame = capture.QueryFrame();
            //Image<Bgr, Byte> frame = new Image<Bgr, Byte>("Capture.jpg");

            if (frame != null)
            {
                Image<Gray, Byte> gray = frame.Convert<Gray, Byte>();

                double cannyThreshold = 180.0;
                double cannyThresholdLinking = 120.0;
                Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);


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
                        Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

                        if (currentContour.Area > 400 && currentContour.Area < 20000) //only consider contours with area greater than 250
                        {
                            if (currentContour.Total == 4) //The contour has 4 vertices.
                            {
                                // determine if all the angles in the contour are within [80, 100] degree
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
                Image<Bgr, Byte> triangleRectangleImage = frame.CopyBlank();
                foreach (Triangle2DF triangle in triangleList)
                    triangleRectangleImage.Draw(triangle, new Bgr(Color.DarkBlue), 2);
                foreach (MCvBox2D box in boxList)
                {
                    frm.SetText(frm.Controls["textBoxImageY"], box.center.Y.ToString());
                    frm.SetText(frm.Controls["textBoxDeg"], box.angle.ToString());
                    frm.SetText(frm.Controls["textBoxImageX"], box.center.X.ToString());
                    CameraHasData = true;

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
                picturebox2.Image = triangleRectangleImage.ToBitmap();


                frame.DrawPolyline(Array.ConvertAll<PointF, Point>(linepointshor, Point.Round), false, new Bgr(Color.AntiqueWhite), 1);
                frame.DrawPolyline(Array.ConvertAll<PointF, Point>(linepointsver, Point.Round), false, new Bgr(Color.AntiqueWhite), 1);
                picturebox1.Image = frame.ToBitmap();


            }
         
         }
    }
}
