using BarcodeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager.Views
{
    public partial class BarcodeCheck : Form
    {
        Bitmap memoryImage;
        public BarcodeCheck()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();
            Color forecolor = Color.Black;
            Color backcolor = Color.Transparent;
            Image img = barcode.Encode(TYPE.CODE39, textBox1.Text, forecolor, backcolor, (int)(pictureBox1.Width * 0.8), (int)(pictureBox1.Height * 0.8));
            pictureBox1.Image = img;

          
        }

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }
    }
}
