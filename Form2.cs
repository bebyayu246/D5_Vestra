using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace SistemManajemenDistributorSayur
{
    public partial class Form2 : Form
    {
        // 1. Variabel Global
        string connectionString = "Data Source=LAPTOP-V3CL2RKG\\BEBEB;Initial Catalog=DBDistributorsayur;Integrated Security=True";
        string userRole = "";
        string tabelAktif = "";


        // 2. Constructor (Penerima Role dari Form Login)
        public Form2(string role)
        {
            InitializeComponent();
            this.userRole = role; // Simpan role (Admin/Petugas)

            //BuatDataGridView();
            AturHakAkses();
        }




        

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void Form2_Load(object sender, EventArgs e) { }
    }
}