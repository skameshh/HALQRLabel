using HALQRLabel.AnT;
using HALQRLabel.GCMarking;
using HALQRLabel.Global;
using HALQRLabel.Logistics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALQRLabel
{
    public partial class FormHome : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormHome()
        {
            InitializeComponent();
            this.Text = "HAL Marking Lable " + MyGlobal.VERSION +"";
            //openDefaultForm();
        }

        


        private void openDefaultForm()
        {
            try
            {
                // string val =  ConfigurationManager.AppSettings["DefaultApp"];
                string val = ConfigurationManager.AppSettings["DB"];
                // System.Configuration.ConfigurationManager.AppSettings["ShowingApp"];
                log.Info("FORM = " + val);
                int ival = Int32.Parse(val);
                switch (ival)
                {
                    case 1://GC
                        loadGCMarking();
                        break;
                    case 2:

                        break;
                    case 3:
                        loadLogis();
                        break;
                    case 4:

                        break;
                    case 5:
                        loadICIAssmMarking();
                        break;
                    case 6:

                        break;

                }
            }catch(Exception ee)
            {
                log.Error("Error " + ee.Message);
                MessageBox.Show("Error " + ee.Message);
            }
            
        }

        private void loadGCMarking()
        {
            Form1GCMarkingcs gcfrm = new Form1GCMarkingcs();
            gcfrm.Show();
        }

        private void loadICIMarking()
        {
            FormICIMarking gcfrm = new FormICIMarking();
            gcfrm.Show();
        }

        private void loadICIAssmMarking()
        {
            FormICIAssembly frm = new FormICIAssembly();
            frm.Show();
        }

        private void loadLogis()
        {
            FormLogistics frm = new FormLogistics();
            frm.Show();
        }

        private void loadLogisLocal()
        {
            FormLogisticsLocal frm = new FormLogisticsLocal();
            frm.Show();
        }

        private void btnICIAssebly_Click(object sender, EventArgs e)
        {
            loadICIAssmMarking();
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            loadGCMarking();
        }

        private void btnLogis_Click(object sender, EventArgs e)
        {
            loadLogis();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }

        private void btnICI_Click(object sender, EventArgs e)
        {

        }

        private void btnICIMachining_Click(object sender, EventArgs e)
        {
            loadICIMarking();
        }

        private void btnLogisLocal_Click(object sender, EventArgs e)
        {
            loadLogisLocal();
        }
    }
}
