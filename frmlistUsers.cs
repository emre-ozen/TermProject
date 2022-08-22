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
                    cmd.CommandText = "select username,name,surname,mphone  from users order by name,surname";

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtRecord = new DataTable();
                    adapter.Fill(dtRecord);
                    dGWUsers.DataSource = dtRecord;


                     dGWUsers.Columns["name"].HeaderText = "Name";
                     dGWUsers.Columns["surname"].HeaderText = "Surname";
                     dGWUsers.Columns["username"].HeaderText = "User Name";
                     dGWUsers.Columns["mphone"].HeaderText = "Mobile Phone";
                     

                    dGWUsers.AllowUserToAddRows = false;
                    dGWUsers.AllowUserToDeleteRows = false;
                    dGWUsers.AllowUserToOrderColumns = true;
                    dGWUsers.ReadOnly = true;
                    dGWUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dGWUsers.MultiSelect = false;
                    dGWUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    dGWUsers.AllowUserToResizeColumns = false;
                    dGWUsers.ColumnHeadersHeightSizeMode =
                        DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dGWUsers.AllowUserToResizeRows = true;
                    dGWUsers.RowHeadersWidthSizeMode =
                        DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                    // Set the selection background color for all the cells.
                    dGWUsers.DefaultCellStyle.SelectionBackColor = Color.White;
                    dGWUsers.DefaultCellStyle.SelectionForeColor = Color.Black;

                    // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
                    // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
                    dGWUsers.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

                    // Set the background color for all rows and for alternating rows. 
                    // The value for alternating rows overrides the value for all rows. 
                    dGWUsers.RowsDefaultCellStyle.BackColor = Color.LightGray;
                    dGWUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

                    lblUserCount.Text= dtRecord.Rows.Count.ToString();
                    cnn.Close();
                }
            } 
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }
           

        }

        private void dGWUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
