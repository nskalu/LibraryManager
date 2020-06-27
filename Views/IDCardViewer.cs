using LibraryManager.Models;
using Microsoft.Reporting.WinForms;
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
    public partial class IDCardViewer : Form
    {
        public IDCardViewer(Student student)
        {
            InitializeComponent();
            //pictureBox1.Image = getQRCode(student.qrcode);
            LoadReport(student);
        }

        private void IDCardViewer_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        Image getBarCode(string data)
        {
            BarcodeWriter wr = new BarcodeWriter();

            wr.Format = BarcodeFormat.CODE_93;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            wr.Write(data).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            Bitmap bmp = new Bitmap(ms);

            return bmp;

        }

        private void LoadReport(Student student)
        {
            try
            {

                ReportParameter rp = new ReportParameter("Name", $"{student.LastName} {student.FirstName} {student.MiddleName}");
                ReportParameter rps = new ReportParameter("MatricNo", student.MatricNo);
                ReportParameter pic = new ReportParameter("Barcode", getBarCode(student.qrcode));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rps });
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pic });
                reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.Visible = true;
                reportViewer1.ProcessingMode = ProcessingMode.Local;
              
                    //ReportDataSource rds = new ReportDataSource(tableName, dt2);
                    //reportViewer1.LocalReport.DataSources.Clear();
                    //reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading the report viewer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
