namespace LibraryManager.Views
{
    partial class BorrowReport
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
            this.htmlLabel2 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel1 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.btnloadreport = new MetroFramework.Controls.MetroButton();
            this.txtdateTo = new MetroFramework.Controls.MetroDateTime();
            this.txtDatefrom = new MetroFramework.Controls.MetroDateTime();
            this.gdvReport = new System.Windows.Forms.DataGridView();
            this.gdvdetails = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvdetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // htmlLabel2
            // 
            this.htmlLabel2.AutoScroll = true;
            this.htmlLabel2.AutoScrollMinSize = new System.Drawing.Size(30, 25);
            this.htmlLabel2.AutoSize = false;
            this.htmlLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel2.Location = new System.Drawing.Point(284, 108);
            this.htmlLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.htmlLabel2.Name = "htmlLabel2";
            this.htmlLabel2.Size = new System.Drawing.Size(48, 28);
            this.htmlLabel2.TabIndex = 11;
            this.htmlLabel2.Text = "To:";
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScroll = true;
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(45, 25);
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel1.Location = new System.Drawing.Point(32, 108);
            this.htmlLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(57, 28);
            this.htmlLabel1.TabIndex = 10;
            this.htmlLabel1.Text = "From:";
            // 
            // btnloadreport
            // 
            this.btnloadreport.Location = new System.Drawing.Point(516, 138);
            this.btnloadreport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnloadreport.Name = "btnloadreport";
            this.btnloadreport.Size = new System.Drawing.Size(141, 39);
            this.btnloadreport.TabIndex = 9;
            this.btnloadreport.Text = "Load Report";
            this.btnloadreport.UseSelectable = true;
            this.btnloadreport.Click += new System.EventHandler(this.Btnloadreport_Click);
            // 
            // txtdateTo
            // 
            this.txtdateTo.Location = new System.Drawing.Point(284, 144);
            this.txtdateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdateTo.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtdateTo.Name = "txtdateTo";
            this.txtdateTo.Size = new System.Drawing.Size(223, 30);
            this.txtdateTo.TabIndex = 8;
            // 
            // txtDatefrom
            // 
            this.txtDatefrom.Location = new System.Drawing.Point(31, 144);
            this.txtDatefrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDatefrom.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtDatefrom.Name = "txtDatefrom";
            this.txtDatefrom.Size = new System.Drawing.Size(229, 30);
            this.txtDatefrom.TabIndex = 7;
            // 
            // gdvReport
            // 
            this.gdvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvReport.Location = new System.Drawing.Point(13, 23);
            this.gdvReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gdvReport.Name = "gdvReport";
            this.gdvReport.Size = new System.Drawing.Size(617, 309);
            this.gdvReport.TabIndex = 6;
            this.gdvReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GdvReport_CellContentClick);
            // 
            // gdvdetails
            // 
            this.gdvdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvdetails.Location = new System.Drawing.Point(8, 23);
            this.gdvdetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gdvdetails.Name = "gdvdetails";
            this.gdvdetails.Size = new System.Drawing.Size(633, 315);
            this.gdvdetails.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gdvReport);
            this.groupBox1.Location = new System.Drawing.Point(19, 187);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(639, 338);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gdvdetails);
            this.groupBox2.Location = new System.Drawing.Point(681, 187);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(649, 353);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail Section";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1176, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "Print Statistics";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1176, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 33);
            this.button2.TabIndex = 16;
            this.button2.Text = "Print Report";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BorrowReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 554);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.htmlLabel2);
            this.Controls.Add(this.htmlLabel1);
            this.Controls.Add(this.btnloadreport);
            this.Controls.Add(this.txtdateTo);
            this.Controls.Add(this.txtDatefrom);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BorrowReport";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Student Book Borrow Report";
            ((System.ComponentModel.ISupportInitialize)(this.gdvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvdetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel2;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel1;
        private MetroFramework.Controls.MetroButton btnloadreport;
        private MetroFramework.Controls.MetroDateTime txtdateTo;
        private MetroFramework.Controls.MetroDateTime txtDatefrom;
        private System.Windows.Forms.DataGridView gdvReport;
        private System.Windows.Forms.DataGridView gdvdetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}