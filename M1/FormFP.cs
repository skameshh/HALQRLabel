using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALQRLabel.M1
{
    public partial class FormFP : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormFP()
        {
            InitializeComponent();
        }

        private void FormFP_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            doPrintLoad();
        }

        private void doPrint()
        {
            reportViewer1.PrintDialog();
        }
        private void doPrintLoad()
        {
            try
            {
                LocalReport report = reportViewer1.LocalReport;
                report.ReportPath = "M1\\M1Floatprint.rdlc";
                //setting parameters
                //    string rprm_txt_dn_num = "DN:" + txtDNNum.Text + " | DN LINE:" + txtLineNum.Text;
                //string rprm_txt_desc1 = txtDesc1.Text;
                //string rprm_txt_desc2 = txtDesc2.Text;

                //ReportParameter[] param = new ReportParameter[7];
                //report.EnableExternalImages = true;
                //param[0] = new ReportParameter("rprm_txt_dn_num", rprm_txt_dn_num, true);
                //report.SetParameters(param);
                reportViewer1.Clear();
                reportViewer1.RefreshReport();
            }
            catch (Exception ee)
            {
                log.Info("EE " + ee.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doPrint();
        }
    }
}
