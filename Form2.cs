using HALQRLabel.DB;
using Microsoft.Reporting.WinForms;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALQRLabel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            getDefaultPrinter();
        }

        private void getDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            lblDefaultPrinter.Text =  "Printer: " +settings.PrinterName;
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
                string rprm_txt_dn_num = "DN:"+txtDNNum.Text +" | DN LINE:"+ txtLineNum.Text;
                string rprm_txt_desc1 = txtDesc1.Text;
                string rprm_txt_desc2 = txtDesc2.Text;
                string rprm_txt_part_num = txtPartNum.Text;
                string rptm_txt_weight = ""+txtWeight.Text;
                string rprm_txt_sl_num = "" + txtSlNum.Text;


                string pat = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/qr.JPG").AbsoluteUri;
                Console.WriteLine("Path = " + pat);


                string pat2 = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/qra1.jpg").AbsoluteUri; ;
                string rprm_txt_img_path = @""+ pat2;// "c:/temp/qr.JPG";

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
            }catch(Exception ee)
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
            QR_Text =   txtSlNum.Text + COMMA + txtPartNum.Text + COMMA + rev + COMMA + txtDNNum.Text + COMMA + txtLineNum.Text
                + COMMA + txtWeight.Text + COMMA + QR_REV;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QR_Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBox1.Image = qrCodeImage;

            Console.WriteLine("QR Generated successfully ");
        }


        private void doGetMat()
        {
            MatDao dao = null;
            try
            {
                  dao = DBUtils.getMaterial(txtDNNum.Text, txtLineNum.Text);
            }catch(Exception ee)
            {
                MessageBox.Show("Error fetching "+ee.Message);
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
            }catch(Exception ee)
            {
                MessageBox.Show("material Description error  "+ee.Message);
                txtDesc1.Text = "";
                return;
            }

            txtWeight.Text = dao.GrossWeight +" " + dao.WeightUnit;
            txtSlNum.Text = dao.BatchNum +"-" + txtSlNum2.Text;
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
                return;
            }

            doButtonClick();
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

            if (doClear())
            {
                reportViewer1.Clear();
                Thread.Sleep(1000);
                doGetMat();
            }          

           // doQRCode();

          
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
             
            reportViewer1.PrintDialog();
        }

        private void btnPageSetup_Click(object sender, EventArgs e)
        {
            reportViewer1.PageSetupDialog();
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
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDNNum.Text = "";
            txtLineNum.Text = "";
            txtSlNum2.Text = "";
        }
    }
}
