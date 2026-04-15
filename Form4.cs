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

namespace SistemManajemenDistributorSayur 
{
    public partial class FormDataPetaniDanPembeli : Form
    {
        
        string connectionString = @"Data Source=LAPTOP-V3CL2RKG\BEBEB;Initial Catalog=DBDistributorsayur;Integrated Security=True";

        string tipeOrang = ""; // Untuk menampung "Petani" atau "Pembeli"
        string idEdit = "";    // Untuk menampung ID jika mode Update

        
        public FormDataPetaniDanPembeli(string tipe, string id)
        {
            InitializeComponent();
            this.tipeOrang = tipe;
            this.idEdit = id;

            
         
}

