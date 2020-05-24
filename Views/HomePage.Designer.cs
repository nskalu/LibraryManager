namespace LibraryManager.Views
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.existingBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowABookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentBorrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksBorrowedReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsVisitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookBorrowedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.bookToolStripMenuItem,
            this.borrowABookToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(27, 74);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(846, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.subToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.fileToolStripMenuItem.Text = "Student";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.newToolStripMenuItem.Text = "Add New Student";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // subToolStripMenuItem
            // 
            this.subToolStripMenuItem.Name = "subToolStripMenuItem";
            this.subToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.subToolStripMenuItem.Text = "Students Visit Report";
            this.subToolStripMenuItem.Click += new System.EventHandler(this.SubToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewBookToolStripMenuItem,
            this.existingBookToolStripMenuItem});
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.bookToolStripMenuItem.Text = "Book";
            // 
            // addNewBookToolStripMenuItem
            // 
            this.addNewBookToolStripMenuItem.Name = "addNewBookToolStripMenuItem";
            this.addNewBookToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.addNewBookToolStripMenuItem.Text = "Add New Book";
            this.addNewBookToolStripMenuItem.Click += new System.EventHandler(this.AddNewBookToolStripMenuItem_Click);
            // 
            // existingBookToolStripMenuItem
            // 
            this.existingBookToolStripMenuItem.Name = "existingBookToolStripMenuItem";
            this.existingBookToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.existingBookToolStripMenuItem.Text = "Existing Book";
            this.existingBookToolStripMenuItem.Click += new System.EventHandler(this.ExistingBookToolStripMenuItem_Click);
            // 
            // borrowABookToolStripMenuItem
            // 
            this.borrowABookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentBorrowToolStripMenuItem,
            this.booksBorrowedReportToolStripMenuItem});
            this.borrowABookToolStripMenuItem.Name = "borrowABookToolStripMenuItem";
            this.borrowABookToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.borrowABookToolStripMenuItem.Text = "Borrow A Book";
            // 
            // studentBorrowToolStripMenuItem
            // 
            this.studentBorrowToolStripMenuItem.Name = "studentBorrowToolStripMenuItem";
            this.studentBorrowToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.studentBorrowToolStripMenuItem.Text = "Student Borrow";
            this.studentBorrowToolStripMenuItem.Click += new System.EventHandler(this.StudentBorrowToolStripMenuItem_Click);
            // 
            // booksBorrowedReportToolStripMenuItem
            // 
            this.booksBorrowedReportToolStripMenuItem.Name = "booksBorrowedReportToolStripMenuItem";
            this.booksBorrowedReportToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.booksBorrowedReportToolStripMenuItem.Text = "Books Borrowed Report";
            this.booksBorrowedReportToolStripMenuItem.Click += new System.EventHandler(this.BooksBorrowedReportToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsVisitToolStripMenuItem,
            this.booksReportToolStripMenuItem,
            this.bookBorrowedToolStripMenuItem,
            this.dailyToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // studentsVisitToolStripMenuItem
            // 
            this.studentsVisitToolStripMenuItem.Name = "studentsVisitToolStripMenuItem";
            this.studentsVisitToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.studentsVisitToolStripMenuItem.Text = "Students Visit";
            this.studentsVisitToolStripMenuItem.Click += new System.EventHandler(this.studentsVisitToolStripMenuItem_Click);
            // 
            // booksReportToolStripMenuItem
            // 
            this.booksReportToolStripMenuItem.Name = "booksReportToolStripMenuItem";
            this.booksReportToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.booksReportToolStripMenuItem.Text = "Books Report";
            this.booksReportToolStripMenuItem.Click += new System.EventHandler(this.booksReportToolStripMenuItem_Click);
            // 
            // bookBorrowedToolStripMenuItem
            // 
            this.bookBorrowedToolStripMenuItem.Name = "bookBorrowedToolStripMenuItem";
            this.bookBorrowedToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.bookBorrowedToolStripMenuItem.Text = "Book Borrowed";
            this.bookBorrowedToolStripMenuItem.Click += new System.EventHandler(this.bookBorrowedToolStripMenuItem_Click);
            // 
            // dailyToolStripMenuItem
            // 
            this.dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            this.dailyToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.dailyToolStripMenuItem.Text = "Daily";
            this.dailyToolStripMenuItem.Click += new System.EventHandler(this.dailyToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewUserToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.AddNewUserToolStripMenuItem_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryManager.Properties.Resources.f372aa5f_6d92_4027_ab8a_b88fed7327c4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(900, 567);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HomePage";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "HomePage";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem existingBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrowABookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentBorrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem booksBorrowedReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsVisitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem booksReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookBorrowedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyToolStripMenuItem;
    }
}