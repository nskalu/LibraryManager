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
using Newtonsoft.Json;
using System.Globalization;

namespace LibraryManager.Views
{
    public partial class BorrowReport : MetroForm
    {
        private readonly LibraryManagerEntities ctx;
        string ReportName, datasetName;
        DataTable dt = new DataTable();
        public BorrowReport(LibraryManagerEntities _ctx)
        {
            InitializeComponent();
            ctx = _ctx;
            GetStudentBookHistory();
        }
        private void GetStudentBookHistory()
        {
            try
            {
            
               
                var allRecord = (from st in ctx.StudentBooks
                                 join sb in ctx.Students
                                    on st.StudentId equals sb.StudentId
                                 select new
                                 {
                                     Name = sb.FirstName + " " + sb.MiddleName + " " + sb.LastName,
                                     sb.MatricNo,
                                     sb.StudentId,
                                     st.IsReturned
                                 });
                var output = (from r in allRecord
                              select new
                              {
                                  r.StudentId,
                                  r.Name,
                                  r.MatricNo,
                                  QtyBorrowed = allRecord.Count(),
                                  QtyReturned = allRecord.Count(a => a.IsReturned == true)
                              }).Distinct().ToList();

                

                if (output.Count() > 0)
                {
                    gdvReport.DataSource = output;
                    gdvReport.Columns[0].Visible = false;
                    DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    {
                        button.Name = "actionButton";
                        button.HeaderText = "Action";
                        button.Text = "View Details";
                        button.UseColumnTextForButtonValue = true;
                        gdvReport.Columns.Add(button);
                    }
                }
                else
                {
                    gdvReport.Columns.Add("No Data", "No Borrow Record");



                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading Borrow History", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GdvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == gdvReport.Columns["actionButton"].Index)
                {
                    //Do something with your button.

                    int index = e.RowIndex;
                    var selectedRow = gdvReport.Rows[index];
                    var StudentId = selectedRow.Cells[1].Value;

                    var res = (from s in ctx.StudentBooks
                               join sa in ctx.Books on s.BookId equals sa.BookId
                               where s.StudentId == (Guid)StudentId
                               select new { sa.Title, sa.Author, sa.ISBN, s.DateBorrowed, s.DateToReturn, s.DateReturned, HasReturned=s.IsReturned  }).ToList();

                    if (res.Count() > 0)
                    {
                        gdvdetails.DataSource = res;
                    }
                    else
                    {
                        MessageBox.Show("Details could not be loaded", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during the return operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnloadreport_Click(object sender, EventArgs e)
        {
            try
            {


                var allRecord = (from st in ctx.StudentBooks.Where(m=>m.DateBorrowed >=txtDatefrom.Value && m.DateBorrowed<=txtdateTo.Value)
                                 join sb in ctx.Students
                                    on st.StudentId equals sb.StudentId
                                 select new
                                 {
                                     Name = sb.FirstName + " " + sb.MiddleName + " " + sb.LastName,
                                     sb.MatricNo,
                                     sb.StudentId,
                                     HasReturned = st.IsReturned == true ? "Yes" : "No"
                                 });
                var output = (from r in allRecord
                              select new
                              {
                                  r.StudentId,
                                  r.Name,
                                  r.MatricNo,
                                  QtyBorrowed = allRecord.Count(),
                                  QtyReturned = allRecord.Count(a => a.HasReturned == "Yes")
                              }).Distinct().ToList();



                if (output.Count() > 0)
                {
                    gdvReport.DataSource = output;
                    gdvReport.Columns[0].Visible = false;
                    DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    {
                        button.Name = "actionButton";
                        button.HeaderText = "Action";
                        button.Text = "View Details";
                        button.UseColumnTextForButtonValue = true;
                        gdvReport.Columns.Add(button);
                    }
                }
                else
                {
                    gdvReport.Columns.Add("No Data", "No Borrow Record");



                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading Borrow History", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ReportName = "BorrowDetails.rdlc";
                datasetName = "BorrowStatDetail";
                try
                {
                    var r = DateTime.Now.Date;
                    
                    var res = (from s in ctx.StudentBooks
                               join sa in ctx.Books on s.BookId equals sa.BookId
                               join st in  ctx.Students on s.StudentId equals st.StudentId
                               select new { Name= st.FirstName + st.MiddleName + st.LastName, st.MatricNo, sa.Title, sa.Author, sa.ISBN,
                                   s.DateBorrowed, 
                                   s.DateToReturn,
                                   s.DateReturned, HasReturned = s.IsReturned == true ? "Yes" : "No"
                               }).
                               OrderBy(m=> m.MatricNo).ToList();

                    var d = JsonConvert.SerializeObject( res);
                    dt = JsonConvert.DeserializeObject<DataTable>(d);

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    ReportName = "BorrowReport.rdlc";
                    datasetName = "BorrowStat";
                    DataColumn col;
                    foreach (DataGridViewColumn dgvCol in gdvReport.Columns)
                    {
                        col = new DataColumn(dgvCol.Name);
                        dt.Columns.Add(col);
                    }
                    DataRow row;
                    int colcount = gdvReport.Columns.Count - 1;
                    for (int i = 0; i <= gdvReport.Rows.Count - 1; i++)
                    {
                        row = dt.Rows.Add();
                        foreach (DataGridViewColumn column in gdvReport.Columns)
                            row[column.Index] = gdvReport.Rows[i].Cells[column.Index].Value;
                    }

                    ReportViewer rp = new ReportViewer(ReportName, dt, datasetName);
                    rp.StartPosition = FormStartPosition.CenterScreen;
                    rp.Show();
                    dt.Clear();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An error occured while loading the statistics", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("An error occured while loading the statistics", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
