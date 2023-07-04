using bpac;
using HALQRLabel.DB;
using Microsoft.Reporting.WinForms;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALQRLabel.forms
{
    public partial class FormBrotherPrinter : Form
    {
        private  string TEMPLATE_DIRECTORY = @"C:\temp\brother\templates\"; // Template file path
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string TEMPLATE_18mm = "logis-QR-18mm.lbx";    // Template file name
        private const string TEMPLATE_12mm = "logis-QR-12mm.lbx";     // Template file name
        private const string TEMPLATE_36mm = "logis-QR-36mm.lbx";
        private const string TEMPLATE_24mm = "logis-QR-24mm.lbx";

        public FormBrotherPrinter()
        {
            InitializeComponent();
            //doClear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtDNNum.Text.Length < 1)
            {
                MessageBox.Show("Please enter DN ");
                return;
            }

            if (txtLineNum.Text.Length < 1)
            {
                MessageBox.Show("Please enter DN Line Num ");
                return;
            }

            MessageBox.Show("It may take bit longer depends on your network speed and Database response");
            button2.Enabled = false;

            if (doClear())
            {
                reportViewer1.Clear();
                Thread.Sleep(1000);
                doGetMat();
            }
        }

        private static string QR_REV = "A";
        private static string COMMA = ",";
        //We dont have part rev
        private string doQRCode(string rev)
        {
            String QR_Text = "";
            QR_Text = txtSlNum.Text + COMMA + txtPartNum.Text + COMMA + rev + COMMA + txtDNNum.Text + COMMA + txtLineNum.Text
                + COMMA + txtWeight.Text + COMMA + QR_REV;
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QR_Text, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                pictureBox1.Image = qrCodeImage;

                Console.WriteLine("QR Generated successfully ");
            }catch(Exception ee)
            {
                log.Error("EE " + ee);
            }

            return QR_Text;
        }

        private void doGetMat()
        {
            MatDao dao = null;
            try
            {
                dao = DBUtils.getMaterial(txtDNNum.Text, txtLineNum.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error fetching " + ee.Message);
                return;
            }
            if (dao == null)
            {
                MessageBox.Show("Sorry cant be found in the db ");
                return;
            }

            txtPartNum.Text = dao.MaterialNum;

            try
            {
                if (dao.MaterialDesc.Length > 20)
                {
                    txtDesc1.Text = dao.MaterialDesc.Substring(0, 20);
                    txtDesc2.Text = dao.MaterialDesc.Substring(20);
                }
                else
                {
                    txtDesc1.Text = dao.MaterialDesc;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("material Description error  ");
                txtDesc1.Text = "";
                return;
            }

            txtWeight.Text = dao.GrossWeight + " " + dao.WeightUnit;
            txtSlNum.Text = dao.BatchNum + "-" + txtSlNum2.Text;
            //txtLineNum.Text = ;

            //generate QRCode
            doQRCode(dao.MaterialRev);
            txtRev.Text = dao.MaterialRev;

            //Replace new QRImage
            try
            {
                string pat = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/qr").AbsoluteUri;
                Console.WriteLine("Path = " + pat);
                //
                // pictureBox1.Image.Save(@"c:\\temp\qra1.jpg", ImageFormat.Jpeg);//OK 

                pictureBox1.Image.Save(@"qra1.jpg", ImageFormat.Jpeg);
                Console.WriteLine("Saved successfully ");
            }
            catch (Exception ee)
            {
                Console.WriteLine("Error saving image " + ee.Message);
                return;
            }

            doButtonClick();
        }

        private void doButtonClick()
        {
            try
            {
                LocalReport report = reportViewer1.LocalReport;
                //report.ReportPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)+"\\Report1.rdlc";
                //working
                report.ReportPath = "Report2.rdlc";

                //setting parameters
                string rprm_txt_dn_num = "DN:" + txtDNNum.Text + " | DN LINE:" + txtLineNum.Text;
                string rprm_txt_desc1 = txtDesc1.Text;
                string rprm_txt_desc2 = txtDesc2.Text;
                string rprm_txt_part_num = txtPartNum.Text;
                string rptm_txt_weight = "" + txtWeight.Text;
                string rprm_txt_sl_num = "" + txtSlNum.Text;


                string pat = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/qr.JPG").AbsoluteUri;
                Console.WriteLine("Path = " + pat);


                string pat2 = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/qra1.jpg").AbsoluteUri; ;
                string rprm_txt_img_path = @"" + pat2;// "c:/temp/qr.JPG";

                Console.WriteLine("rprm_txt_img_path = " + rprm_txt_img_path);

                ReportParameter[] param = new ReportParameter[7];

                report.EnableExternalImages = true;
                //string imagePath = new Uri(Server.MapPath("~/images/Mudassar.jpg")).AbsoluteUri;

                param[0] = new ReportParameter("rprm_txt_dn_num", rprm_txt_dn_num, true);
                param[1] = new ReportParameter("rprm_txt_desc1", rprm_txt_desc1, true);
                param[2] = new ReportParameter("rprm_txt_desc2", rprm_txt_desc2, true); //
                param[3] = new ReportParameter("rprm_txt_part_num", rprm_txt_part_num, true);// 
                param[4] = new ReportParameter("rprm_txt_img_path", rprm_txt_img_path, true);
                param[5] = new ReportParameter("rptm_txt_weight", rptm_txt_weight, true);
                param[6] = new ReportParameter("rprm_txt_sl_num", rprm_txt_sl_num, true);


                report.SetParameters(param);

                //set datasource
                //report.DataSources.Add(new ReportDataSource("SaleSlipData", dtAddItems));
                //report.DataSources.Add(new ReportDataSource("SaleSlipPaymentData", dtPaymentCollection));

                // report.DataSources.Add();
                // reportViewer1.PrinterSettings.PaperSizes = ;

                reportViewer1.Clear();
                reportViewer1.RefreshReport();
            }
            catch (Exception ee)
            {
                Console.WriteLine("Report Error " + ee.Message);
            }
        }



        private bool doClear()
        {
          
            txtPartNum.Text = "";
            txtDesc1.Text = "";
            txtDesc2.Text = "";
            txtSlNum.Text = "";
            txtWeight.Text = "";
            return true;
        }

        private void doPrint()
        {
            try
            {
                string prt = txtPartNum.Text;

                if (txtDNNum.Text.Length < 1)
                {
                    MessageBox.Show("Please enter DN ");
                    return;
                }

                if (txtLineNum.Text.Length < 1)
                {
                    MessageBox.Show("Please enter DN Line Num ");
                    return;
                }

                if (prt.Length < 1)
                {
                    MessageBox.Show("Please fetch data!");
                    return;
                }

                string size = string.Empty;

                TEMPLATE_DIRECTORY = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"brother-templates\");
               // string[] files = File.ReadAllLines(path);

                string templatePath = TEMPLATE_DIRECTORY + TEMPLATE_18mm;
                log.Info("template dir = "+ TEMPLATE_DIRECTORY);
                  if (rdo18mm.Checked)
                  {
                      templatePath = TEMPLATE_DIRECTORY + TEMPLATE_18mm;
                  }
                  else if (rdo36mm.Checked)
                  {
                      templatePath = TEMPLATE_DIRECTORY + TEMPLATE_36mm;
                  }
                  else if (rdo24mm.Checked)
                  {
                      templatePath = TEMPLATE_DIRECTORY + TEMPLATE_24mm;
                  }
                log.Info("template full path " + templatePath);
                // templatePath = TEMPLATE_DIRECTORY + TEMPLATE_18mm;

                //string templatePath = TEMPLATE_DIRECTORY + TEMPLATE_18mm;
                bpac.Document doc = new bpac.Document();


                if (doc.Open(templatePath) != false)
                {

                    /*  doc.GetObject("objDwgNum").Text = txtDwgNum.Text;
                      doc.GetObject("ObjPrtNum").Text = txtPartNum.Text;
                      doc.GetObject("objBatchNum").Text = txtBatchNum.Text;
                      doc.GetObject("objBarCode").Text = txtDwgNum.Text + "|" + txtPartNum.Text + "|" + txtBatchNum.Text; */

                    //qrcode_fix_id | txtDwgNum
                    doc.GetObject("qrcode_fix_id").Text = doQRCode(txtRev.Text);
                    doc.GetObject("txtDwgNum").Text = txtPartNum.Text;
                    doc.GetObject("txtDesc1").Text = txtDesc1.Text;
                    doc.GetObject("txtDesc2").Text = txtDesc2.Text;
                    doc.GetObject("txtSlNo").Text = txtSlNum.Text;
                    doc.GetObject("txtWeight").Text = txtWeight.Text;


                    // doc.SetMediaById(doc.Printer.GetMediaId(), true);
                    doc.StartPrint("", PrintOptionConstants.bpoDefault);
                    doc.PrintOut(1, PrintOptionConstants.bpoDefault);
                    doc.EndPrint();
                    doc.Close();
                }
                else
                {
                    MessageBox.Show("Open() Error: " + doc.ErrorCode);
                }
            }
            catch (Exception ee)
            {
                log.Error("Error " + ee.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           DialogResult res=  MessageBox.Show("Are you sure to print?","Print", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                doPrint();
            }
            button2.Enabled = true;

        }

        private void txtDNNum_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            doClear();
            button2.Enabled = true;
            txtDNNum.Text = "";
            txtLineNum.Text = "";
            txtSlNum.Text = "";
        }
    }
}
