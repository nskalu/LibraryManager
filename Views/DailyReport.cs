﻿using MetroFramework.Forms;
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
using Newtonsoft.Json;

namespace LibraryManager.Views
{
    public partial class DailyReport : MetroForm
    {
        private readonly LibraryManagerEntities ctx;
        string ReportName, datasetName;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    ReportName = "DailyReport.rdlc";
                    datasetName = "DailyReport";
                    try
                    {

                        var bor = (from s in ctx.StudentBooks
                                   join sa in ctx.Books on s.BookId equals sa.BookId
                                   //where s.DateBorrowed.ToString() == "2020-04-12"//DateTime.Now.Date
                                   select new
                                   {
                                      
                                       Borrowed= sa.Title + " "+sa.Author,
                                   }).
                                   OrderBy(m => m.Borrowed).ToList();

                        var ret = (from s in ctx.StudentBooks
                                   join sa in ctx.Books on s.BookId equals sa.BookId
                                   where s.DateReturned.ToString() == "2020-04-12" //DateTime.Now.Date
                                   select new
                                   {

                                       Returned = sa.Title + " " + sa.Author,
                                   }).
                              OrderBy(m => m.Returned).ToList();

                        var r = JsonConvert.SerializeObject(ret);
                        var b = JsonConvert.SerializeObject(bor);
                        dt = JsonConvert.DeserializeObject<DataTable>(r);
                        dt1 = JsonConvert.DeserializeObject<DataTable>(b);

                        //merge both results into one dt
                        dt2.Columns.Add("CurrentDate");
                        dt2.Columns.Add("Borrowed");
                        dt2.Columns.Add("Returned");

                        dt2.Rows.Add();
                        dt2.Rows[0][0] = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                        for (int i= 0; i<=dt1.Rows.Count-1; i++)
                        {
                            dt2.Rows[i][1] = dt1.Rows[i][0];
                            dt2.Rows.Add();
                        }
                        for (int i = 0; i <= dt.Rows.Count-1; i++)
                        {
                            dt2.Rows[i][2] = dt.Rows[i][0];
                        }

                        ReportViewer rp = new ReportViewer(ReportName, dt2, datasetName);
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}