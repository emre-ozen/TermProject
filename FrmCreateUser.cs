using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// user included
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace TermProject
{
    public partial class FrmCreateUser : Form
    {
        public FrmCreateUser()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int size = rnd.Next(5, 11); // length of password
            string password = "";
            string charList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!?*_";
            for(int i = 0; i < size; i++)
            {
                int idx=rnd.Next(0,charList.Length);  // generate random index for alphabet
                password += charList[idx].ToString(); // 
            }
            txtPassword.Text = password;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtMPhone.Clear();

            txtUserName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length < 3)
            {
                errP.SetError(txtUserName, "Username should be min 3 characters!");
                return;
            }
            errP.SetError(txtUserName, "");

            
            if (txtPassword.Text.Trim().Length<5)
            {
                errP.SetError(txtPassword,"Password should be minimum 5 characters");
                return ;
            }
            errP.SetError(txtPassword, "");

            if (txtName.Text.Trim().Length < 3)
            {
                errP.SetError(txtName, "Name should be min 3 characters!");
                return;
            }
            errP.SetError(txtName, "");

            if (txtSurname.Text.Trim().Length < 3)
            {
                errP.SetError(txtSurname, "Surname should be min 3 characters!");
                return;
            }
            errP.SetError(txtSurname, "");

            // hash the password begins
            string actualPassword; // hashed password will be stored here

            SHA512 hashSvc = SHA512.Create();   //SHA2  SHA1 like md5 is not in use anymore.

            //returns 512 bits (64 byte) for the hash
            byte[] hash = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text));
            // returns Fb-2F-85 ; 64 bytes hash removing - makes it 128 characters.

            actualPassword = BitConverter.ToString(hash).Replace("-", "");
            // hash the password ends

            try
            {
                using (SqlConnection cnn = new SqlConnection(ClsVariables.connectionString))
                {
                    cnn.Open();
                    if (cnn.State != ConnectionState.Open) 
                       throw new Exception("Connection is broken");

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType= CommandType.Text;
                    cmd.CommandText = "select count(*) from users where username=@username";
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    // check if this username is in use
                    int exists = Convert.ToInt32(cmd.ExecuteScalar());
                    if (exists == 1)
                    {
                        errP.SetError(txtUserName, "User name is in use!");
                        cmd.Dispose();
                        cnn.Close();
                        return;
                    }
                    errP.SetError(txtUserName, "");

                    cmd.Parameters.Clear();
                    cmd.CommandText = "insert into users(username,password,name,surname,mphone) values(@username,@password,@name,@surname,@mphone)";
                    cmd.Parameters.AddWithValue("@username",txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password",actualPassword);
                    cmd.Parameters.AddWithValue("@name",txtName.Text);
                    cmd.Parameters.AddWithValue("@surname",txtSurname.Text);
                    cmd.Parameters.AddWithValue("@mphone",txtMPhone.Text);
                    int res = cmd.ExecuteNonQuery();
                    if (res == 1)
                    {
                        MessageBox.Show("Record Saved");
                        cmd.Dispose();
                        cnn.Close();
                        btnNew.PerformClick();
                        return;
                    }
                    MessageBox.Show("Add user failed!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }


        }
    }
}
