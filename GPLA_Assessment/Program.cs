using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    /// <summary>
    /// The main class of the program which run the application
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application. <br/>Enables the graphical application window - Windows Form to display when the program is run.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}