using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace LibraryManager.Views
{
    public partial class HomePage : MetroForm
    {
        public HomePage()
        { 
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        void getQRCode(string data, string dest)
        {
            BarcodeWriter wr = new BarcodeWriter();

            wr.Format = BarcodeFormat.QR_CODE;

            wr.Write(data).Save(dest);
        }
        Image getQRCode(string data )
        {
            BarcodeWriter wr = new BarcodeWriter();

            wr.Format = BarcodeFormat.QR_CODE;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            wr.Write(data).Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);

            Bitmap bmp = new Bitmap(ms);

            return bmp;

        }
        string readQRCode(string data, string source)

        {
            BarcodeReader reader = new BarcodeReader();

            var sourcebmp = (Bitmap)Bitmap.FromFile(source);

            var coderesult = reader.Decode(sourcebmp);

            return coderesult?.Text;


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent b = new AddStudent();
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Books b = new Books(new Models.LibraryManagerEntities());
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }

        private void StudentBorrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentBook b = new StudentBook(new Models.LibraryManagerEntities());
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }

        private void SubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsVisitReport b = new StudentsVisitReport(new Models.LibraryManagerEntities());
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }

        private void ExistingBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookReport b = new BookReport(new Models.LibraryManagerEntities());
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }

        private void BooksBorrowedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowReport b = new BorrowReport(new Models.LibraryManagerEntities());
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }

        private void AddNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser b = new NewUser(new Models.LibraryManagerEntities());
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }

        private void studentsVisitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsVisitReport b = new StudentsVisitReport(new Models.LibraryManagerEntities());
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }

        private void booksReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookReport b = new BookReport(new Models.LibraryManagerEntities());
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }

        private void bookBorrowedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowReport b = new BorrowReport(new Models.LibraryManagerEntities());
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyReport b = new DailyReport(new Models.LibraryManagerEntities());
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
        }
    }
}
