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
using MetroFramework.Forms;

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

       

        private void Books_Load(object sender, EventArgs e)
        {

        }

        private void MetroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if feilds are nulls
                if (string.IsNullOrWhiteSpace(txtTitle.Text) && string.IsNullOrWhiteSpace(txtAuthor.Text)
                    && string.IsNullOrWhiteSpace(txtISBN.Text) && string.IsNullOrWhiteSpace(txtQty.Text))
                {
                    MessageBox.Show("All fields are required", "Warning", MessageBoxButtons.OK);
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
                           ISBN=txtISBN.Text,
                           QtyEntered= Int32.Parse(txtQty.Text),
                           QtyAvailable= Int32.Parse(txtQty.Text),
                           Title=txtTitle.Text

                        });

                        ctx.SaveChanges();
                        LoadGrid();
                        MessageBox.Show("Record Saved Successfully", "Good Job", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel);
            }
        }

        private void LoadGrid()
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
    }
}
