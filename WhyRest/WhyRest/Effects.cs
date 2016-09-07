using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using WhyRest.Utilities;

namespace WhyRest
{
    [DataContract]
    public class Effect
    {
        [DataMember]
        public int id;

        [DataMember]
        public string name;

        [DataMember]
        public bool Solenoid;

    }

    public partial class Effects
    {
        private static readonly Effects _instance = new Effects();

        private Effects() {

        }

        public static Effects Instance
        {
            get { return _instance; }
        }

        public List<Effect> EffectList
        {
            get { return fxs; }
        }

        private List<Effect> fxs = new List<Effect>()
        {
            //ids correspond to arduino pin for convenience
            new Effect() {id = 2, name = "W1"},
            new Effect() { id = 3, name = "W2"},
            new Effect() { id = 4, name = "W3"},
            new Effect() { id = 5, name = "H4" },
            new Effect() { id = 6, name = "H5" },
            new Effect() { id = 7, name = "Y6" },
            new Effect() { id = 8, name = "Y7" },
        };

        public void Fire(int id)
        {
            //Send the states of all effects and properties as a serial message
            //Arduino side code should read datawords, look for &, count chars through the list of effects and break on %
            string data = buildFireCommand(id);
            sendSerial(data);
        }

        public static void sendSerial(string data)
        {
            try
            {
                //waitForArduino();
                if (!ArduinoAccessLayer.Instance.ArduinoPort.IsOpen)
                {
                    ArduinoAccessLayer.Instance.ArduinoPort.Open();
                }

                if (ArduinoAccessLayer.Instance.ArduinoPort.IsOpen)
                {
                    ArduinoAccessLayer.Instance.ArduinoPort.Write(data);
                }

                ArduinoAccessLayer.Instance.ArduinoPort.Close();
            }
            catch (Exception e)
            {
                //handle silently.
            }
        }

        private string buildFireCommand(int id)
        {
            // method for packing all effects and states into a 
            //serial word for consumption by the arduino
            // & Begin message
            // % End message
            IEnumerable<Effect> fxs = Instance.EffectList;
            //correct id to zero index
            string message = "1" + fxs.ElementAt(id - 1).id.ToString() + "\n";
            return message;
        }

    }
}