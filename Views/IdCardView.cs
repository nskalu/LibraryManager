using LibraryManager.Models;
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
    public partial class IdCardView : Form
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
    }
}
