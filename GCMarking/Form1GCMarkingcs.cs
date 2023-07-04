using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bpac;
using HALQRLabel.DB;

namespace HALQRLabel.GCMarking
{
    public partial class Form1GCMarkingcs : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1GCMarkingcs()
        {
            InitializeComponent();
            updateSeq();
        }

        private void updateSeq()
        {
            for(int i=1; i <= 100; i++)
            {
                if (i <= 9)
                {
                    cboSeqStart.Items.Add("0"+i);
                    cboSeqEnd.Items.Add("0" + i);
                }
                else
                {
                    cboSeqStart.Items.Add("" + i);
                    cboSeqEnd.Items.Add("" + i);
                }
               
            }
            cboSeqStart.SelectedIndex = 0;
            cboSeqEnd.SelectedIndex = 0;
        }

       /* private void printOld()
        {
            try
            {
                LocalReport report = reportViewer1.LocalReport;
                report.ReportPath = "GCMarking/GCMarking1.rdlc";

                string rprm_txt_part_num = "M 103059904";
                string rptm_txt_part_num_old = "78Q10300-SBB";
                string rprm_txt_sl_num = "0004757962-20";
                string coo1 = "COUNTRY OF";
                string coo2 = "ORIGINS SINGAPORE";

                ReportParameter[] param = new ReportParameter[5];

                report.EnableExternalImages = true;

                param[0] = new ReportParameter("rprm_part_num", rprm_txt_part_num, true);
                param[1] = new ReportParameter("rprm_part_num_old", rptm_txt_part_num_old, true);
                param[2] = new ReportParameter("rprm_sl_num", rprm_txt_sl_num, true); //
                param[3] = new ReportParameter("rprm_coo_1", coo1, true);// 
                param[4] = new ReportParameter("rprm_coo_2", coo2, true);

                report.SetParameters(param);

                reportViewer1.Clear();
                reportViewer1.RefreshReport();
            }catch(Exception ee)
            {
                Console.WriteLine("Error " + ee.Message);
            }
        }*/

        private void doClear()
        {
            txtGCPONum.Text = "";
            txtPartNum.Text = "";
            txtSlNum.Text = "";
            txtPartNumOld.Text = "";
        }

        private void doFetch()
        {
            String ponum = txtGCPONum.Text;
            if (ponum.Length < 5)
            {
                MessageBox.Show("Please enter PO Num ");
                return;
            }
            try
            {
                MatDao dao = DBUtils.doFetchMaterial(ponum);
                txtPartNum.Text = dao.MaterialNum;
                txtPartNumOld.Text = dao.OldMaterialNum;
                txtSlNum.Text = dao.BatchNum;
                if (dao.TotOrdQty > 0)
                {
                    cboSeqEnd.Text = dao.TotOrdQty + "";
                }
            }catch(Exception ee)
            {
                MessageBox.Show("Error in fetching " + ee.Message);
            }

            log.Info("Got ");
        }

        private const string TEMPLATE_36mm = "gc_marking_36.lbx";

        /**
         *txtPartNum
         * txtPartNumOld
         * txtSlNum
         * 
         */
        private void print()
        {
            string size = string.Empty;
            String TEMPLATE_DIRECTORY = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"gc-templates\");
            string templatePath = TEMPLATE_DIRECTORY + TEMPLATE_36mm;


            string str_start = (string) cboSeqStart.Text;
            string str_end = (string)cboSeqEnd.Text;

            int start = Int16.Parse( str_start);
            int end = Int16.Parse(str_end);

            if (start > end)
            {
                MessageBox.Show("Start sequence number must be lesser than end sequence num, Please correct it. ");
                return;
            }


            for (int i = start; i <=end; i++)
            {
                string str = string.Empty;
                if (i <= 9)
                {
                    str = "0"+i;
                }
                else
                {
                    str = ""+i;
                }
                 

                try
                {
                 
                    bpac.DocumentClass doc = new bpac.DocumentClass();
                    doc.SetPrinter("Brother PT-P900W", true);
                    //doc.SetMediaById();
                    if (doc.Open(templatePath) != false)
                    {
                        doc.GetObject("txtPartNum").Text = "M " + txtPartNum.Text;
                        doc.GetObject("txtPartNumOld").Text = "" + txtPartNumOld.Text;
                        doc.GetObject("txtSlNum").Text = "" + txtSlNum.Text+"-"+str;


                        // doc.SetMediaById(doc.Printer.GetMediaId(), true);
                        doc.StartPrint("", PrintOptionConstants.bpoDefault);
                        doc.PrintOut(1, PrintOptionConstants.bpoDefault);
                        doc.EndPrint();
                        doc.Close();
                    }
                }
                catch (Exception ee)
                {
                    log.Info("Error " + ee.Message);
                    MessageBox.Show("Print error " + ee.Message);
                }
            }//for

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print();
        }

        private void Form1GCMarkingcs_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMaterialNumFetch_Click(object sender, EventArgs e)
        {

        }

        private void btnFetchPONum_Click(object sender, EventArgs e)
        {
            doFetch();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            doClear();
        }

        private void txtGCPONum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                doFetch();
                btnPrint.Focus();
            }
        }
    }
}
