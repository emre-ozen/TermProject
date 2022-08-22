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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public static string username="";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (txtUsername.Text.Trim().Length < 3)
            {
                errP.SetError(txtUsername, "Check username!");
                return;
            }
            errP.SetError(txtUsername, "");

            if (txtPassword.Text.Trim().Length < 5)
            {
                errP.SetError(txtPassword, "Check username!");
                return;
            }
            errP.SetError(txtPassword, "");

            string actualPassword;
            SHA512 hashSvc = SHA512.Create();
            byte[] hash = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text));
            actualPassword = BitConverter.ToString(hash).Replace("-", "");

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
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", actualPassword);
                    int exists = Convert.ToInt32(cmd.ExecuteScalar());
                    if (exists == 0)
                    {
                        errP.SetError(txtUsername, "User name is wrong!");
                        errP.SetError(txtPassword, "Password is wrong!");
                        cmd.Dispose();
                        cnn.Close();
                        return;
                    }
                    errP.SetError(txtUsername, "");
                    errP.SetError(txtPassword, "");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }
            

            username = txtUsername.Text;

            FrmMenu frm=new FrmMenu();
            this.Hide();
            frm.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}