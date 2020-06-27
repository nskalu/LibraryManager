using LibraryManager.Models;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager.Views
{
    public partial class StudentBook : MetroForm
    {

        private readonly LibraryManagerEntities ctx;
        public StudentBook(LibraryManagerEntities _ctx)
        {
            InitializeComponent();
            ctx = _ctx;
            LoadDropDown();
            lblID.Hide();
        }


        private void MetroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void StudentBook_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtcriteria;
            }
            catch (Exception)
            {

                MessageBox.Show("Error during form load", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDropDown()
        {
            try
            {
                var response = ctx.Books.Select(c => new
                {
                    c.Title,
                    c.BookId
                }).ToList();
                if (response != null)
                {
                    cmbBooks.ValueMember = "BookId";
                    cmbBooks.DisplayMember = "Title";
                    cmbBooks.DataSource = response;

                }
                else
                {
                    cmbBooks.Items.Insert(0, "No Books Created Yet");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading books", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //call this method on scan of the barcode
        private void GetStudentBookHistory(string MatricNo)
        {
            try
            {
                gdvHistory.Columns.Clear();

                var data = ctx.Students.Where(m => m.MatricNo == MatricNo).FirstOrDefault();
                if (data == null)
                {
                    MessageBox.Show("This Matric Number Has Not Been Registered", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var StudentId = data.StudentId;
                var FullName = data.FirstName + " " + data.LastName;

                var res = (from s in ctx.StudentBooks
                           join sa in ctx.Books on s.BookId equals sa.BookId
                           where s.StudentId == StudentId
                           select new
                           {
                               s.Id,
                               sa.Title,
                               sa.Author,
                               sa.ISBN,
                               s.DateBorrowed,
                               s.DateToReturn,
                               s.DateReturned,
                               HasReturned = s.IsReturned == true ? "Yes" : "No"
                           }).ToList();

                lblMatric.Text = MatricNo;
                lblName.Text = FullName;
                lblID.Text = data.StudentId.ToString();

                if (res.Count() > 0)
                {
                    gdvHistory.DataSource = res;


                    DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    {
                        button.Name = "actionButton";
                        button.HeaderText = "Action";
                        button.Text = "Return";
                        
                        button.ToolTipText = "Return this Book";
                        button.DefaultCellStyle.ForeColor = Color.Blue;
                        button.UseColumnTextForButtonValue = true;
                        if (!gdvHistory.Columns.Contains("actionButton"))
                        {

                            gdvHistory.Columns.Add(button);

                        }
                      
                    }
                    foreach (DataGridViewRow selectedrow in gdvHistory.Rows)
                    {
                        var b = selectedrow.Cells["HasReturned"].Value;
                        if (b.ToString() == "Yes")
                        {

                            DataGridViewTextBoxCell oEmptyTextCell = new DataGridViewTextBoxCell();
                            oEmptyTextCell.Value = String.Empty;
                            selectedrow.Cells[8] = oEmptyTextCell;

                        }
                    

                    }
                }
                else
                {
                    gdvHistory.Columns.Add("No Data", "No Borrow Record");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading Borrow History", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtcriteria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string strCurrentString = txtcriteria.Text.Trim().ToString();
                if (strCurrentString != "")
                {
                    //Do something with the barcode entered
                    txtcriteria.Text = "";
                    GetStudentBookHistory(strCurrentString);
                }
                txtcriteria.Focus();
            }
        }
        private void BtnBorrow_Click(object sender, EventArgs e)
        {
            string matric = lblMatric.Text;
            
            try
            {
                var studentId = Guid.Parse(lblID.Text);//enter the student id here
                if (cmbBooks.SelectedValue == null)
                {
                    MessageBox.Show("Please select a book", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (ctx.StudentBooks.Any(c => c.BookId == (int)cmbBooks.SelectedValue && c.StudentId == studentId && c.IsReturned != true))
                    {
                        MessageBox.Show($"This student has already borrowed {cmbBooks.Text} and has not returned it", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var qty = ctx.Books.SingleOrDefault(m => m.BookId == (int)cmbBooks.SelectedValue).QtyAvailable;
                    if (qty > 0)
                    {
                        //initialized the Db Context
                        using (var ctx = new LibraryManagerEntities())
                        {

                            ctx.StudentBooks.Add(new Models.StudentBook()
                            {
                                StudentId = studentId,
                                BookId = (int)cmbBooks.SelectedValue,
                                DateToReturn = cmbDateToReturn.Value,
                                DateBorrowed = DateTime.Now.Date

                            });

                            var book = ctx.Books.Find((int)cmbBooks.SelectedValue);
                            var qty1 = book.QtyAvailable;
                            book.QtyAvailable = --qty1;
                            book.TimesBorowed = ++book.TimesBorowed;
                            ctx.SaveChanges();

                            ctx.SaveChanges();
                            MessageBox.Show("Book Borrowed to Student Successfully", "Good Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetStudentBookHistory(matric);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"{cmbBooks.Text} is out of stock", "Sorry", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while saving record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            GetStudentBookHistory(txtcriteria.Text);
        }

        private void GdvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == gdvHistory.Columns["actionButton"].Index)
                {
                    //Do something with your button.

                    int index = e.RowIndex;
                    var selectedRow = gdvHistory.Rows[index];
                    var id = selectedRow.Cells[0].Value;
                    var data = ctx.StudentBooks.Where(m => m.Id == (int)id).FirstOrDefault();
                    data.IsReturned = true;
                    data.DateReturned = DateTime.Now.Date;
                    var book = ctx.Books.Where(m => m.BookId == data.BookId).FirstOrDefault();
                    book.QtyAvailable = ++book.QtyAvailable;
                    ctx.SaveChanges();
                    MessageBox.Show("Book returned successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetStudentBookHistory(lblMatric.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured during the return operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GdvHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gdvHistory.Columns[0].Visible = false;
        }
    }
}
