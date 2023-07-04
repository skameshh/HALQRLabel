
namespace HALQRLabel.Logistics
{
    partial class FormLogistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogistics));
            this.btnClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSlNum2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLineNum = new System.Windows.Forms.TextBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.txtDNNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label11 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoManualPrint = new System.Windows.Forms.RadioButton();
            this.rdoAutoPrint = new System.Windows.Forms.RadioButton();
            this.panelManual = new System.Windows.Forms.Panel();
            this.btnManualPrint = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPartRev = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPartNum = new System.Windows.Forms.TextBox();
            this.txtDesc2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSlNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panelManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(371, 829);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 74);
            this.btnClear.TabIndex = 50;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1306, 536);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 56);
            this.button1.TabIndex = 49;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(983, 829);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(316, 74);
            this.btnPrint.TabIndex = 36;
            this.btnPrint.Text = "Remote Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(926, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 22);
            this.label9.TabIndex = 47;
            this.label9.Text = "Sl Num";
            // 
            // txtSlNum2
            // 
            this.txtSlNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlNum2.Location = new System.Drawing.Point(916, 160);
            this.txtSlNum2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSlNum2.Name = "txtSlNum2";
            this.txtSlNum2.Size = new System.Drawing.Size(96, 48);
            this.txtSlNum2.TabIndex = 31;
            this.txtSlNum2.Text = "01";
            this.txtSlNum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(753, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 22);
            this.label4.TabIndex = 38;
            this.label4.Text = "DN Line Num";
            // 
            // txtLineNum
            // 
            this.txtLineNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineNum.Location = new System.Drawing.Point(756, 160);
            this.txtLineNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLineNum.Name = "txtLineNum";
            this.txtLineNum.Size = new System.Drawing.Size(118, 48);
            this.txtLineNum.TabIndex = 29;
            this.txtLineNum.Text = "10";
            this.txtLineNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFetch
            // 
            this.btnFetch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnFetch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFetch.ForeColor = System.Drawing.Color.White;
            this.btnFetch.Location = new System.Drawing.Point(1130, 149);
            this.btnFetch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(170, 72);
            this.btnFetch.TabIndex = 32;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = false;
            this.btnFetch.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtDNNum
            // 
            this.txtDNNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNNum.Location = new System.Drawing.Point(371, 160);
            this.txtDNNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDNNum.Name = "txtDNNum";
            this.txtDNNum.Size = new System.Drawing.Size(335, 48);
            this.txtDNNum.TabIndex = 28;
            this.txtDNNum.Text = "821658597";
            this.txtDNNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(368, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 22);
            this.label1.TabIndex = 27;
            this.label1.Text = "Scan DN Num";
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 48;
            this.reportViewer1.Location = new System.Drawing.Point(371, 264);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(928, 514);
            this.reportViewer1.TabIndex = 26;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.ZoomPercent = 200;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(382, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(844, 55);
            this.label11.TabIndex = 51;
            this.label11.Text = "QR Code Label for Part Identification";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(552, 846);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(55, 20);
            this.lblResult.TabIndex = 54;
            this.lblResult.Text = "Result";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoManualPrint);
            this.groupBox1.Controls.Add(this.rdoAutoPrint);
            this.groupBox1.Location = new System.Drawing.Point(20, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(250, 112);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // rdoManualPrint
            // 
            this.rdoManualPrint.AutoSize = true;
            this.rdoManualPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoManualPrint.Location = new System.Drawing.Point(25, 64);
            this.rdoManualPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoManualPrint.Name = "rdoManualPrint";
            this.rdoManualPrint.Size = new System.Drawing.Size(212, 36);
            this.rdoManualPrint.TabIndex = 1;
            this.rdoManualPrint.Text = "Manual Print";
            this.rdoManualPrint.UseVisualStyleBackColor = true;
            this.rdoManualPrint.CheckedChanged += new System.EventHandler(this.rdoManualPrint_CheckedChanged);
            // 
            // rdoAutoPrint
            // 
            this.rdoAutoPrint.AutoSize = true;
            this.rdoAutoPrint.Checked = true;
            this.rdoAutoPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAutoPrint.Location = new System.Drawing.Point(25, 20);
            this.rdoAutoPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoAutoPrint.Name = "rdoAutoPrint";
            this.rdoAutoPrint.Size = new System.Drawing.Size(175, 36);
            this.rdoAutoPrint.TabIndex = 0;
            this.rdoAutoPrint.TabStop = true;
            this.rdoAutoPrint.Text = "Auto Print";
            this.rdoAutoPrint.UseVisualStyleBackColor = true;
            this.rdoAutoPrint.CheckedChanged += new System.EventHandler(this.rdoAutoPrint_CheckedChanged);
            // 
            // panelManual
            // 
            this.panelManual.Controls.Add(this.btnManualPrint);
            this.panelManual.Controls.Add(this.label10);
            this.panelManual.Controls.Add(this.txtPartRev);
            this.panelManual.Controls.Add(this.label8);
            this.panelManual.Controls.Add(this.label7);
            this.panelManual.Controls.Add(this.pictureBox1);
            this.panelManual.Controls.Add(this.txtPartNum);
            this.panelManual.Controls.Add(this.txtDesc2);
            this.panelManual.Controls.Add(this.label6);
            this.panelManual.Controls.Add(this.txtSlNum);
            this.panelManual.Controls.Add(this.label5);
            this.panelManual.Controls.Add(this.txtWeight);
            this.panelManual.Controls.Add(this.label3);
            this.panelManual.Controls.Add(this.txtDesc1);
            this.panelManual.Controls.Add(this.label2);
            this.panelManual.Location = new System.Drawing.Point(16, 154);
            this.panelManual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelManual.Name = "panelManual";
            this.panelManual.Size = new System.Drawing.Size(345, 749);
            this.panelManual.TabIndex = 56;
            this.panelManual.Visible = false;
            // 
            // btnManualPrint
            // 
            this.btnManualPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualPrint.Location = new System.Drawing.Point(26, 658);
            this.btnManualPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnManualPrint.Name = "btnManualPrint";
            this.btnManualPrint.Size = new System.Drawing.Size(205, 74);
            this.btnManualPrint.TabIndex = 68;
            this.btnManualPrint.Text = "Manual Print";
            this.btnManualPrint.UseVisualStyleBackColor = true;
            this.btnManualPrint.Click += new System.EventHandler(this.btnManualPrint_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 22);
            this.label10.TabIndex = 67;
            this.label10.Text = "Part Rev :";
            // 
            // txtPartRev
            // 
            this.txtPartRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartRev.Location = new System.Drawing.Point(26, 146);
            this.txtPartRev.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPartRev.Name = "txtPartRev";
            this.txtPartRev.Size = new System.Drawing.Size(204, 35);
            this.txtPartRev.TabIndex = 66;
            this.txtPartRev.Text = "A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 22);
            this.label8.TabIndex = 65;
            this.label8.Text = "Part Num :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 545);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 22);
            this.label7.TabIndex = 64;
            this.label7.Text = "QR Code :";
            // 
            // txtPartNum
            // 
            this.txtPartNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNum.Location = new System.Drawing.Point(26, 62);
            this.txtPartNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPartNum.Name = "txtPartNum";
            this.txtPartNum.Size = new System.Drawing.Size(204, 35);
            this.txtPartNum.TabIndex = 62;
            this.txtPartNum.Text = "102182884";
            // 
            // txtDesc2
            // 
            this.txtDesc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc2.Location = new System.Drawing.Point(26, 320);
            this.txtDesc2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDesc2.Name = "txtDesc2";
            this.txtDesc2.Size = new System.Drawing.Size(300, 35);
            this.txtDesc2.TabIndex = 61;
            this.txtDesc2.Text = "PCL REL.. NX1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 22);
            this.label6.TabIndex = 60;
            this.label6.Text = "Descrption2 (max 20chars)";
            // 
            // txtSlNum
            // 
            this.txtSlNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlNum.Location = new System.Drawing.Point(26, 481);
            this.txtSlNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSlNum.Name = "txtSlNum";
            this.txtSlNum.Size = new System.Drawing.Size(204, 35);
            this.txtSlNum.TabIndex = 59;
            this.txtSlNum.Text = "4456610-05";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 455);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 22);
            this.label5.TabIndex = 58;
            this.label5.Text = "Sl Num:";
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(26, 401);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(204, 35);
            this.txtWeight.TabIndex = 57;
            this.txtWeight.Text = "10 LB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 22);
            this.label3.TabIndex = 56;
            this.label3.Text = "Weight";
            // 
            // txtDesc1
            // 
            this.txtDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc1.Location = new System.Drawing.Point(26, 229);
            this.txtDesc1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDesc1.Name = "txtDesc1";
            this.txtDesc1.Size = new System.Drawing.Size(300, 35);
            this.txtDesc1.TabIndex = 55;
            this.txtDesc1.Text = "PKR.HF1.9653 TBG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 22);
            this.label2.TabIndex = 54;
            this.label2.Text = "Descrption (max 20 chars)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(26, 568);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 918);
            this.Controls.Add(this.panelManual);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSlNum2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLineNum);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.txtDNNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Logistics";
            this.Load += new System.EventHandler(this.FormLogistics_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelManual.ResumeLayout(false);
            this.panelManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSlNum2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLineNum;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.TextBox txtDNNum;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoManualPrint;
        private System.Windows.Forms.RadioButton rdoAutoPrint;
        private System.Windows.Forms.Panel panelManual;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPartRev;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPartNum;
        private System.Windows.Forms.TextBox txtDesc2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSlNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnManualPrint;
    }
}