using BarcodeLib;
using LibraryManager.Models;
using LibraryManager.Shared;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using ZXing;

namespace LibraryManager.Views
{
    public partial class NewIdCardViewer : MetroForm
    {
        public NewIdCardViewer(Student student, bool action, string installedPrinter)
        {
            InitializeComponent();
            getBarCode(student.qrcode);
            //GenerateBarCodeWithBarcodeLib(student.qrcode);
            LoadReport(student, action, installedPrinter);
        }
        private string dirname = Guid.NewGuid().ToString();
        private PrintDocument printdoc;
        private int m_currentPageIndex;
        public IList<Stream> m_streams;
        bool bProcessingPages = true;

        void getBarCode(string data)
        {
            BarcodeWriter wr = new BarcodeWriter();
            Color forecolor = Color.Black;

            wr.Format = BarcodeFormat.CODE_93;

            MemoryStream ms = new MemoryStream();

            wr.Write(data).Save(ms, ImageFormat.Jpeg);
            //create directory to save the image

            if (!Directory.Exists(@"C:\" + dirname))
            {
                Directory.CreateDirectory(@"C:\" + dirname);
            }

            Bitmap bmp = new Bitmap(ms);
            bmp.Save(@"C:\" + dirname + "\\" + dirname + "1.jpg");

            //return bmp;

        }
        void GenerateBarCodeWithBarcodeLib(string data)
        {
            try
            {
                Barcode barcode = new Barcode();
                Color forecolor = Color.Black;
                Color backcolor = Color.Transparent;
                Image img = barcode.Encode(TYPE.CODE93, data, forecolor, backcolor);
                using (var ms = new MemoryStream())
                {
                    //img.Save(ms, img.RawFormat);
                    Bitmap bmp = new Bitmap(img);
                    //create directory to save the image

                    if (!Directory.Exists(@"C:\" + dirname))
                    {
                        Directory.CreateDirectory(@"C:\" + dirname);
                    }

                    bmp.Save(@"C:\" + dirname + "\\" + dirname + ".jpg");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while printing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //void getBarCode1(string data)
        //{
        //    string Barcode = data;

        //    using (Bitmap bitmap = new Bitmap(350, 220))
        //    {
        //        bitmap.SetResolution(240, 240);
        //        using (Graphics graphics = Graphics.FromImage(bitmap))
        //        {
        //            Font font = new Font("IDAutomationHC39M", 10, FontStyle.Regular, GraphicsUnit.Point);

        //            graphics.Clear(Color.White);
        //            StringFormat stringformat = new StringFormat(StringFormatFlags.NoWrap);
        //            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        //            graphics.TextContrast = 10;
        //            SolidBrush black = new SolidBrush(Color.Black);
        //            SolidBrush white = new SolidBrush(Color.White);
        //            PointF TextPosition = new PointF(45F, 10F);
        //            SizeF TextSize = graphics.MeasureString(Barcode, font, TextPosition, stringformat);
        //            PointF pointPrice = new PointF(90f, 125f);
        //            Font newfont2 = new Font("Cambria", 8, FontStyle.Regular, GraphicsUnit.Point);
        //            Font newfont3 = new Font("Arial Black", 10, FontStyle.Regular, GraphicsUnit.Point);
        //            PointF pointPname = new PointF(200f, 170f);
        //            PointF pointBcode = new PointF(35f, 170f);
        //            graphics.DrawString("" + Barcode + "", newfont2, black, pointBcode);
        //            if (TextSize.Width > bitmap.Width)
        //            {
        //                float ScaleFactor = (bitmap.Width - (TextPosition.X / 2)) / TextSize.Width;
        //                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //                graphics.ScaleTransform(ScaleFactor, ScaleFactor);
        //            }

        //            graphics.DrawString(Barcode, font, new SolidBrush(Color.Black), TextPosition, StringFormat.GenericTypographic);

        //            bitmap.Save(@"barcode.png", ImageFormat.Png);
        //            this.pictureBox1.Image = (Bitmap)bitmap.Clone();
        //            if (!Directory.Exists(@"C:\" + dirname))
        //            {
        //                Directory.CreateDirectory(@"C:\" + dirname);
        //            }

        //            bitmap.Save(@"C:\" + dirname + "\\" + dirname + ".jpg", ImageFormat.Png);

        //            font.Dispose();
        //        }
        //    }

        //}
        private void LoadReport(Student student, bool action, string InstalledIDCardPrinter)
        {
            try
            {
                reportViewer1.Reset();
#if DEBUG
                reportViewer1.LocalReport.ReportPath = @"..\..\Reports\newIDCard2.rdlc";
#else
    reportViewer1.LocalReport.ReportPath = @"C:\Program Files (x86)\Reports\newIDCard2.rdlc"; 
#endif
                ReportParameter rp = new ReportParameter("Name", $"{student.LastName} {student.FirstName} {student.MiddleName}");
                ReportParameter rps = new ReportParameter("MatricNo", student.MatricNo);
                ReportParameter pic = new ReportParameter("Barcode", new Uri(@"C:\" + dirname + "\\" + dirname + ".jpg").AbsoluteUri);
                reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rps, pic });
                reportViewer1.Visible = true;
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
                reportViewer1.ShowExportButton = false;
                Global.GlobalVar.Add(dirname);
               
                if (action)
                {
                    print_microsoft_report(reportViewer1.LocalReport, true, InstalledIDCardPrinter);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading the report viewer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void print_microsoft_report(LocalReport report, bool islandscap = false, string printer_name = null)
        {
            printdoc = new PrintDocument();
            if (printer_name != null)
                printdoc.PrinterSettings.PrinterName = printer_name;
            if (!printdoc.PrinterSettings.IsValid)
                throw new Exception("Cannot find the specified printer");
            else
            {
                PaperSize ps;
                ps = printdoc.PrinterSettings.DefaultPageSettings.PaperSize;
                // Dim ps As New PaperSize("Custom", page_width, page_height)
                printdoc.DefaultPageSettings.PaperSize = ps;
                printdoc.DefaultPageSettings.Landscape = islandscap;
                Export(report);
                Print();
            }
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            printdoc.PrintPage += PrintPage;
            printdoc.BeginPrint += BeginPrint;

            m_currentPageIndex = 0;
            printdoc.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            bProcessingPages = true;
            m_currentPageIndex += 1;
            while ((bProcessingPages))
            {
                bool isPageInRange = (m_currentPageIndex >= ev.PageSettings.PrinterSettings.FromPage);
                isPageInRange = isPageInRange & (m_currentPageIndex <= ev.PageSettings.PrinterSettings.ToPage);

                if ((isPageInRange))
                {
                    try
                    {
                        int pagetoprint = m_currentPageIndex - 1;
                        Metafile pageImage = new Metafile(m_streams[pagetoprint]);

                        Rectangle adjustedRect = new Rectangle(ev.PageBounds.Left - System.Convert.ToInt32(ev.PageSettings.HardMarginX), ev.PageBounds.Top - System.Convert.ToInt32(ev.PageSettings.HardMarginY), ev.PageBounds.Width, ev.PageBounds.Height);

                        ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

                        ev.Graphics.DrawImage(pageImage, adjustedRect);
                        ev.HasMorePages = (pagetoprint < m_streams.Count);
                    }
                    catch (Exception ex)
                    {
                        ev.HasMorePages = false;
                        bProcessingPages = false;
                    }
                }
                bProcessingPages = false;
            }
        }

        private void BeginPrint(object sender, PrintEventArgs e)
        {
            m_currentPageIndex = 0;
            var p = (PrintDocument)sender;
            p.PrinterSettings.PrintRange = PrintRange.SomePages;
            p.PrinterSettings.FromPage = 1;
            p.PrinterSettings.ToPage = 2;

        }

        private void Export(LocalReport report)
        {
            int w;
            int h;
            if (printdoc.DefaultPageSettings.Landscape == true)
            {
                w = printdoc.DefaultPageSettings.PaperSize.Height;
                h = printdoc.DefaultPageSettings.PaperSize.Width;
            }
            else
            {
                w = printdoc.DefaultPageSettings.PaperSize.Width;
                h = printdoc.DefaultPageSettings.PaperSize.Height;
            }
            string deviceInfo = "<DeviceInfo>" + "<OutputFormat>EMF</OutputFormat>" + "<PageWidth>" + w / (double)100 + "in</PageWidth>" + "<PageHeight>" + h / (double)100 + "in</PageHeight>" + "<MarginTop>0.0in</MarginTop>" + "<MarginLeft>0.0in</MarginLeft>" + "<MarginRight>0.0in</MarginRight>" + "<MarginBottom>0.0in</MarginBottom>" + "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private Stream CreateStream(string name, string fileNameExtension, System.Text.Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
    }
}
