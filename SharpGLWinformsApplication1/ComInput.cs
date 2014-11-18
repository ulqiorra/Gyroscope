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

        public static float osX = 0.0f;
        public static float osY = 0.0f;
        public static float osZ = 0.0f;

        private System.Object lockThis = new System.Object();

        public void mainMethod()
        {
            SerialPort mySerialPort = new SerialPort("COM6");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.RequestToSend;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            mySerialPort.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorReceived);

            mySerialPort.Open();

        }        

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        { 
                SerialPort sp = (SerialPort)sender;
                string indata = sp.ReadExisting();

                Parser p = new Parser();
                osX = p.getAngleX(indata);
                osY = p.getAngleY(indata);
                osZ = p.getAngleZ(indata);

                indata = null;

                sp.DiscardInBuffer();

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
