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
    public partial class FormTambahSayur : Form  
    {
        string connectionString = @"Data Source=LAPTOP-V3CL2RKG\BEBEB;Initial Catalog=DBDistributorsayur;Integrated Security=True";
        string idTerpilih = "";

        
        public FormTambahSayur(string id)
        {
            InitializeComponent();
            idTerpilih = id;

            if (idTerpilih != "")
            {
                this.Text = "Edit Data Sayur";
                MuatDataLama();
            }
            else
            {
                this.Text = "Tambah Sayur Baru";
            }
        }

        private void MuatDataLama()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
               
                string query = "SELECT * FROM Sayur WHERE SayurID=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idTerpilih);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtNama.Text = dr["NamaSayur"].ToString();
                    txtStok.Text = dr["Stok"].ToString();
                    txtHarga.Text = dr["HargaJual"].ToString();
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(txtNama.Text) || string.IsNullOrEmpty(txtStok.Text) || string.IsNullOrEmpty(txtHarga.Text))
            {
                MessageBox.Show("Semua data (Nama, Stok, Harga) harus diisi!", "Peringatan");
                return;
            }

            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-V3CL2RKG\\BEBEB;Initial Catalog=DBDistributorsayur;Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Sayur (NamaSayur, Kategori, Stok, HargaJual) VALUES (@nama, @kat, @stok, @harga)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@kat", "Umum"); 
                    cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text));
                    cmd.Parameters.AddWithValue("@harga", double.Parse(txtHarga.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data sayur berhasil disimpan!", "Sukses");
                    this.Close(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal simpan: " + ex.Message);
                }
            }
        }
    }
}