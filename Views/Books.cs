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
using System.Net;

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
            dataGridView1.Columns.Clear();
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
                    DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    {
                        button.Name = "actionButton";
                        button.HeaderText = "Action";
                        button.Text = "Delete";

                        button.ToolTipText = "Delete Book";
                        button.DefaultCellStyle.ForeColor = Color.Red;
                        button.UseColumnTextForButtonValue = true;
                        if (!dataGridView1.Columns.Contains("actionButton"))
                        {

                            dataGridView1.Columns.Add(button);

                        }

                    }

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
                    bool firstRow = true; bool firstRow2 = true;
                    DataTable dt = new DataTable();
                    int count = 0;
                    using (XLWorkbook workBook = new XLWorkbook(filee))
                    {
                        var cats = ctx.Categories.ToList();
                        var categories = cats.Select(x => x.CategoryName);
                        //Read the first Sheet from Excel file.
                        IXLWorksheet workSheet = workBook.Worksheet(1);
                        foreach (IXLRow row in workSheet.Rows())
                        {
                            if (firstRow)
                            {

                                firstRow = false;
                            }
                            else
                            {
                                var i = row.Cell(6).Value.ToString();
                                if  (!categories.Contains(row.Cell(6).Value.ToString().Trim()))
                                {
                                    MessageBox.Show("Ensure that all category names listed in the excel sheet are already registered on the system. click on the Category drop down to see registered categories, or add a new category in the Create Category section above.", "Unable to Upload!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }
                           
                        }
                        foreach (IXLRow row in workSheet.Rows())
                        {

                            if (firstRow2)
                            {

                              firstRow2 = false;
                            }
                            else 
                          
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
                                            Title = row.Cell(2).Value.ToString(),
                                            CategoryId = cats.Where(x => x.CategoryName == row.Cell(6).Value.ToString().Trim()).FirstOrDefault().Id

                                        });

                                        ctx.SaveChanges();
                                        count++;
                                   
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
                if (ex.Message.Contains("The process cannot access the file"))
                    MessageBox.Show("Close the excel file and try again", "Unable to Upload", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("An error occured while uploading the file, Ensure the excel sheet is properly formatted or contact the vendor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this book record?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (e.ColumnIndex == dataGridView1.Columns["actionButton"].Index)
                    {
                        int index = e.RowIndex;
                        var selectedRow = dataGridView1.Rows[index];
                        //var id = selectedRow.Cells[3].Value.ToString();
                        //i used an extension method here instead of above line cos the isbn cell value was not consistent, sths it returns the qty value
                        var isbn = selectedRow.Cells.GetCellValueFromColumnHeader("ISBN").ToString();
                       
                        var book = ctx.Books.Where(m => m.ISBN == isbn).FirstOrDefault();
                        var rec = ctx.StudentBooks.Where(m => m.BookId == book.BookId).ToList();
                        if (rec.Any())
                        {
                            MessageBox.Show("Sorry! This record cannot be deleted because it has a borrow history", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        ctx.Books.Remove(book);
                        ctx.SaveChanges();
                        MessageBox.Show("Book deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGrid();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while deleting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            string remoteUri = @"..\..\Shared\";
            string fileName = "BookUploadTemplate.xlsx", myStringWebResource = null;
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource, fileName);
            string msg = "\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath;
            MessageBox.Show(msg, "Download Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
        }
    }

    public static class DataGridHelper
    {
        public static object GetCellValueFromColumnHeader(this DataGridViewCellCollection CellCollection, string HeaderText)
        {
            return CellCollection.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == HeaderText).Value;
        }
    }
}
