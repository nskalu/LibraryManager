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

namespace LibraryManager.Views
{
    public partial class NewUser : MetroForm
    {
        private readonly LibraryManagerEntities ctx;
        public NewUser(LibraryManagerEntities _ctx)
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
                if (string.IsNullOrWhiteSpace(txtname.Text) && string.IsNullOrWhiteSpace(txtphone.Text)
                    && string.IsNullOrWhiteSpace(txtpassword.Text) && string.IsNullOrWhiteSpace(txtusername.Text))
                {
                    MessageBox.Show("All fields are required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (ctx.Users.Any(c => c.PhoneNumber == txtphone.Text))
                    {
                        MessageBox.Show($"A record with {txtphone.Text} already exists", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (ctx.Users.Any(c => c.username == txtusername.Text))
                    {
                        MessageBox.Show($"A record with the username {txtusername.Text} already exists", "Sorry", MessageBoxButtons.OK);
                        return;
                    }
                    //initialized the Db Context
                    using (var ctx = new LibraryManagerEntities())
                    {

                        ctx.Users.Add(new User()
                        {
                            PhoneNumber = txtphone.Text,
                            username = txtusername.Text,
                            Password = txtpassword.Text,
                            CreatedBy = 2,
                            FullName = txtname.Text,
                            DateCreated = DateTime.Now.Date

                        });

                        ctx.SaveChanges();
                        LoadGrid();
                        MessageBox.Show("Record Saved Successfully", "Good Job", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            var response = ctx.Users.Select(c => new
            {
                c.FullName,
                c.PhoneNumber,
                c.username,
                c.DateCreated,
            }).ToList();
            if (response != null)
            {
                dataGridView1.DataSource = response;

            }
            else
            {
                dataGridView1.Columns.Add("No Data", "No Record Yet");
            }
        }
    }
}
