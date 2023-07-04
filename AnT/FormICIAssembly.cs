using bpac;
using HALQRLabel.DB;
using HALQRLabel.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALQRLabel.AnT
{
    public partial class FormICIAssembly : Form
    { 
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormICIAssembly()
        {
            InitializeComponent();
            updateSeq();
            listAllPrinters();
        }

        private void updateSeq()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i <= 9)
                {
                    cboSeqStart.Items.Add("0" + i);
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

        private void listAllPrinters()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cboPrinters.Items.Add(printer);
                //MessageBox.Show(printer);
            }
        }
 
        private const string TEMPLATE_36mm = "ici_assm_marking_36.lbx";

        /**
         *txtPartNum
         * txtPartNumOld
         * txtSlNum
         * 
         */
        private void print()
        {

            if(cboPrinters.Text.Equals("") )
            {
                MessageBox.Show("Please select a Brother Pritner ");
                return;
            }

            string size = string.Empty;
            String TEMPLATE_DIRECTORY = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ici-assm-templates\");
            string templatePath = TEMPLATE_DIRECTORY + TEMPLATE_36mm;

            bool print_ok = false;
            string str_start = (string)cboSeqStart.SelectedItem;
            string str_end = (string)cboSeqEnd.SelectedItem;

            int start = Int16.Parse(str_start);
            int end = Int16.Parse(str_end);

            if (start > end)
            {
                MessageBox.Show("Start sequence number must be lesser than end sequence num, Please correct it. ");
                return;
            }


            for (int i = start; i <= end; i++)
            {
                string str = string.Empty;
                if (i <= 9)
                {
                    str = "0" + i;
                }
                else
                {
                    str = "" + i;
                }

                try
                {
                    bpac.DocumentClass doc = new bpac.DocumentClass();
                    //doc.SetPrinter("Brother PT-P900W", true);
                    doc.SetPrinter(cboPrinters.Text, true);

                    if (doc.Open(templatePath) != false)
                    {
                        string pre = "M ";
                        if (rdoAssy.Checked)
                        {
                            pre = "ASSY ";
                        }
                        doc.GetObject("txtPoNum").Text = "P " + txtPoNum.Text;
                        doc.GetObject("txtPartNum").Text = pre + txtPartNum.Text;
                        doc.GetObject("txtPartNumOld").Text = "" + txtPartNumOld.Text;
                        doc.GetObject("txtSlNum").Text = "" + txtSlNum.Text + "-" + str;

                        // doc.SetMediaById(doc.Printer.GetMediaId(), true);
                        doc.StartPrint("", PrintOptionConstants.bpoDefault);
                        doc.PrintOut(1, PrintOptionConstants.bpoDefault);
                        doc.EndPrint();
                         
                        doc.Close();
                        print_ok = true;                        
                    }
                }
                catch (Exception ee)
                {
                    log.Info("Error " + ee.Message);
                    MessageBox.Show("Printer Error ");
                    
                }
            }//for

            if(print_ok)
            MessageBox.Show("All Print sent to Printer ");

        }

        private void doClear()
        {
            txtPoNum.Text = "";
            txtPartNum.Text = "";
            txtPartNumOld.Text = "";
            txtSlNum.Text = "";
            cboSeqStart.SelectedIndex = 0;
            cboSeqEnd.SelectedIndex = 0;
        }




        public   void doFetch( )
        {
            MatDao dao = null;
            string ponum = txtPoNum.Text;
            if (ponum.Length < 0)
            {
                MessageBox.Show("Please enter po num");
                return  ;
            }

            dao = DBUtils.doFetchMaterial(ponum);
            if (dao != null){
                txtPartNum.Text = dao.MaterialNum;
                txtPartNumOld.Text = dao.OldMaterialNum;
                txtSlNum.Text = dao.BatchNum;
            }
            else
            {
                MessageBox.Show("Material info not found for  po num "+ponum);
            }

        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            doClear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print();
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            print();
        }

        private void btnPONumFetch_Click(object sender, EventArgs e)
        {
            doFetch();
        }
    }
}
