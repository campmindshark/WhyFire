using System;
using System.Management;
using System.IO.Ports;


namespace WhyRest.Utilities
{
    public class ArduinoAccessLayer
    {
        //Container class for methods to detect, connect and command an arduino based control layer

        #region "Properties"
        public string portName;
        public SerialPort ArduinoPort;
        public const int baud = 9600;
        #endregion
        #region "Constructors"
        private static ArduinoAccessLayer instance;
        private ArduinoAccessLayer(string port)
        {
            try
            {
                portName = port;
                if (portName != null)
                {
                    ArduinoPort = new SerialPort(portName, baud);
                    ArduinoPort.Open();
                }
                else
                {
                    throw new Exception("Failed to open serial port: " + portName);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Serial Error", e);
            }

        }

        public static ArduinoAccessLayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArduinoAccessLayer(AutodetectArduinoPort());
                }
                return instance;
            }
        }
        #endregion

        #region "Data Access"
        private static string AutodetectArduinoPort()
        {
            try
            {
                ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);


                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino") || desc.Contains("uno"))
                    {
                        return deviceId;
                    }
                }
                //no device found
                return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}

