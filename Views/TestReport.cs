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
using LibraryManager.Datasets;
using LibraryManager.Models;

namespace LibraryManager.Views
{
    public partial class TestReport : Form
    {
        private readonly LibraryManagerEntities ctx;
        public TestReport(LibraryManagerEntities _ctx)
        {
            InitializeComponent();
        }

        private void TestReport_Load(object sender, EventArgs e)
        {
            Library2 lib = new Library2();
        

            DataTable dt = new DataTable();
           
                dt.Columns.Add("Title");
                dt.Columns.Add("Author");
                dt.Columns.Add("ISBN");
            
            DataRow row;
         
                row = dt.Rows.Add();
                row[0] = "Azure Intro";
                row[1] = "Bill Grahams";
                row[2] = "2345678";


            reportViewer2.LocalReport.ReportPath = @"C:\Users\nskalu\Source\Repos\LibraryManagerV1\Reports\BookTest.rdlc";

            ReportDataSource rds = new ReportDataSource("Books", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();

            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(rds);
            reportViewer2.LocalReport.Refresh();
            this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
        }
    }
}
