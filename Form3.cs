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

            // Tambahkan event handler untuk validasi input
            txtNama.KeyPress += OnlyLetters_KeyPress;
        }

        // Fungsi Validasi: Hanya boleh huruf, spasi, dan tombol control
        private void OnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Tolak input jika bukan huruf/spasi
                MessageBox.Show("Hanya diperbolehkan memasukkan huruf!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "";
                    conn.Open();
                    if (idTerpilih != "")
                    {
                        query = "UPDATE Sayur SET NamaSayur = @nama, Kategori = @kat, Stok = @stok, HargaJual = @harga where SayurID = @id";
                    }
                    else
                    {
                        query = "EXEC insertSayur @nama = @nama, @kat = @kat, @stok = @stok, @harga = @harga";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@kat", "Umum");
                    cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text));
                    cmd.Parameters.AddWithValue("@harga", double.Parse(txtHarga.Text));
                    if (idTerpilih != "") cmd.Parameters.AddWithValue("@id", idTerpilih);

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