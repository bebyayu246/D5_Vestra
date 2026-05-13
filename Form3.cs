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
                try
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
                catch (Exception ex) { MessageBox.Show("Gagal Muat Data: " + ex.Message); }
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
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ManageSayur", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (idTerpilih != "")
                    {
                        cmd.Parameters.AddWithValue("@Action", "UPDATE");
                        cmd.Parameters.AddWithValue("@ID", idTerpilih);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Action", "INSERT");
                        cmd.Parameters.AddWithValue("@ID", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@Kat", "Umum");
                    cmd.Parameters.AddWithValue("@Stok", int.Parse(txtStok.Text));
                    cmd.Parameters.AddWithValue("@Harga", double.Parse(txtHarga.Text));

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

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTambahSayur_Load(object sender, EventArgs e)
        {
   
        }
    }
}
