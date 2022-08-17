using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// user defined
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace TermProject
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
            txtUserName.Text = frmLogin.username;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtNewPwd.Text.Trim().Length < 5)
            {
                errP.SetError(txtNewPwd, "Password can not be less than 5 characters");
                return;
            }
            errP.SetError(txtNewPwd, "");


            if (txtNewPwd.Text != txtRPwd.Text)
            {
                errP.SetError(txtRPwd, "Retype of your pasword is different");
                return;
            }
            errP.SetError(txtRPwd, "");

            if (txtUserName.Text.Trim().Length < 3)
            {
                errP.SetError(txtUserName, "Username can not be less than 3 characters");
                return;
            }
            errP.SetError(txtUserName, "");

            if (txtOldPwd.Text.Trim().Length < 5)
            {
                errP.SetError(txtOldPwd, "Old password can not be less than 5 characters");
                return;
            }
            errP.SetError(txtOldPwd, "");

            if (txtOldPwd.Text == txtNewPwd.Text)
            {
                errP.SetError(txtNewPwd, "Old and New passwords can not be the same");
                return;
            }
            errP.SetError(txtNewPwd, "");

            // hash the password begins


            SHA512 hashSvc = SHA512.Create();   //SHA2  SHA1 like md5 is not in use anymore.

            string oldPassword;
            byte[] hash = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(txtOldPwd.Text));
            oldPassword = BitConverter.ToString(hash).Replace("-", "");

            string newPassword;
            byte[] hash2 = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(txtNewPwd.Text));
            newPassword = BitConverter.ToString(hash2).Replace("-", "");

            // hash the password ends

            // check if old password is ok
            try
            {
                using (SqlConnection cnn = new SqlConnection(ClsVariables.connectionString))
                {
                    cnn.Open();
                    if (cnn.State != ConnectionState.Open)
                        throw new Exception("Connection is broken");

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select count(*) from users where username=@username and password=@password";
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password", oldPassword);
                    int validOld = Convert.ToInt32(cmd.ExecuteScalar());
                    if (validOld == 0)
                    {
                        MessageBox.Show("Either username or Old Password is wrong");   
                        cmd.Dispose();
                        cnn.Close();
                        return;
                    }

                    cmd.Parameters.Clear();
                    cmd.CommandText = "update users set password=@password where username=@username";
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    int res = cmd.ExecuteNonQuery();
                    if (res == 1)
                    {
                        MessageBox.Show("Password Updated");
                        cmd.Dispose();
                        cnn.Close();
                        txtOldPwd.Clear();
                        txtNewPwd.Clear();
                        txtRPwd.Clear();
                        txtUserName.Text = frmLogin.username;
                        txtUserName.SelectAll();
                        txtUserName.Focus();
                        return;
                    }
                    MessageBox.Show("Change password failed!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }



        }
    }
}
