using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProject
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            tSSLblUser.Text = frmLogin.username;
        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();  
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCreateUser frm=new FrmCreateUser();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frm = new FrmChangePassword();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?","Comfirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
              Application.Exit();
        }

        private void listUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlistUsers frm = new frmlistUsers();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
