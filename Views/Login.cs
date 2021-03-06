﻿using LibraryManager.Models;
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
    public partial class Login : MetroForm
    {
        private readonly LibraryManagerEntities ctx = new LibraryManagerEntities();
        public Login()
        {
            InitializeComponent();
            txtusername.Focus();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                  if( string.IsNullOrWhiteSpace(txtusername.Text) && string.IsNullOrWhiteSpace(txtpassword.Text))
                {
                    MessageBox.Show("Please enter username and password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (ctx.Users.Any(c => c.username == txtpassword.Text && c.Password == txtusername.Text))
                {
                HomePage homePage = new HomePage();
                homePage.Show();
                Login lg = new Login();
                lg.Close();
                    lg.Hide();
                }
                else
                {

                    MessageBox.Show($"Username or Password is Incorrect", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Oops an error occured, Try again! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
