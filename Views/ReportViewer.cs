using LibraryManager.Datasets;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager.Views
{
    public partial class ReportViewer : MetroForm
    {
        public ReportViewer(string report,DataTable dt, string datasetName)
        {
            InitializeComponent();
            LoadReport(report, dt, datasetName);
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void LoadReport(string ReportName, DataTable dt, string tableName)
        {
            try
            {

                //for some reason the dt above refused to bind to the reportviewer table, so i had to transfer it again to another datatable
                DataTable dt2 = new DataTable();
                CultureInfo provider = CultureInfo.InvariantCulture;
                foreach (DataColumn column in dt.Columns)
                {
                    dt2.Columns.Add(column.ColumnName);
                }

                for (int i =0; i <= dt.Rows.Count-1; i++)
                {
                        dt2.Rows.Add();
                    for (int r = 0; r <=dt.Columns.Count - 1; r++)
                    {
      
                        string type = (dt.Rows[i][r].GetType().FullName);
                        if (type == "System.DateTime")
                        {
                            //because getting date out of nullable datetime isn't pretty straightforward, i used a hack 
                            DateTime? date = null;
                            date = Convert.ToDateTime(dt.Rows[i][r]);
                            string finalDate = string.Empty;

                            finalDate = date !=null ? date.Value.ToShortDateString() : null;
                            dt2.Rows[i][r] = finalDate;
                        }
                        else 
                            dt2.Rows[i][r] = dt.Rows[i][r].ToString();
                    }
                }
                

                reportViewer1.Visible = true;
                reportViewer1.ProcessingMode = ProcessingMode.Local;
#if DEBUG
                reportViewer1.LocalReport.ReportPath = @"..\..\Reports\" + ReportName;
#else
    reportViewer1.LocalReport.ReportPath = @"C:\Program Files (x86)\Reports\" + ReportName; 
#endif

                if (dt.Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource(tableName, dt2);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
                    //reportViewer1.cons
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading the report viewer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
