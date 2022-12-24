using System;
using System.Windows.Forms;

namespace PhilosophersAndSpaghetti
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Supervisor Boss = new Supervisor();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProgramUI(Boss));


        }
    }
}
