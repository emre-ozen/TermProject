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

            username = "Emre";

            FrmMenu frm=new FrmMenu();
            this.Hide();
            frm.Show();

        }
    }
}