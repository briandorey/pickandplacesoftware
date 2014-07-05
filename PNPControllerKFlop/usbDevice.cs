//-----------------------------------------------------------------------------
//
//  usbDevice.cs
//
//  USB Generic Demonstration 3_0_0_0
//
//  A demonstration application for the usbGenericHidCommunications library
//  Copyright (C) 2011 Simon Inns
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
//  Web:    http://www.waitingforfriday.com
//  Email:  simon.inns@gmail.com
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// The following namespace allows debugging output (when compiled in debug mode)
using System.Diagnostics;

namespace PNPControllerKFlop
    {
    using usbGenericHidCommunications;

    /// <summary>
    /// This class performs several different tests against the 
    /// reference hardware/firmware to confirm that the USB
    /// communication library is functioning correctly.
    /// 
    /// It also serves as a demonstration of how to use the class
    /// library to perform different types of read and write
    /// operations.
    /// </summary>
    class usbDevice : usbGenericHidCommunication
        {
        /// <summary>
        /// Class constructor - place any initialisation here
        /// </summary>
        /// <param name="vid"></param>
        /// <param name="pid"></param>
        public usbDevice(int vid, int pid) : base(vid, pid)
            {
            }


        public bool getDeviceStatus()
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x01;
            outputBuffer[2] = 0x01;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            return success;
        }

        public bool getFeederReadyStatus()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x02;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 0) return true;
                if (inputBuffer[1] == 1) return false;
            }

            return success;
        }

        public bool setGotoFeeder(byte inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x03;
            outputBuffer[3] = inval;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setGotoFeederWithoutPick(byte inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x08;
            outputBuffer[3] = inval;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setFeederPort(Int16 inval)
        {
            byte b0 = (byte)inval,
                 b1 = (byte)(inval >> 8);

            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x07;
            outputBuffer[3] = b0;
            outputBuffer[4] = b1;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }



        public bool setPickerUp()
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x04;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setResetFeeder()
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x05;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setPickerDown()
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x06;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setVAC1(bool inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x01;
            if (inval)
            {
                outputBuffer[3] = 0x01;
            }
            else
            {
                outputBuffer[3] = 0x00;
            }

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setVAC2(bool inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x02;
            if (inval)
            {
                outputBuffer[3] = 0x01;
            }
            else
            {
                outputBuffer[3] = 0x00;
            }

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setVibrationMotor(bool inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x03;
            if (inval)
            {
                outputBuffer[3] = 0x01;
            }
            else
            {
                outputBuffer[3] = 0x00;
            }

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setVibrationMotorSpeed(byte inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x07;
            outputBuffer[3] = inval;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool getVac1Status()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x04;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 1) return true;
                if (inputBuffer[1] == 0) return false;
            }

            return success;
        }

        public bool getVac2Status()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x05;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 1) return true;
                if (inputBuffer[1] == 0) return false;
            }

            return success;
        }

        public bool getVibrationStatus()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x06;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 1) return true;
                if (inputBuffer[1] == 0) return false;
            }

            return success;
        }

        public bool setBaseCameraLED(bool inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x01;
            if (inval)
            {
                outputBuffer[3] = 0x01;
            }
            else
            {
                outputBuffer[3] = 0x00;
            }

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setHeadCameraLED(bool inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x03;
            if (inval)
            {
                outputBuffer[3] = 0x01;
            }
            else
            {
                outputBuffer[3] = 0x00;
            }

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setBaseCameraPWM(byte inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x02;
            outputBuffer[3] = inval;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setHeadCameraPWM(byte inval)
        {
            Byte[] outputBuffer = new Byte[65];


            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x04;
            outputBuffer[3] = inval;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool getBaseCameraLEDStatus()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x05;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 1) return true;
                if (inputBuffer[1] == 0) return false;
            }

            return success;
        }

        public bool getHeadCameraLEDStatus()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x06;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 1) return true;
                if (inputBuffer[1] == 0) return false;
            }

            return success;
        }





       

        // Collect debug information from the device
        public String collectDebug()
            {
            // Collect debug information from USB device
            Debug.WriteLine("Reference Application -> Collecting debug information from device");

            // Declare our output buffer
            Byte[] outputBuffer = new Byte[65];

            // Declare our input buffer
            Byte[] inputBuffer = new Byte[65];

            // Byte 0 must be set to 0
            outputBuffer[0] = 0;

            // Byte 1 must be set to our command
            outputBuffer[1] = 0x10;

            // Send the collect debug command
            writeRawReportToDevice(outputBuffer);

            // Read the response from the device
            readSingleReportFromDevice(ref inputBuffer);

            // Byte 1 contains the number of characters transfered
            if (inputBuffer[1] == 0) return String.Empty;

            // Convert the Byte array into a string of the correct length
            string s = System.Text.ASCIIEncoding.ASCII.GetString(inputBuffer, 2, inputBuffer[1]);

            return s;
            }
        }
    }