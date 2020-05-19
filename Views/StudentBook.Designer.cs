namespace LibraryManager.Views
{
    partial class StudentBook
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gdvHistory = new System.Windows.Forms.DataGridView();
            this.cmbBooks = new MetroFramework.Controls.MetroComboBox();
            this.btnBorrow = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lblMatric = new MetroFramework.Controls.MetroLabel();
            this.lblName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.cmbDateToReturn = new MetroFramework.Controls.MetroDateTime();
            this.txtcriteria = new MetroFramework.Controls.MetroTextBox();
            this.btnsearch = new MetroFramework.Controls.MetroButton();
            this.lblID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvHistory)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gdvHistory);
            this.groupBox1.Location = new System.Drawing.Point(481, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(952, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Borrow History";
            // 
            // gdvHistory
            // 
            this.gdvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvHistory.Location = new System.Drawing.Point(8, 32);
            this.gdvHistory.Margin = new System.Windows.Forms.Padding(4);
            this.gdvHistory.Name = "gdvHistory";
            this.gdvHistory.Size = new System.Drawing.Size(927, 364);
            this.gdvHistory.TabIndex = 0;
            this.gdvHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GdvHistory_CellContentClick);
            this.gdvHistory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GdvHistory_DataBindingComplete);
            // 
            // cmbBooks
            // 
            this.cmbBooks.FormattingEnabled = true;
            this.cmbBooks.ItemHeight = 24;
            this.cmbBooks.Location = new System.Drawing.Point(33, 304);
            this.cmbBooks.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new System.Drawing.Size(408, 30);
            this.cmbBooks.TabIndex = 1;
            this.cmbBooks.UseSelectable = true;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(33, 432);
            this.btnBorrow.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(191, 34);
            this.btnBorrow.TabIndex = 2;
            this.btnBorrow.Text = "Borrow Book to Student";
            this.btnBorrow.UseSelectable = true;
            this.btnBorrow.Click += new System.EventHandler(this.BtnBorrow_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.lblMatric);
            this.metroPanel1.Controls.Add(this.lblName);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(31, 102);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(412, 123);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(29, 74);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(70, 20);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Matric No";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(29, 15);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(47, 20);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Name";
            // 
            // lblMatric
            // 
            this.lblMatric.AutoSize = true;
            this.lblMatric.Location = new System.Drawing.Point(183, 74);
            this.lblMatric.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatric.Name = "lblMatric";
            this.lblMatric.Size = new System.Drawing.Size(0, 0);
            this.lblMatric.TabIndex = 7;
            this.lblMatric.Click += new System.EventHandler(this.MetroLabel4_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(183, 16);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 0);
            this.lblName.TabIndex = 8;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(33, 273);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 20);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Select a Book..";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(31, 351);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(99, 20);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Date to Return";
            // 
            // cmbDateToReturn
            // 
            this.cmbDateToReturn.Location = new System.Drawing.Point(33, 380);
            this.cmbDateToReturn.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDateToReturn.MinimumSize = new System.Drawing.Size(0, 30);
            this.cmbDateToReturn.Name = "cmbDateToReturn";
            this.cmbDateToReturn.Size = new System.Drawing.Size(408, 30);
            this.cmbDateToReturn.TabIndex = 7;
            // 
            // txtcriteria
            // 
            // 
            // 
            // 
            this.txtcriteria.CustomButton.Image = null;
            this.txtcriteria.CustomButton.Location = new System.Drawing.Point(265, 2);
            this.txtcriteria.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtcriteria.CustomButton.Name = "";
            this.txtcriteria.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtcriteria.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtcriteria.CustomButton.TabIndex = 1;
            this.txtcriteria.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtcriteria.CustomButton.UseSelectable = true;
            this.txtcriteria.CustomButton.Visible = false;
            this.txtcriteria.Lines = new string[0];
            this.txtcriteria.Location = new System.Drawing.Point(33, 69);
            this.txtcriteria.Margin = new System.Windows.Forms.Padding(4);
            this.txtcriteria.MaxLength = 32767;
            this.txtcriteria.Name = "txtcriteria";
            this.txtcriteria.PasswordChar = '\0';
            this.txtcriteria.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtcriteria.SelectedText = "";
            this.txtcriteria.SelectionLength = 0;
            this.txtcriteria.SelectionStart = 0;
            this.txtcriteria.ShortcutsEnabled = true;
            this.txtcriteria.Size = new System.Drawing.Size(291, 28);
            this.txtcriteria.TabIndex = 9;
            this.txtcriteria.UseSelectable = true;
            this.txtcriteria.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtcriteria.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtcriteria.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcriteria_KeyUp);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(336, 69);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(100, 28);
            this.btnsearch.TabIndex = 10;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseSelectable = true;
            this.btnsearch.Click += new System.EventHandler(this.Btnsearch_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(389, 432);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 17);
            this.lblID.TabIndex = 11;
            // 
            // StudentBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 508);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtcriteria);
            this.Controls.Add(this.cmbDateToReturn);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.cmbBooks);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StudentBook";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Borrow a Book";
            this.Load += new System.EventHandler(this.StudentBook_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvHistory)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gdvHistory;
        private MetroFramework.Controls.MetroComboBox cmbBooks;
        private MetroFramework.Controls.MetroButton btnBorrow;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblMatric;
        private MetroFramework.Controls.MetroLabel lblName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroDateTime cmbDateToReturn;
        private MetroFramework.Controls.MetroTextBox txtcriteria;
        private MetroFramework.Controls.MetroButton btnsearch;
        private System.Windows.Forms.Label lblID;
    }
}