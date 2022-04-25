using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Message_Relay_GUI
{
    static class MessageProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SpaghettiForm());
        }
    }
}