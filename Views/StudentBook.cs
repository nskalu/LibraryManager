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

                throw;
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
                var data = ctx.Students.Where(m => m.MatricNo == MatricNo).FirstOrDefault();
                if (data == null)
                {
                    MessageBox.Show("This Matric Number Has Not Been Registered", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var StudentId = data.StudentId;
                var FullName = data.FirstName + " "+ data.LastName;

                var res = (from s in ctx.StudentBooks
                              join sa in ctx.Books on s.BookId equals sa.BookId
                              where s.StudentId == StudentId
                              select new { sa.Title, sa.Author, sa.ISBN, s.DateBorrowed, s.DateToReturn,s.DateReturned}).ToList();

                lblMatric.Text = MatricNo;
                lblName.Text = FullName;
                lblID.Text = data.StudentId.ToString();

                if (res.Count()>0)
                {
                    gdvHistory.DataSource = res;
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
            var studentId = Guid.Parse(lblID.Text);//enter the student id here
            try
            {
                if (cmbBooks.SelectedValue == null) 
                {
                    MessageBox.Show("Please select a book", "Warning", MessageBoxButtons.OK);
                }
                else
                {
                    if (ctx.StudentBooks.Any(c => c.BookId == (int)cmbBooks.SelectedValue && c.StudentId==studentId))
                    {
                        MessageBox.Show($"A book with the Title {cmbBooks.Text} already exists for this Student", "Sorry", MessageBoxButtons.OK);
                        return;
                    }
                    var qty = ctx.Books.SingleOrDefault(m => m.BookId == (int)cmbBooks.SelectedValue).QtyAvailable;
                    if (qty > 0) { 
                    //initialized the Db Context
                    using (var ctx = new LibraryManagerEntities())
                    {

                        ctx.StudentBooks.Add(new Models.StudentBook()
                        {
                            StudentId = studentId,
                            BookId = (int)cmbBooks.SelectedValue,
                            DateToReturn = cmbDateToReturn.Value,
                            DateBorrowed = DateTime.Now.Date

                        }) ;
                        
                        var book = ctx.Books.Find((int)cmbBooks.SelectedValue);
                            var qty1 = book.QtyAvailable;
                            book.QtyAvailable = --qty1; 
                        ctx.SaveChanges();
                            
                            ctx.SaveChanges();
                            MessageBox.Show("Book Borrowed to Student Successfully", "Good Job", MessageBoxButtons.OK);
                            GetStudentBookHistory(matric);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"{cmbBooks.Text} is out of stock", "Sorry", MessageBoxButtons.OK);
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
      
     
    }
}
