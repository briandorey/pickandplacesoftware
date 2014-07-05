using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMotion_dotNet;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace PNPControllerKFlop
{
    public class kflop
    {
        KM_Controller _Controller; //Object to interface with the Kflop
        KM_Axis _XAxis;
        KM_Axis _YAxis;
        KM_Axis _ZAxis;
        KM_Axis _AAxis;
        KM_Axis _BAxis;
        KM_Axis _CAxis;
        KM_CoordMotion _Motion;

        private double JogSpeed = 2000;

        private double currentX = 0.0;
        private double currentY = 0.0;
        private double currentZ = 0.0;
        private double currentA = 0.0;
        private double currentB = 0.0;
        private double currentC = 0.0;

        public bool eStopActive = false;

        public void initdevicesettings() {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);

            String TheCFile = path + @"\InitPickandPlace.c";

            //************NEW program execution model***********
            String result = _Controller.ExecuteProgram(1, TheCFile, false);
            if (result != "") MessageBox.Show(result);

            _XAxis.Enable();
            _XAxis.CPU = 1000;

            _YAxis.Enable();
            _YAxis.CPU = 1000;


            _ZAxis.Enable();
            _ZAxis.CPU = 1000;

            _AAxis.Enable();
            _AAxis.CPU = 1000;

            _BAxis.Enable();
            _BAxis.CPU = 1000;

            _CAxis.Enable();
            _CAxis.CPU = 1000;

            // setup homing params

            _ZAxis.HomingParams.SourceType = HOMING_ROUTINE_SOURCE_TYPE.AUTO;

            _ZAxis.HomingParams.DefaultThread = 5;
            _ZAxis.HomingParams.HomeFastVel = 300;
            _ZAxis.HomingParams.HomeSlowVel = 70;
            _ZAxis.HomingParams.HomeLimitBit = 21;
            _ZAxis.HomingParams.HomeLimitState = true;
            _ZAxis.HomingParams.RepeatHomeAtSlowerRate = true;
            _ZAxis.HomingParams.SequencePriority = 1;
            _ZAxis.HomingParams.HomeNegative = true;
            _ZAxis.HomingParams.StatusBit = 21;
            _ZAxis.HomingParams.SetToZero = true;


            _AAxis.HomingParams.SourceType = HOMING_ROUTINE_SOURCE_TYPE.AUTO;

            _AAxis.HomingParams.DefaultThread = 2;
            _AAxis.HomingParams.HomeFastVel = 300;
            _AAxis.HomingParams.HomeSlowVel = 70;
            _AAxis.HomingParams.HomeLimitBit = 23;
            _AAxis.HomingParams.HomeLimitState = true;
            _AAxis.HomingParams.RepeatHomeAtSlowerRate = true;
            _AAxis.HomingParams.SequencePriority = 2;
            _AAxis.HomingParams.HomeNegative = true;
            _AAxis.HomingParams.StatusBit = 23;
            _AAxis.HomingParams.SetToZero = true;


            _XAxis.HomingParams.SourceType = HOMING_ROUTINE_SOURCE_TYPE.AUTO;
            _XAxis.HomingParams.DefaultThread = 3;
            _XAxis.HomingParams.HomeFastVel = 300;
            _XAxis.HomingParams.HomeSlowVel = 70;
            _XAxis.HomingParams.HomeLimitBit = 19;
            _XAxis.HomingParams.HomeLimitState = true;
            _XAxis.HomingParams.RepeatHomeAtSlowerRate = true;
            _XAxis.HomingParams.SequencePriority = 3;
            _XAxis.HomingParams.HomeNegative = true;
            _XAxis.HomingParams.StatusBit = 19;
            _XAxis.HomingParams.SetToZero = true;

            _YAxis.HomingParams.SourceType = HOMING_ROUTINE_SOURCE_TYPE.AUTO;
            _YAxis.HomingParams.DefaultThread = 4;
            _YAxis.HomingParams.HomeFastVel = 800;
            _YAxis.HomingParams.HomeSlowVel = 70;
            _YAxis.HomingParams.HomeLimitBit = 25;
            _YAxis.HomingParams.HomeLimitState = true;
            _YAxis.HomingParams.RepeatHomeAtSlowerRate = true;
            _YAxis.HomingParams.SequencePriority = 4;
            _YAxis.HomingParams.HomeNegative = true;
            _YAxis.HomingParams.StatusBit = 25;
            _YAxis.HomingParams.SetToZero = true;



            // setup motion params
            _Controller.CoordMotion.Abort();
            _Controller.CoordMotion.ClearAbort();
            _Controller.CoordMotion.MotionParams.CountsPerInchX = 171.405629;
            _Controller.CoordMotion.MotionParams.CountsPerInchY = 416.3108547;
            _Controller.CoordMotion.MotionParams.CountsPerInchZ = 342.245989;
            _Controller.CoordMotion.MotionParams.CountsPerInchA = 342.245989;
            _Controller.CoordMotion.MotionParams.CountsPerInchB = 8.88888;
            _Controller.CoordMotion.MotionParams.CountsPerInchC = 8.88888;

            _Controller.CoordMotion.MotionParams.MaxAccelZ = 2e+006; ;
            // _Controller.CoordMotion.MotionParams.MaxAccelZ = 400000;
            _Controller.CoordMotion.MotionParams.MaxVelZ = 20000;
            // _ZAxis.TuningParams.Jerk = 5e+006;

            /*
             _Controller.WriteLine(String.Format("DefineCS = {0} {1} {2} {3} {4} {5}", 0, 1, 2, -1, -1, -1));
             _Controller.WriteLine(String.Format("EnableAxis{0}", 0));
             _Controller.WriteLine(String.Format("EnableAxis{0}", 1));
             _Controller.WriteLine(String.Format("EnableAxis{0}", 2));
             _Controller.WriteLine(String.Format("EnableAxis{0}", 3));
             _Controller.WriteLine(String.Format("EnableAxis{0}", 4));
             _Controller.WriteLine(String.Format("EnableAxis{0}", 5));
           
             _Controller.CoordMotion.MotionParams.BreakAngle = 30;
             _Controller.CoordMotion.MotionParams.RadiusA = 5;
             _Controller.CoordMotion.MotionParams.RadiusB = 5;
             _Controller.CoordMotion.MotionParams.RadiusC = 5;
             _Controller.CoordMotion.MotionParams.MaxAccelX = 400000;
             _Controller.CoordMotion.MotionParams.MaxAccelY = 400000;
             
             _Controller.CoordMotion.MotionParams.MaxAccelA = 400000;
             _Controller.CoordMotion.MotionParams.MaxAccelB = 400000;
             _Controller.CoordMotion.MotionParams.MaxAccelC = 400000;

             _XAxis.TuningParams.Jerk = 4e+006;
             _YAxis.TuningParams.Jerk = 4e+006;
             _ZAxis.TuningParams.Jerk = 4e+006;
             _AAxis.TuningParams.Jerk = 4e+006;
             _BAxis.TuningParams.Jerk = 4e+006;
             _CAxis.TuningParams.Jerk = 4e+006;

             _Controller.CoordMotion.MotionParams.MaxVelX = 4e+007;
             _Controller.CoordMotion.MotionParams.MaxVelY = 4e+007;
             _Controller.CoordMotion.MotionParams.MaxVelA = 4e+007;
             _Controller.CoordMotion.MotionParams.MaxVelB = 4e+007;
             _Controller.CoordMotion.MotionParams.MaxVelC = 4e+007; 
             
             _Controller.CoordMotion.MotionParams.CountsPerInchY = 200;
             _Controller.CoordMotion.MotionParams.CountsPerInchZ = 200;
             _Controller.CoordMotion.MotionParams.CountsPerInchA = 200;
             _Controller.CoordMotion.MotionParams.CountsPerInchB = 200;
             _Controller.CoordMotion.MotionParams.CountsPerInchC = 200;
             _Controller.CoordMotion.MotionParams.DegreesA = false;
             _Controller.CoordMotion.MotionParams.DegreesB = true;
             _Controller.CoordMotion.MotionParams.DegreesC = true;
          */

            setAlltoZero();
        }

        public void initdevice()
        {
            Debug.WriteLine("Init Device");

            _Controller = new KMotion_dotNet.KM_Controller();


            _XAxis = new KMotion_dotNet.KM_Axis(_Controller, 0, "x");
            _YAxis = new KMotion_dotNet.KM_Axis(_Controller, 1, "y");
            _ZAxis = new KMotion_dotNet.KM_Axis(_Controller, 2, "z");
            _AAxis = new KMotion_dotNet.KM_Axis(_Controller, 3, "a");
            _BAxis = new KMotion_dotNet.KM_Axis(_Controller, 4, "b");
            _CAxis = new KMotion_dotNet.KM_Axis(_Controller, 5, "c");
            _Motion = new KMotion_dotNet.KM_CoordMotion(_Controller);

            AddHandlers();

            initdevicesettings();
        }

               
        // public methods

        public void HomeAll()
        {
            Debug.WriteLine("Starting Home");

            setAlltoZero();

            _ZAxis.StartDoHome();
            _AAxis.StartDoHome();
            while (!_ZAxis.MotionComplete() && !_AAxis.MotionComplete())
            _XAxis.StartDoHome();
            _YAxis.StartDoHome();


            setAlltoZero();
         

      // initdevice();

        }

        public void setAlltoZero()
        {
            Debug.WriteLine("Setting All to Zero");
            currentX = 0.0;
            currentY = 0.0;
            currentZ = 0.0;
            currentA = 0.0;
            currentB = 0.0;
            currentC = 0.0;
            _Controller.CoordMotion.Abort();
            _Controller.CoordMotion.ClearAbort();


            double x = 0; double y = 0; double z = 0; double a = 0; double b = 0; double c = 0;
             _Controller.CoordMotion.Interpreter.ReadAndSynchCurInterpreterPosition(ref x, ref y, ref z, ref a, ref b, ref c);

            _XAxis.SetCurrentPosition(0);
            _YAxis.SetCurrentPosition(0);
            _ZAxis.SetCurrentPosition(0);
            _AAxis.SetCurrentPosition(0);
            _BAxis.SetCurrentPosition(0);
            _CAxis.SetCurrentPosition(0);
        }

        public void SetPickerHome()
        {
            _ZAxis.SetCurrentPosition(38.0);
            _AAxis.SetCurrentPosition(38.0);

        }
        public bool MoveXAxis(double newpos)
        {
            _XAxis.MoveTo(newpos);
            while (!_XAxis.MotionComplete())
            {
                Thread.Sleep(10);
            }
            return true;
        }
        public bool MoveYAxis(double newpos)
        {
            _YAxis.MoveTo(newpos);
            while (!_YAxis.MotionComplete())
            {
                Thread.Sleep(10);
            }
            return true;
        }
        public bool MoveZAxis(double newpos)
        {

            //_ZAxis.StartMoveTo(newpos / 2);
            //currentZ = newpos;           
            while (!_ZAxis.MotionComplete())
            {
                Thread.Sleep(10);
            }
           
            return true;
        }
        public bool MoveAAxis(double newpos)
        {
            _AAxis.MoveTo(newpos);
            while (!_AAxis.MotionComplete())
            {
                Thread.Sleep(10);
            }
            return true;
        }
        public bool MoveBAxis(double newpos)
        {
            _BAxis.MoveTo(newpos);
            while (!_BAxis.MotionComplete())
            {
                Thread.Sleep(10);
            }
            return true;
        }
        public bool MoveCAxis(double newpos)
        {
            _CAxis.MoveTo(newpos);
            while (!_CAxis.MotionComplete())
            {
                Thread.Sleep(10);
            }
            return true;
        }
        public bool MoveSingleFeed(double speed, double x, double y, double z, double a, double b, double c)
        {
            currentX = x;
            currentY = y;
            currentZ = z;
            currentA = a;
            currentB = b;
            currentC = c;
                       
            _Controller.CoordMotion.StraightTraverse(currentX, currentY, currentZ, currentA, currentB, currentC, true);
           // _Controller.CoordMotion.SetTPParams();
            
            _Controller.CoordMotion.DownloadDoneSegments();
            _Controller.CoordMotion.WaitForSegmentsFinished(true);
            _Controller.CoordMotion.FlushSegments();
           
            _BAxis.SetCurrentPosition(0);
            _CAxis.SetCurrentPosition(0);
            //Debug.WriteLine("(X:" + x.ToString() + ")(Y:" + y.ToString() + ")(Z:" + z.ToString() + ")(A:" + a.ToString() + ")(B:" + b.ToString() + ")(C:" + c.ToString());
            return true;
        }

        public bool MoveArrayFeed(double[,] array)
        {
            double speed = 0.0;
            for (int i = 0; i < array.Length; i++)
            {
                speed = array[i, 0];
                if (!array[i,1].Equals(currentX))
                {
                    currentX = array[i, 1];
                }
                if (!array[i, 2].Equals(currentY))
                {
                    currentY = array[i, 2];
                }
                if (!array[i, 3].Equals(currentZ))
                {
                    currentZ = array[i, 3];
                }
                if (!array[i, 4].Equals(currentA))
                {
                    currentA = array[i, 4];
                }
                if (!array[i, 5].Equals(currentB))
                {
                    currentB = array[i, 5];
                }
                if (!array[i, 6].Equals(currentC))
                {
                    currentC = array[i, 6];
                }

                _Controller.CoordMotion.StraightTraverse(currentX, currentY, currentZ, currentA, currentB, currentC, true);
                _Controller.CoordMotion.WaitForSegmentsFinished(true);
                _Controller.CoordMotion.FlushSegments();

            }


            

            
            return true;
        }

        public void GetDRO(out double _x, out double _y, out double _z, out double _a, out double _b, out double _c)
        {
            double x = 0;
            double y = 0; 
            double z = 0; 
            double a = 0; 
            double b = 0; 
            double c = 0;
             _Controller.CoordMotion.Interpreter.ReadCurMachinePosition(ref x, ref y, ref z, ref a, ref b, ref c);
             _x = x;
             _y = y;
             _z = z;
             _a = a;
             _b = b;
             _c = c;
        }

        
        public void EStop()
        {
            if (!eStopActive)
            {

                _XAxis.Disable();
                _YAxis.Disable();
                _ZAxis.Disable();
                _AAxis.Disable();
                _BAxis.Disable();
                _CAxis.Disable();
            }
            else
            {
                _XAxis.Enable();
                _YAxis.Enable();
                _ZAxis.Enable();
                _AAxis.Enable();
                _BAxis.Enable();
                _CAxis.Enable();
            }
        }
        public void JogAxis(string axis, bool direction)
        {
           // to do
            if (axis.Equals("X"))
            {
                if (direction)
                {
                    _XAxis.Jog();
                    _XAxis.JogVelocity = 100;
                    _XAxis.Jog();
                }
                else
                {
                    _XAxis.Jog(-JogSpeed);
                }
            }
            if (axis.Equals("Y"))
            {
                if (direction)
                {
                    _YAxis.Jog(JogSpeed);
                }
                else
                {
                    _YAxis.Jog(-JogSpeed);
                }
            }
            if (axis.Equals("Z"))
            {
                if (direction)
                {
                    _ZAxis.Jog(JogSpeed);
                }
                else
                {
                    _ZAxis.Jog(-JogSpeed);
                }
            }
            if (axis.Equals("A"))
            {
                if (direction)
                {
                    _AAxis.Jog(JogSpeed);
                }
                else
                {
                    _AAxis.Jog(-JogSpeed);
                }
            }
            if (axis.Equals("B"))
            {
                if (direction)
                {
                    _BAxis.Jog(JogSpeed);
                }
                else
                {
                    _BAxis.Jog(-JogSpeed);
                }
            }
            if (axis.Equals("C"))
            {
                if (direction)
                {
                    _CAxis.Jog(JogSpeed);
                }
                else
                {
                    _CAxis.Jog(-JogSpeed);
                }
            }

        }
        public void JogAxisStop()
        {
            _XAxis.Stop();
            _XAxis.Stop();
            _YAxis.Stop();
            _ZAxis.Stop();
            _AAxis.Stop();
            _BAxis.Stop();
            _CAxis.Stop();
        }

        // event handlers for motion controller
        void Interpreter_Interpreter_CoordMotionStraightTranverse(double x, double y, double z, int sequence_number)
        {
            Debug.WriteLine("Interpreter CoordMotion Straight Tranverse::  {0} | {1} | {2} | {3}", x, y, z, sequence_number);
        }

        void Interpreter_Interpreter_CoordMotionStraightFeed(double DesiredFeedRate_in_per_sec, double x, double y, double z, int sequence_number, int ID)
        {
            Debug.WriteLine("Interpreter CoordMotion Straight Feed::  {0} | {1} | {2} | {3} | {4} | {5}", DesiredFeedRate_in_per_sec, x, y, z, sequence_number, ID);
        }

        void Interpreter_Interpreter_CoordMotionArcFeed(bool ZeroLenAsFullCircles, double DesiredFeedRate_in_per_sec, int plane, double first_end, double second_end, double first_axis, double second_axis, int rotation, double axis_end_point, double first_start, double second_start, double axis_start_point, int sequence_number, int ID)
        {
            Debug.WriteLine("Interpreter CoordMotion Arc Feed::  {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} | {11} | {12}",
                ZeroLenAsFullCircles,
                DesiredFeedRate_in_per_sec,
                plane, first_end,
                second_end,
                first_axis,
                second_axis,
                rotation,
                axis_end_point,
                first_start,
                second_start,
                axis_start_point,
                sequence_number,
                ID);
        }

        void Interpreter_InterpreterCompleted(int status, int lineno, int sequence_number, string err)
        {
            Debug.WriteLine(String.Format("Interpreter Completed::  {0} | {1} | {2} | {3}", status, lineno, sequence_number, err));
            //            complete = true;
        }

        void Interpreter_InterpreterStatusUpdated(int lineno, string msg)
        {
            Debug.WriteLine("Interpreter Status Update:");
            Debug.WriteLine(lineno);
            Debug.WriteLine(msg);
        }

        void Interpreter_InterpreterUserCallbackRequested(string msg)
        {
            Debug.WriteLine("Interpreter User Callback:");
            Debug.WriteLine(msg);
        }

        int Interpreter_InterpreterUserMCodeCallbackRequested(int code)
        {
            throw new NotImplementedException();
        }

        void AddHandlers()
        {


            //Set the callback for general messages
            _Controller.MessageReceived += new KMotion_dotNet.KMConsoleHandler(_Controller_MessageUpdated);
            //And Errors
            _Controller.ErrorReceived += new KMotion_dotNet.KMErrorHandler(_Controller_ErrorUpdated);


            //CoordMotion Callbacks 
            _Controller.CoordMotion.CoordMotionStraightTraverse += new KMotion_dotNet.KM_CoordMotionStraightTraverseHandler(CoordMotion_CoordMotionStraightTranverse);
            _Controller.CoordMotion.CoordMotionArcFeed += new KMotion_dotNet.KM_CoordMotionArcFeedHandler(CoordMotion_CoordMotionArcFeed);
            _Controller.CoordMotion.CoordMotionStraightFeed += new KMotion_dotNet.KM_CoordMotionStraightFeedHandler(CoordMotion_CoordMotionStraightFeed);


            //Set the Interpreter's callbacks
            _Controller.CoordMotion.Interpreter.InterpreterStatusUpdated += new KMotion_dotNet.KM_Interpreter.KM_GCodeInterpreterStatusHandler(Interpreter_InterpreterStatusUpdated);
            _Controller.CoordMotion.Interpreter.InterpreterCompleted += new KMotion_dotNet.KM_Interpreter.KM_GCodeInterpreterCompleteHandler(Interpreter_InterpreterCompleted);
            _Controller.CoordMotion.Interpreter.InterpreterUserCallbackRequested += new KMotion_dotNet.KM_Interpreter.KM_GCodeInterpreterUserCallbackHandler(Interpreter_InterpreterUserCallbackRequested);
            _Controller.CoordMotion.Interpreter.InterpreterUserMCodeCallbackRequested += new KMotion_dotNet.KM_Interpreter.KM_GCodeInterpreterUserMcodeCallbackHandler(Interpreter_InterpreterUserMCodeCallbackRequested);
        }

        static int _Controller_MessageUpdated(string message)
        {
            Debug.WriteLine(message);
            return 0;
        }

        /// <summary>
        /// Handler for the error message pump
        /// </summary>
        /// <param name="message">error string</param>
        static void _Controller_ErrorUpdated(string message)
        {
            Debug.WriteLine("#########################  ERROR  #########################");
            Debug.WriteLine(message);
            Debug.WriteLine("#########################  ERROR  #########################");
        }

        static void CoordMotion_CoordMotionStraightTranverse(double x, double y, double z, int sequence_number)
        {
            Debug.WriteLine("CoordMotion Straight Tranverse::  {0} | {1} | {2} | {3}", x, y, z, sequence_number);
        }

        static void CoordMotion_CoordMotionStraightFeed(double DesiredFeedRate_in_per_sec, double x, double y, double z, int sequence_number, int ID)
        {
            Debug.WriteLine("CoordMotion Straight Feed::  {0} | {1} | {2} | {3} | {4} | {5}", DesiredFeedRate_in_per_sec, x, y, z, sequence_number, ID);
        }

        static void CoordMotion_CoordMotionArcFeed(bool ZeroLenAsFullCircles, double DesiredFeedRate_in_per_sec, int plane, double first_end, double second_end, double first_axis,
            double second_axis, int rotation, double axis_end_point, double first_start, double second_start, double axis_start_point, int sequence_number, int ID)
        {
            Debug.WriteLine("CoordMotion Arc Feed::  {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} | {11} | {12}",
                ZeroLenAsFullCircles,
                DesiredFeedRate_in_per_sec,
                plane, first_end,
                second_end,
                first_axis,
                second_axis,
                rotation,
                axis_end_point,
                first_start,
                second_start,
                axis_start_point,
                sequence_number,
                ID);
        }
    }
}
