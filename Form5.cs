using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemManajemenDistributorSayur
{
   
    public partial class Form5 : Form
    {
        string connectionString = @"Data Source=LAPTOP-V3CL2RKG\BEBEB;Initial Catalog=DBDistributorsayur;Integrated Security=True";
        double hargaSayurSatuKilo = 0;

        public Form5()
        {
            InitializeComponent();
        }

       

        private void label4_Click(object sender, EventArgs e) { }
        private void Form5_Load(object sender, EventArgs e) { }
    }
}