using HALQRLabel.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALQRLabel.wifi
{
    public partial class WifiPrinter : Form
    {
        public WifiPrinter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           DBUtils.doWifiPrinter();
        }
    }
}
