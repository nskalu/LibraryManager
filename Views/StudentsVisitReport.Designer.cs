namespace LibraryManager.Views
{
    partial class StudentsVisitReport
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtDatefrom = new MetroFramework.Controls.MetroDateTime();
            this.txtdateTo = new MetroFramework.Controls.MetroDateTime();
            this.btnloadreport = new MetroFramework.Controls.MetroButton();
            this.htmlLabel1 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel2 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 192);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1045, 353);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtDatefrom
            // 
            this.txtDatefrom.Location = new System.Drawing.Point(144, 144);
            this.txtDatefrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDatefrom.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtDatefrom.Name = "txtDatefrom";
            this.txtDatefrom.Size = new System.Drawing.Size(265, 30);
            this.txtDatefrom.TabIndex = 1;
            // 
            // txtdateTo
            // 
            this.txtdateTo.Location = new System.Drawing.Point(495, 145);
            this.txtdateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdateTo.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtdateTo.Name = "txtdateTo";
            this.txtdateTo.Size = new System.Drawing.Size(265, 30);
            this.txtdateTo.TabIndex = 2;
            // 
            // btnloadreport
            // 
            this.btnloadreport.Location = new System.Drawing.Point(815, 144);
            this.btnloadreport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnloadreport.Name = "btnloadreport";
            this.btnloadreport.Size = new System.Drawing.Size(221, 39);
            this.btnloadreport.TabIndex = 3;
            this.btnloadreport.Text = "Load Report";
            this.btnloadreport.UseSelectable = true;
            this.btnloadreport.Click += new System.EventHandler(this.Btnloadreport_Click);
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScroll = true;
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(45, 25);
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel1.Location = new System.Drawing.Point(31, 144);
            this.htmlLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(79, 28);
            this.htmlLabel1.TabIndex = 4;
            this.htmlLabel1.Text = "From:";
            // 
            // htmlLabel2
            // 
            this.htmlLabel2.AutoScroll = true;
            this.htmlLabel2.AutoScrollMinSize = new System.Drawing.Size(30, 25);
            this.htmlLabel2.AutoSize = false;
            this.htmlLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel2.Location = new System.Drawing.Point(431, 148);
            this.htmlLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.htmlLabel2.Name = "htmlLabel2";
            this.htmlLabel2.Size = new System.Drawing.Size(48, 28);
            this.htmlLabel2.TabIndex = 5;
            this.htmlLabel2.Text = "To:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(863, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Download Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // StudentsVisitReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.htmlLabel2);
            this.Controls.Add(this.htmlLabel1);
            this.Controls.Add(this.btnloadreport);
            this.Controls.Add(this.txtdateTo);
            this.Controls.Add(this.txtDatefrom);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StudentsVisitReport";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Students Visit Report";
            this.Load += new System.EventHandler(this.StudentsVisitReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroDateTime txtDatefrom;
        private MetroFramework.Controls.MetroDateTime txtdateTo;
        private MetroFramework.Controls.MetroButton btnloadreport;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel1;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel2;
        private System.Windows.Forms.Button button1;
    }
}