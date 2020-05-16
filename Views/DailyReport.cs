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
using LibraryManager.Models;

namespace LibraryManager.Views
{
    public partial class DailyReport : MetroForm
    {
        private readonly LibraryManagerEntities ctx;
        public DailyReport(LibraryManagerEntities _ctx)
        {
            InitializeComponent();
            ctx = _ctx;
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                var allRecord = (from st in ctx.StudentBooks
                                 select new
                                 {
                                    st.BookId,
                                    st.DateBorrowed,
                                    st.DateReturned,
                                 });

                var output = (from r in allRecord
                              select new
                              {
                                  CurrentDate=DateTime.Now.Date,
                                  NoBorrowed = allRecord.Where(m=>m.DateBorrowed == DateTime.Now.Date).Count(),
                                  NoReturned = allRecord.Where(m => m.DateReturned == DateTime.Now.Date).Count()
                             
                              }).Distinct().ToList();

                if (output != null)
                {
                    dataGridView1.DataSource = output;
                    DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    {
                        button.Name = "actionButton";
                        button.HeaderText = "Action";
                        button.Text = "View Details";
                        button.UseColumnTextForButtonValue = true;
                        dataGridView1.Columns.Add(button);
                    }

                }
                else
                {
                    dataGridView1.Visible = false;
                    groupBox2.Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading daily report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

       

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["actionButton"].Index)
                {
                    //Do something with your button.

                 

                    var borrowed = (from s in ctx.StudentBooks
                               join sa in ctx.Books on s.BookId equals sa.BookId
                               where s.DateBorrowed== DateTime.Now.Date
                               select new { sa.Title, sa.Author, sa.ISBN, s.DateBorrowed, s.DateToReturn}).ToList();

                    var returned = (from s in ctx.StudentBooks
                               join sa in ctx.Books on s.BookId equals sa.BookId
                               where s.DateReturned == DateTime.Now.Date
                               select new { sa.Title, sa.Author, sa.ISBN, s.DateBorrowed, s.DateReturned }).ToList();

                    if (borrowed.Count() > 0)
                    {
                        gdvBorrowed.DataSource = borrowed;
                    }
                    else
                    {
                        MessageBox.Show("No Book was borrowed today", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (returned.Count() > 0)
                    {
                        gdvBorrowed.DataSource = returned;
                    }
                    else
                    {
                        MessageBox.Show("No Book was returned today", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during the return operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
    }
}
