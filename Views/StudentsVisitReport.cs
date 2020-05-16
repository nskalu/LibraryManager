using LibraryManager.Models;
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

namespace LibraryManager.Views
{
    public partial class StudentsVisitReport : MetroForm
    {
        private readonly LibraryManagerEntities ctx;
         string ReportName, datasetName;
            DataTable dt = new DataTable();
        public StudentsVisitReport(LibraryManagerEntities _ctx)
        {
            InitializeComponent();
            ctx = _ctx;
        }

        private void StudentsVisitReport_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (var ctx = new LibraryManagerEntities())
                {
                    var response = ctx.Students.Select(c => new
                    {
                        c.LastName,
                        c.FirstName,
                        c.MiddleName,
                        c.Email,
                        c.MatricNo,
                        c.DateCreated
                    }).ToList();
                    if (response != null)
                    {
                        dataGridView1.DataSource = response;
                   
                    }
                    else
                    {
                        dataGridView1.Visible = false;
                    }
                    Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading the report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnloadreport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new LibraryManagerEntities())
                {
                    var response = ctx.Students.Select(c => new
                    {
                        c.LastName,
                        c.FirstName,
                        c.MiddleName,
                        c.Email,
                        c.MatricNo,
                        c.DateCreated
                    }).Where(m => m.DateCreated >= txtDatefrom.Value && m.DateCreated <= txtdateTo.Value).ToList();
                    if (response != null)
                    {
                        dataGridView1.DataSource = response;

                    }
                    else
                    {
                        dataGridView1.Visible = false;
                    }
                    Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading the report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    ReportName = "StudentsVisit.rdlc";
                    datasetName = "StudentsVisit";
                    DataColumn col;
                    foreach (DataGridViewColumn dgvCol in dataGridView1.Columns)
                    {
                        col = new DataColumn(dgvCol.Name);
                        dt.Columns.Add(col);
                    }
                    DataRow row;
                    int colcount = dataGridView1.Columns.Count - 1;
                    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                    {
                        row = dt.Rows.Add();
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                            row[column.Index] = dataGridView1.Rows[i].Cells[column.Index].Value;
                    }

                    ReportViewer rp = new ReportViewer(ReportName, dt, datasetName);
                    rp.StartPosition = FormStartPosition.CenterScreen;
                    rp.Show();
                    dt.Clear();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An error occured while loading the report viewer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("An error occured while loading the report viewer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
