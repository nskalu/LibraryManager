using LibraryManager.Models;
using LibraryManager.ViewModels;
using MetroFramework.Forms;
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
using ZXing;

namespace LibraryManager.Views
{
    public partial class AddStudent : MetroForm
    {
        private readonly LibraryManagerEntities ctx;
        public AddStudent()
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            ctx = new LibraryManagerEntities();
            using (var ctx = new LibraryManagerEntities())
            {
                var response = ctx.Students.Select(c => new
                {
                    c.LastName,
                    c.FirstName,
                    c.Email,
                    c.MatricNo,
                    c.DateCreated
                }).ToList();
                if (response != null)
                {
                    dataGridView1.DataSource = response;
                    DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    {
                        button.Name = "actionButton";
                        button.HeaderText = "Action";
                        button.Text = "Print Access Card";
                        button.UseColumnTextForButtonValue = true; 
                        
                        dataGridView1.Columns.Add(button);
                    }
                }
                else
                {
                    dataGridView1.Visible = false;
                    groupBox2.Visible = false;
                }
                Cursor = Cursors.Arrow;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if feilds are nulls
                if (string.IsNullOrWhiteSpace(txtfirstName.Text) && string.IsNullOrWhiteSpace(txtsurname.Text)
                    && string.IsNullOrWhiteSpace(txtemail.Text) && string.IsNullOrWhiteSpace(txtmatricNo.Text)
                    && string.IsNullOrWhiteSpace(txtlastName.Text) && string.IsNullOrWhiteSpace(txtNumber.Text))
                {
                    MessageBox.Show("All fields are required", "Warning", MessageBoxButtons.OK);
                }
                else
                {
                    if (ctx.Students.Any(c=>c.Email== txtemail.Text))
                    {
                        MessageBox.Show($"A record with that Email{txtemail.Text} already exists", "Sorry", MessageBoxButtons.OK);
                        return;
                    }
                    //initialized the Db Context
                    using (var ctx = new LibraryManagerEntities())
                    {
                        //Using Student Info to generate QR
                        var stdId = Guid.NewGuid();
                        string makeStudentQR = $"{txtmatricNo.Text}";
                        //Saving student Info to DB
                        ctx.Students.Add(new Student()
                        {
                            FirstName = txtfirstName.Text,
                            LastName = txtsurname.Text,
                            CreatedBy = 1,
                            DateCreated = DateTime.Now.Date,
                            Email = txtemail.Text,
                            MatricNo = txtmatricNo.Text,
                            MiddleName = txtlastName.Text,
                            PhoneNumber = txtNumber.Text,
                            StudentId = stdId,
                            qrcode = makeStudentQR
                        });

                        ctx.SaveChanges();
                        var response = ctx.Students.Select(c => new
                        {
                            c.LastName,
                            c.FirstName,
                            c.Email,
                            c.MatricNo,
                            c.DateCreated
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
                        MessageBox.Show("Record Saved Successfully", "Good Job", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        void getQRCode(string data, string dest)
        {
            BarcodeWriter wr = new BarcodeWriter();

            wr.Format = BarcodeFormat.QR_CODE;

            wr.Write(data).Save(dest);
        }
        Image getQRCode(string data)
        {
            BarcodeWriter wr = new BarcodeWriter();

            wr.Format = BarcodeFormat.QR_CODE;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            wr.Write(data).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            Bitmap bmp = new Bitmap(ms);

            return bmp;

        }
        string readQRCode(string data, string source)
        {
            BarcodeReader reader = new BarcodeReader();

            var sourcebmp = (Bitmap)Bitmap.FromFile(source);

            var coderesult = reader.Decode(sourcebmp);

            return coderesult?.Text;


        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["actionButton"].Index)
                {
                    //Do something with your button.
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    var selectedRow = dataGridView1.Rows[selectedrowindex].DataBoundItem;
                    var Json = Newtonsoft.Json.JsonConvert.SerializeObject(selectedRow);
                    var JsonR = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentVM>(Json);
                    //Use Student Email to Load Data
                    var getUserByEmail = ctx.Students.Where(c => c.Email == JsonR.Email).SingleOrDefault();
                    //IdCardView b = new IdCardView(getUserByEmail);
                    IDCardViewer rp = new IDCardViewer(getUserByEmail);
                    rp.StartPosition = FormStartPosition.CenterScreen;
                    rp.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while printing access card", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtfirstName.Text = "";
            txtsurname.Text = "";
            txtemail.Text = "";
            txtmatricNo.Text = "";
            txtlastName.Text = "";
            txtNumber.Text = "";
        }

    
    }
}
