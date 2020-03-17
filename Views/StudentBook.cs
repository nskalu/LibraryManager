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
        }


        private void MetroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void StudentBook_Load(object sender, EventArgs e)
        {
            try
            {

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

        //call this method on scan of the qr code
        private void GetStudentBookHistory(Guid StudentId)
        {
            try
            {
               
               var res  =  ctx.StudentBooks.Where(m=>m.StudentId==StudentId)
             .Include(m => m.Student)
             .Include(m => m.Book).ToList().Select(c=> new {

                 c.FullName,
                 c.Student.MatricNo,
                 c.Book.Title,
                 c.DateBorrowed,
                 c.DateToReturn,
                 c.IsReturned,
                 c.DateReturned
             });
            if (res != null)
                {
                    gdvHistory.DataSource = res;
                }
                else
                {
                    gdvHistory.Rows.Add();
                    gdvHistory.Rows[0].Cells[0].Value = "No Borrow Record";
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while loading Borrow History", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBorrow_Click(object sender, EventArgs e)
        {
            var studentId = new Guid(); //enter the student id here
            try
            {
                if (cmbBooks.SelectedValue == null) 
                {
                    MessageBox.Show("Please select a book", "Warning", MessageBoxButtons.OK);
                }
                else
                {
                    if (ctx.StudentBooks.Any(c => c.BookId == (int)cmbBooks.SelectedValue))
                    {
                        MessageBox.Show($"A book with the Title {cmbBooks.Text} already exists for this Student", "Sorry", MessageBoxButtons.OK);
                        return;
                    }
                    //initialized the Db Context
                    using (var ctx = new LibraryManagerEntities())
                    {

                        ctx.StudentBooks.Add(new Models.StudentBook()
                        {
                            StudentId = studentId,
                            BookId = (int)cmbBooks.SelectedValue,
                            DateToReturn = cmbDateToReturn.Value

                        }) ;

                        ctx.SaveChanges();
                        GetStudentBookHistory(studentId);
                        MessageBox.Show("Record Saved Successfully", "Good Job", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured while saving record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
