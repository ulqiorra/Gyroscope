using System;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace SharpGLWinformsApp
{
    class ComInput
    {
        public static void go()
        {
            ComInput c = new ComInput();
            c.mainMethod();
        }

        public static float fl = 0.0f;

        public sealed class Coordinates
        {
            private Coordinates() {}

            private float osX = 0.0f;
            private float osY = 0.0f;
            private float osZ = 0.0f;
            static readonly Coordinates _instance = new Coordinates();
            public static Coordinates Instance
            {
                get
                {
                    return _instance;
                }
            }

            public void setX(float x)
            { this.osX = x; }

            public float getX()
            { return this.osX; }

            public void setY(float y)
            { this.osY = y; }

            public float getY()
            { return this.osY; }

            public void setZ(float z)
            { this.osZ = z; }

            public float getZ()
            { return this.osZ; }
        }

        public void mainMethod()
        {
            SerialPort mySerialPort = new SerialPort("COM6");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            mySerialPort.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorReceived);

            mySerialPort.Open();

            while (true)
            {
                Thread.Sleep(1000);
                fl++;
                if (fl > 1000)
                {
                    fl = 0.0f;
                }
            }

        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        { 
                SerialPort sp = (SerialPort)sender;
                string indata = sp.ReadExisting();    

                Coordinates cord = Coordinates.Instance;

                Parser p = new Parser();
                cord.setX(p.getAngleX(indata));//Coordinates.osX = p.getAngleX(indata);
                cord.setY(p.getAngleY(indata));//Coordinates.osY = p.getAngleY(indata);
                cord.setZ(p.getAngleZ(indata));//Coordinates.osZ = p.getAngleZ(indata);                

                indata = null; 

                sp.DiscardInBuffer();
               

                /*using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\StringExample.txt", true))
                {
                    String callstackStr = Dbg.GetStackString();
                    file.WriteLine(callstackStr);
                } */

        }        

        private void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();              
            
        }

       /* private static System.Timers.Timer aTimer;

        public void mainMethod()
        {
            aTimer = new System.Timers.Timer(25);

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            aTimer.Enabled = true;

           // Console.ReadKey();
        }

        public static int x = 1, counter = 0;

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {

            if (counter <= 45)
            {
                osX += 2.0f * x;
                osZ += 2.0f * x;
                counter++;
            }
            else
            {
                counter = 0;
                x = x * (-1);
            } 

        }   */


    }
}
