using LibraryManager.Models;
using LibraryManager.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace LibraryManager.Views
{
    public partial class IDCardViewer : Form
    {
        private string dirname = Guid.NewGuid().ToString();
        public IDCardViewer(Student student)
        {
            InitializeComponent();
            getBarCode(student.qrcode);
            LoadReport(student);
        }

        private void IDCardViewer_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        void getBarCode(string data)
        {
            BarcodeWriter wr = new BarcodeWriter();

            wr.Format = BarcodeFormat.CODE_93;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            wr.Write(data).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //create directory to save the image
           
            if (!Directory.Exists(@"C:\" + dirname))
            {
                Directory.CreateDirectory(@"C:\"+dirname);
            }
            
            Bitmap bmp = new Bitmap(ms);
            bmp.Save(@"C:\"+dirname + "\\" + dirname + ".jpg");

            //return bmp;

        }

        private void LoadReport(Student student)
        {
            try
            {
                ReportParameter rp = new ReportParameter("Name", $"{student.LastName} {student.FirstName} {student.MiddleName}");
                ReportParameter rps = new ReportParameter("MatricNo", student.MatricNo);
                ReportParameter pic = new ReportParameter("Barcode", new Uri(@"C:\" + dirname + "\\" + dirname + ".jpg").AbsoluteUri);
                reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rps, pic });
                reportViewer1.Visible = true;
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();

                Global.GlobalVar = dirname;
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading the report viewer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
