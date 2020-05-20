namespace LibraryManager.Views
{
    partial class BookReport
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
            this.ddlSearchCriteria = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cmbFrom = new MetroFramework.Controls.MetroDateTime();
            this.cmbTo = new MetroFramework.Controls.MetroDateTime();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 170);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1045, 375);
            this.dataGridView1.TabIndex = 1;
            // 
            // ddlSearchCriteria
            // 
            this.ddlSearchCriteria.FormattingEnabled = true;
            this.ddlSearchCriteria.ItemHeight = 24;
            this.ddlSearchCriteria.Items.AddRange(new object[] {
            "Available By Category",
            "Highest Borrowed "});
            this.ddlSearchCriteria.Location = new System.Drawing.Point(7, 107);
            this.ddlSearchCriteria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlSearchCriteria.Name = "ddlSearchCriteria";
            this.ddlSearchCriteria.Size = new System.Drawing.Size(229, 30);
            this.ddlSearchCriteria.TabIndex = 1;
            this.ddlSearchCriteria.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(544, 74);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(44, 20);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "From:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(7, 74);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(102, 20);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Search Criteria:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(857, 80);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(26, 20);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "To:";
            // 
            // cmbFrom
            // 
            this.cmbFrom.Location = new System.Drawing.Point(360, 107);
            this.cmbFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbFrom.MinimumSize = new System.Drawing.Size(0, 30);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(265, 30);
            this.cmbFrom.TabIndex = 2;
            // 
            // cmbTo
            // 
            this.cmbTo.Location = new System.Drawing.Point(655, 107);
            this.cmbTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTo.MinimumSize = new System.Drawing.Size(0, 30);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(265, 30);
            this.cmbTo.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(936, 105);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "Load Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(820, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 27);
            this.button2.TabIndex = 5;
            this.button2.Text = "Download Report";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // BookReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.ddlSearchCriteria);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BookReport";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Books In Library";
            this.Load += new System.EventHandler(this.BookReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroComboBox ddlSearchCriteria;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime cmbFrom;
        private MetroFramework.Controls.MetroDateTime cmbTo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}