using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALQRLabel
{
    public partial class FormPrint : Form
    {
        public FormPrint()
        {
            InitializeComponent();
        }


        private void doPrint()
        {
            Form2 frm = new Form2();
            frm.Visible = true;
        }

        //https://www.youtube.com/watch?v=cFvo48Ix_Xc
        private void button1_Click(object sender, EventArgs e)
        {
            doPrint();
        }


        private void xprint()
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics graphics = panel.CreateGraphics();
            Size size = this.ClientSize;
            bitmap = new Bitmap(size.Width, size.Height, graphics);

            graphics = Graphics.FromImage(bitmap);

            Point point = PointToScreen(panel.Location);

            graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        Bitmap bitmap;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
