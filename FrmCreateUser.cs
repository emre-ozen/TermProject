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
    }
}
