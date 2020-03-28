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
            this.groupBox1.Location = new System.Drawing.Point(361, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 333);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Borrow History";
            // 
            // gdvHistory
            // 
            this.gdvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvHistory.Location = new System.Drawing.Point(6, 31);
            this.gdvHistory.Name = "gdvHistory";
            this.gdvHistory.Size = new System.Drawing.Size(410, 296);
            this.gdvHistory.TabIndex = 0;
            // 
            // cmbBooks
            // 
            this.cmbBooks.FormattingEnabled = true;
            this.cmbBooks.ItemHeight = 23;
            this.cmbBooks.Location = new System.Drawing.Point(25, 247);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new System.Drawing.Size(307, 29);
            this.cmbBooks.TabIndex = 1;
            this.cmbBooks.UseSelectable = true;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(25, 351);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(143, 28);
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
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 83);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(309, 100);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(22, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(68, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Matric No";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(22, 12);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(45, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Name";
            // 
            // lblMatric
            // 
            this.lblMatric.AutoSize = true;
            this.lblMatric.Location = new System.Drawing.Point(137, 60);
            this.lblMatric.Name = "lblMatric";
            this.lblMatric.Size = new System.Drawing.Size(0, 0);
            this.lblMatric.TabIndex = 7;
            this.lblMatric.Click += new System.EventHandler(this.MetroLabel4_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(137, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 0);
            this.lblName.TabIndex = 8;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(25, 222);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(94, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Select a Book..";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 285);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(94, 19);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Date to Return";
            // 
            // cmbDateToReturn
            // 
            this.cmbDateToReturn.Location = new System.Drawing.Point(25, 309);
            this.cmbDateToReturn.MinimumSize = new System.Drawing.Size(0, 29);
            this.cmbDateToReturn.Name = "cmbDateToReturn";
            this.cmbDateToReturn.Size = new System.Drawing.Size(307, 29);
            this.cmbDateToReturn.TabIndex = 7;
            // 
            // txtcriteria
            // 
            // 
            // 
            // 
            this.txtcriteria.CustomButton.Image = null;
            this.txtcriteria.CustomButton.Location = new System.Drawing.Point(196, 1);
            this.txtcriteria.CustomButton.Name = "";
            this.txtcriteria.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtcriteria.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtcriteria.CustomButton.TabIndex = 1;
            this.txtcriteria.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtcriteria.CustomButton.UseSelectable = true;
            this.txtcriteria.CustomButton.Visible = false;
            this.txtcriteria.Lines = new string[0];
            this.txtcriteria.Location = new System.Drawing.Point(25, 56);
            this.txtcriteria.MaxLength = 32767;
            this.txtcriteria.Name = "txtcriteria";
            this.txtcriteria.PasswordChar = '\0';
            this.txtcriteria.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtcriteria.SelectedText = "";
            this.txtcriteria.SelectionLength = 0;
            this.txtcriteria.SelectionStart = 0;
            this.txtcriteria.ShortcutsEnabled = true;
            this.txtcriteria.Size = new System.Drawing.Size(218, 23);
            this.txtcriteria.TabIndex = 9;
            this.txtcriteria.UseSelectable = true;
            this.txtcriteria.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtcriteria.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(252, 56);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 10;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseSelectable = true;
            this.btnsearch.Click += new System.EventHandler(this.Btnsearch_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(292, 351);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 13);
            this.lblID.TabIndex = 11;
            // 
            // StudentBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 413);
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
            this.Name = "StudentBook";
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