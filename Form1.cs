using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace SistemManajemenDistributorSayur
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
      
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();


            string connectionString = @"Data Source=LAPTOP-V3CL2RKG\BEBEB;Initial Catalog=DBDistributorsayur;Integrated Security=True";

           
        }




        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}