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
using LibraryManager.Models;
using MetroFramework.Forms;
using ClosedXML.Excel;

namespace LibraryManager
{
    public partial class Books : MetroForm
    {
        private readonly LibraryManagerEntities ctx;
        public Books(LibraryManagerEntities _ctx)
        {
            InitializeComponent();
            ctx = _ctx;
            LoadGrid();
        }

       

      

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if feilds are nulls
                if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAuthor.Text)
                    || string.IsNullOrWhiteSpace(txtISBN.Text) || string.IsNullOrWhiteSpace(txtQty.Text) || (int)ddlCategory.SelectedValue ==0)
                {
                    MessageBox.Show("All fields are required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (ctx.Books.Any(c => c.Title == txtTitle.Text))
                    {
                        MessageBox.Show($"A record with the Title {txtTitle.Text} already exists", "Sorry", MessageBoxButtons.OK);
                        return;
                    }
                    //initialized the Db Context
                    using (var ctx = new LibraryManagerEntities())
                    {

                        ctx.Books.Add(new Book()
                        {
                            Author = txtAuthor.Text,
                            ISBN = txtISBN.Text,
                            QtyEntered = Int32.Parse(txtQty.Text),
                            QtyAvailable = Int32.Parse(txtQty.Text),
                            Title = txtTitle.Text,
                            DateCreated = DateTime.Now.Date,
                            CategoryId=(int)ddlCategory.SelectedValue

                        }) ;

                        ctx.SaveChanges();
                        LoadGrid();
                        MessageBox.Show("Record Saved Successfully", "Good Job", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
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
                }).ToList();
                if (response != null)
                {
                    dataGridView1.DataSource = response;
               
                }
                else
                {
                    dataGridView1.Visible = false;
                    groupBox2.Visible = false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("An error occured while loading Books", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                var response = ctx.Categories.Select(c => new
                {
                    c.CategoryName,
                    c.Id
                }).ToList();
                if (response != null && response.Count() >0 )
                {
                    ddlCategory.ValueMember = "Id";
                    ddlCategory.DisplayMember = "CategoryName";
                    ddlCategory.DataSource = response;

                }
                else
                {
                    ddlCategory.Items.Insert(0, "No Category Created Yet");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MetroButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        
        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var filee = openFileDialog1.FileName;
            btnChoose.Text = filee;

        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
          
            var filee = openFileDialog1.FileName;
            try
            {
                var filePath = Path.GetTempFileName();
                if (Path.GetExtension(filee) != ".xlsx" && Path.GetExtension(filee) != ".xls")
                {

                    MessageBox.Show("This is not a valid excel file", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning );

                }
                else
                {
                    int first = 1, last = 4;
                    int rowIndex = 0;
                    bool firstRow = true;
                    DataTable dt = new DataTable();
                    int count = 0;
                    using (XLWorkbook workBook = new XLWorkbook(filee))
                    {

                        //Read the first Sheet from Excel file.
                        IXLWorksheet workSheet = workBook.Worksheet(1);
                        foreach (IXLRow row in workSheet.Rows())
                        {

                            if (firstRow)
                            {

                              firstRow = false;
                            }
                            else {
                          
                            {
                                string title = row.Cell(2).Value.ToString();
                                if (ctx.Books.Any(c => c.Title == title))
                                {
                                    MessageBox.Show($"A book with the Title {title} already exists", "Sorry", MessageBoxButtons.OK);

                                }
                                else
                                {
                                    //initialized the Db Context
                                    using (var ctx = new LibraryManagerEntities())
                                    {
                                            string qty = row.Cell(5).Value.ToString();
                                            
                                        ctx.Books.Add(new Book()
                                        {
                                            Author = row.Cell(4).Value.ToString(),
                                            ISBN = row.Cell(3).Value.ToString(),
                                            QtyEntered = Int32.Parse(qty),
                                            QtyAvailable = Int32.Parse(qty),
                                            Title = row.Cell(2).Value.ToString()

                                        });

                                        ctx.SaveChanges();
                                        count++;
                                   
                                    }
                                }
                             

                            }
                            }

                        }

                        LoadGrid();
                        MessageBox.Show(count +" Records Saved Successfully", "Good Job", MessageBoxButtons.OK);
                    }
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("An error occured while uploading the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCategory_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if feilds are nulls
                if (string.IsNullOrWhiteSpace(txtCategory.Text))
                {
                    MessageBox.Show("Please enter a Category name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (ctx.Books.Any(c => c.Title == txtTitle.Text))
                    {
                        MessageBox.Show($"{txtCategory.Text} already exists", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //initialized the Db Context
                    using (var ctx = new LibraryManagerEntities())
                    {

                        ctx.Categories.Add(new Category()
                        {
                            CategoryName = txtCategory.Text,
                            DateCreated = DateTime.Now.Date,
                            CreatedBy=1

                        });

                        ctx.SaveChanges();
                        LoadGrid();
                        MessageBox.Show("Category Saved Successfully", "Good Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
    }
}
