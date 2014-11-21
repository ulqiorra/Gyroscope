using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace SharpGLWinformsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread thread = new Thread(ComInput.go);
            thread.Start();
            //new Thread(ComInput.go).Start();
            Application.Run(new SharpGLForm());
            
        }
    }
}
