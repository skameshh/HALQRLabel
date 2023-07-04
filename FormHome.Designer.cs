
namespace HALQRLabel
{
    partial class FormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnICIMachining = new System.Windows.Forms.Button();
            this.btnLogis = new System.Windows.Forms.Button();
            this.btnGC = new System.Windows.Forms.Button();
            this.btnICIAssebly = new System.Windows.Forms.Button();
            this.btnGCAssembly = new System.Windows.Forms.Button();
            this.btnLogisLocal = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnICIMachining, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnLogis, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnGC, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnICIAssebly, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGCAssembly, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnLogisLocal, 2, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(120, 82);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 374);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnICIMachining
            // 
            this.btnICIMachining.BackColor = System.Drawing.Color.Navy;
            this.btnICIMachining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnICIMachining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnICIMachining.ForeColor = System.Drawing.Color.White;
            this.btnICIMachining.Location = new System.Drawing.Point(3, 135);
            this.btnICIMachining.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnICIMachining.Name = "btnICIMachining";
            this.btnICIMachining.Size = new System.Drawing.Size(301, 102);
            this.btnICIMachining.TabIndex = 3;
            this.btnICIMachining.Text = "ICI Machining";
            this.btnICIMachining.UseVisualStyleBackColor = false;
            this.btnICIMachining.Click += new System.EventHandler(this.btnICIMachining_Click);
            // 
            // btnLogis
            // 
            this.btnLogis.BackColor = System.Drawing.Color.Navy;
            this.btnLogis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogis.ForeColor = System.Drawing.Color.White;
            this.btnLogis.Location = new System.Drawing.Point(3, 270);
            this.btnLogis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogis.Name = "btnLogis";
            this.btnLogis.Size = new System.Drawing.Size(301, 100);
            this.btnLogis.TabIndex = 2;
            this.btnLogis.Text = "Logistics (WIFI)";
            this.btnLogis.UseVisualStyleBackColor = false;
            this.btnLogis.Click += new System.EventHandler(this.btnLogis_Click);
            // 
            // btnGC
            // 
            this.btnGC.BackColor = System.Drawing.Color.Navy;
            this.btnGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGC.ForeColor = System.Drawing.Color.White;
            this.btnGC.Location = new System.Drawing.Point(3, 4);
            this.btnGC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGC.Name = "btnGC";
            this.btnGC.Size = new System.Drawing.Size(301, 98);
            this.btnGC.TabIndex = 1;
            this.btnGC.Text = "GC Machining";
            this.btnGC.UseVisualStyleBackColor = false;
            this.btnGC.Click += new System.EventHandler(this.btnGC_Click);
            // 
            // btnICIAssebly
            // 
            this.btnICIAssebly.BackColor = System.Drawing.Color.Navy;
            this.btnICIAssebly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnICIAssebly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnICIAssebly.ForeColor = System.Drawing.Color.White;
            this.btnICIAssebly.Location = new System.Drawing.Point(332, 4);
            this.btnICIAssebly.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnICIAssebly.Name = "btnICIAssebly";
            this.btnICIAssebly.Size = new System.Drawing.Size(301, 98);
            this.btnICIAssebly.TabIndex = 0;
            this.btnICIAssebly.Text = "ICI Assembly";
            this.btnICIAssebly.UseVisualStyleBackColor = false;
            this.btnICIAssebly.Click += new System.EventHandler(this.btnICIAssebly_Click);
            // 
            // btnGCAssembly
            // 
            this.btnGCAssembly.BackColor = System.Drawing.Color.Navy;
            this.btnGCAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGCAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGCAssembly.ForeColor = System.Drawing.Color.White;
            this.btnGCAssembly.Location = new System.Drawing.Point(332, 135);
            this.btnGCAssembly.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGCAssembly.Name = "btnGCAssembly";
            this.btnGCAssembly.Size = new System.Drawing.Size(301, 102);
            this.btnGCAssembly.TabIndex = 4;
            this.btnGCAssembly.Text = "GC Assembly";
            this.btnGCAssembly.UseVisualStyleBackColor = false;
            // 
            // btnLogisLocal
            // 
            this.btnLogisLocal.BackColor = System.Drawing.Color.Crimson;
            this.btnLogisLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogisLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogisLocal.ForeColor = System.Drawing.Color.White;
            this.btnLogisLocal.Location = new System.Drawing.Point(332, 270);
            this.btnLogisLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogisLocal.Name = "btnLogisLocal";
            this.btnLogisLocal.Size = new System.Drawing.Size(301, 100);
            this.btnLogisLocal.TabIndex = 5;
            this.btnLogisLocal.Text = "Logistics (Local)";
            this.btnLogisLocal.UseVisualStyleBackColor = false;
            this.btnLogisLocal.Click += new System.EventHandler(this.btnLogisLocal_Click);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lable Print-v2.2";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLogis;
        private System.Windows.Forms.Button btnGC;
        private System.Windows.Forms.Button btnICIAssebly;
        private System.Windows.Forms.Button btnICIMachining;
        private System.Windows.Forms.Button btnGCAssembly;
        private System.Windows.Forms.Button btnLogisLocal;
    }
}