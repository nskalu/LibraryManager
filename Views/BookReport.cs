using LibraryManager.Models;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager.Views
{
    public partial class BookReport : MetroForm
    {
        private readonly LibraryManagerEntities ctx;
        String ReportName, datasetName;
        DataTable dt = new DataTable();
        public BookReport(LibraryManagerEntities _ctx)
        {
            InitializeComponent();
            ctx = _ctx;
            LoadGrid();
           
        }

        private void BookReport_Load(object sender, EventArgs e)
        {

        }
        private void LoadGrid()
        {
            try
            {
                var response = ctx.Books.Select(c => new
                {
                    c.Title,
                    c.Author,
                    c.ISBN,
                    c.QtyEntered,
                    c.QtyAvailable
                }).OrderBy(m => m.QtyAvailable).ToList();
                if (response != null)
                {
                    dataGridView1.DataSource = response;
                    ReportName = "Registered.rdlc";
                    datasetName = "Registered";

                }
                else
                {
                    dataGridView1.Visible = false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("An error occured while loading the report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (ddlSearchCriteria.SelectedIndex == 0)
                {
                    //available
                     var response = (from b in ctx.Books
                                    join c in ctx.Categories on b.CategoryId equals c.Id
                                    where (b.QtyAvailable > 0)
                                    orderby (c.CategoryName)
                                    select new
                                    {
                                        c.CategoryName,
                                        b.Title,
                                        b.Author,
                                        b.ISBN,
                                        b.QtyEntered,
                                        b.QtyAvailable
                                    });

                    ReportName = "Available.rdlc";
                    datasetName = "Available";
                    if (response != null)
                    {
                        dataGridView1.DataSource = response;

                    }
                    else
                    {
                        dataGridView1.Visible = false;
                    }
                }
                else
                {
                    //highest borrowed


                    var response = (from b in ctx.Books
                                                   join c in ctx.StudentBooks on b.BookId equals c.BookId
                                                   where (c.DateBorrowed >= cmbFrom.Value && c.DateBorrowed <= cmbTo.Value)
                                                   orderby b.TimesBorowed descending
                                                   select new
                                                   {
                                                       b.Title,
                                                       b.Author,
                                                       b.ISBN,
                                                       b.QtyEntered,
                                                       b.QtyAvailable,
                                                       TimesBorrowed=b.TimesBorowed
                                                   }).Distinct().ToList();

                    ReportName = "AllBooks.rdlc";
                    datasetName = "TimesBorrowed";
                    if (response != null)
                    {
                        dataGridView1.DataSource = response;
                    }
                    else
                    {
                        dataGridView1.Visible = false;
                    }

                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading the report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataColumn col;
                foreach (DataGridViewColumn dgvCol in dataGridView1.Columns)
                {
                    col = new DataColumn(dgvCol.Name);
                    dt.Columns.Add(col);
                }
                DataRow row;
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    row = dt.Rows.Add();
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                        row[column.Index] = dataGridView1.Rows[i].Cells[column.Index].Value.ToString(); 
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
    }
}
