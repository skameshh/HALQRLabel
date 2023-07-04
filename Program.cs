using HALQRLabel.GCMarking;
using HALQRLabel.M1;
using HALQRLabel.wifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALQRLabel
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
            Application.Run(new FormHome()); //production FormHome | Form2 | WifiPrinter
                                             // Application.Run(new FormFP()); //test
        }
    }
}
