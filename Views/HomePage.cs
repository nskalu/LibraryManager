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
            metroProgressSpinner1.Visible = false;
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
            metroProgressSpinner1.Visible = true;
            AddStudent b = new AddStudent();
            b.MdiParent = this;
            b.StartPosition = FormStartPosition.CenterScreen;
            b.Show();
            metroProgressSpinner1.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        // Image qr=    getQRCode(textBox1.Text);
        //    pictureBox1.Image = qr;
        //}
    }
}
