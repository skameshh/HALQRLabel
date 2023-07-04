using HALQRLabel.DB;
using HALQRLabel.Global;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALQRLabel.Logistics
{
    public partial class FormLogistics : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public FormLogistics()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            //getDefaultPrinter();
        }

        private void getDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            //lblDefaultPrinter.Text = "Printer: " + settings.PrinterName;
            Console.WriteLine(settings.PrinterName);
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


        private void button1_Click(object sender, EventArgs e)
        {
            doButtonClick();
        }

        private static string QR_REV = "A";
        private static string COMMA = ",";
        //We dont have part rev
        private void doQRCode(string rev)
        {
            String QR_Text = "";
            QR_Text = txtSlNum.Text + COMMA + txtPartNum.Text + COMMA + rev + COMMA + txtDNNum.Text + COMMA + txtLineNum.Text
                + COMMA + txtWeight.Text + COMMA + QR_REV;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QR_Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBox1.Image = qrCodeImage;

            Console.WriteLine("QR Generated successfully ");
        }


        private bool doGetMat()
        {
            MatDao dao = null;
            try
            {
                dao = DBUtils.getMaterial(txtDNNum.Text, txtLineNum.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error fetching " + ee.Message);
                return false;
            }
            if (dao == null)
            {
                MessageBox.Show("Sorry cant be found in the db ");
                return false;
            }

            txtPartNum.Text = dao.MaterialNum;
            txtPartRev.Text = dao.MaterialRev;

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
                MessageBox.Show("material Description error  " + ee.Message);
                txtDesc1.Text = "";
                return false;
            }

            txtWeight.Text = dao.GrossWeight + " " + dao.WeightUnit;
            txtSlNum.Text = dao.BatchNum + "-" + txtSlNum2.Text;
            //txtLineNum.Text = ;

            //generate QRCode
            doQRCode(dao.MaterialRev);


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
                return false;
            }

            doButtonClick();
            return true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            btnFetch.Enabled = false;
            btnPrint.Enabled = false;

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

            if (doClear())
            {
                reportViewer1.Clear();
                Thread.Sleep(1000);
                doGetMat();
            }

            MessageBox.Show("Fetched from server successfully ");

            btnFetch.Enabled = true;
            btnPrint.Enabled = true;
        }


        private static string ApmfgCString = @"Data Source=APMFGDBS001;Initial Catalog=MPM;User ID=iusr_server;Password=iusr";
        private bool doRemotePrint()
        {
            btnPrint.Enabled = false;
            btnFetch.Enabled = false;

            int affRows = 0;
            log.Info(" string = " + MyGlobal.getApmfgCString());
            using (SqlConnection cnn = new SqlConnection(ApmfgCString))
            {
                cnn.Open();
                log.Info(" doWifiPrinter  ");
                string error_code = "";
                string error_msg = "";

                using (SqlCommand cmd = new SqlCommand("MPM.HSP_PrintLogisticsPartLabels", cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        string json = string.Empty;// "[{\"QrMaterial\":\"100006488\",\"Material\":\"100006488\",\"MaterialDesc1\":\"PKR.HF 1.9653 TBG\",\"MaterialDesc2\":\"PCL REL..NX1\",\"SearialNo\":\"4443432 - 05\",\"Weights\":\"0.6 LB\"}]";
                        log.Info("Json = " + json);

                        MaterialObject mo = new MaterialObject()
                        {
                            DN = txtDNNum.Text,
                            DNL = txtLineNum.Text,
                            Material = txtPartNum.Text,
                            MaterialDesc1 = txtDesc2.Text,
                            MaterialDesc2 = txtDesc1.Text,
                            PartRev = txtPartRev.Text,
                            SearialNo = txtSlNum.Text,
                            Weights = txtWeight.Text
                        };
                        ArrayList al = new ArrayList();
                        al.Add(mo);
                        json = JsonConvert.SerializeObject(al);
                        log.Info("Json = " + json);
                        cmd.Parameters.Add(new SqlParameter("@Plant_CD", "2080"));
                        cmd.Parameters.Add(new SqlParameter("@Empl_Nbr", "00691364"));
                        cmd.Parameters.Add(new SqlParameter("@Prntr_Oid", 906));
                        cmd.Parameters.Add(new SqlParameter("@LabelSize", "12"));
                        cmd.Parameters.Add(new SqlParameter("@UpdateJson", json));
                        cmd.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.VarChar, 10));
                        cmd.Parameters.Add(new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 250));


                        // cmd.Parameters.Add("@ClientName", SqlDbType.VarChar, 100);
                        //cmd.Parameters["@ClientName"].Direction = ParameterDirection.Output;

                        cmd.Parameters["@ErrorCode"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;

                        affRows = cmd.ExecuteNonQuery();
                        log.Info("Affrows = " + affRows);

                        error_code = Convert.ToString(cmd.Parameters["@ErrorCode"].Value);
                        error_msg = Convert.ToString(cmd.Parameters["@ErrorMessage"].Value);

                        lblResult.Text = "Error code = " + error_code + ", error_msg = " + error_msg;

                        log.Info("Error code " + error_code + ", error_msg=" + error_msg + "\n");
                        return true;
                    }
                    catch (Exception ee)
                    {
                        log.Error("EE = " + ee.Message);
                    }
                }

                btnPrint.Enabled = true;
                btnFetch.Enabled = true;
            }

            return false;
        }


        private bool doClear()
        {
            txtPartNum.Text = "";
            txtDesc1.Text = "";
            txtDesc2.Text = "";
            txtSlNum.Text = "";
            txtWeight.Text = "";
            txtPartRev.Text = "";

            //
           
            return true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            doRemotePrint();
        }

        private void btnPageSetup_Click(object sender, EventArgs e)
        {

        }

        private void listAllPrinters()
        {
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                // this.listBox1.Items.Add(item.ToString());
                Console.WriteLine("Printer " + item.ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listAllPrinters();

            // myPrinters.SetDefaultPrinter();
        }

        //in list box change
        // string pname = this.listBox1.SelectedItem.ToString();
        // myPrinters.SetDefaultPrinter(pname);

        //set default printer
        public static class myPrinters
        {
            //[DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            doBtnClear();
        }

        private void doBtnClear()
        {
            doClear();
            txtDNNum.Text = "";
            txtLineNum.Text = "";
            txtSlNum2.Text = "";
            lblResult.Text = "";
        }

        private void doSelectPrint()
        {
            if (rdoAutoPrint.Checked)
            {
                panelManual.Visible = false;
                btnFetch.Enabled = true;
                btnPrint.Enabled = true;
            }
            else if (rdoManualPrint.Checked)
            {
                btnFetch.Enabled = false;
                btnPrint.Enabled = false;
                doBtnClear();
                panelManual.Visible = true;
            }
        }

        private void rdoManualPrint_CheckedChanged(object sender, EventArgs e)
        {
            doSelectPrint();
        }

        private void rdoAutoPrint_CheckedChanged(object sender, EventArgs e)
        {
            doSelectPrint();
        }

        private void btnManualPrint_Click(object sender, EventArgs e)
        {
            doRemotePrint();
        }

        private void FormLogistics_Load(object sender, EventArgs e)
        {

        }
    }
}
