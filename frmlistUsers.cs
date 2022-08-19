using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProject
{
    public partial class frmlistUsers : Form
    {
        public frmlistUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmlistUsers_Load(object sender, EventArgs e)
        {
            
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
                    cmd.CommandText = "select *  from users order by name,surname";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    /*
                    DataSet dsusers = new DataSet();
                    adapter.Fill(dsusers, "users");


                    BindingSource bs = new BindingSource();
                    bs.DataSource = adapter;
                    */

                    dGWUsers.DataSource=cmd;
                    dGWUsers.DataBind();

                    
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }


        }
    }
}
