using LibraryManager.Models;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace LibraryManager.Views
{
    public partial class IdCardView : MetroForm
    {
        public IdCardView(Student student)
        {
            InitializeComponent();
            lblName.Text = $"{student.LastName} {student.FirstName} {student.MiddleName}";
            lblMatric.Text = student.MatricNo;
            lblPhone.Text = student.PhoneNumber;
            pictureBox1.Image = getQRCode(student.qrcode);
        }
        Image getQRCode(string data)
        {
            BarcodeWriter wr = new BarcodeWriter();

            wr.Format = BarcodeFormat.QR_CODE;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            wr.Write(data).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            Bitmap bmp = new Bitmap(ms);

            return bmp;

        }
        Bitmap memoryImage;
        private void button1_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }
       
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
