using System;
using System.Data;
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

        // KETENTUAN: Mengambil harga menggunakan VIEW
        private void cbSayur_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Mengambil harga dari VIEW v_DataSayur
                    SqlCommand cmd = new SqlCommand("SELECT HargaJual FROM v_DataSayur WHERE NamaSayur = @nama", conn);
                    cmd.Parameters.AddWithValue("@nama", cbSayur.Text);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        hargaSayurSatuKilo = Convert.ToDouble(result);
                        HitungTotalOtomatis();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengambil harga: " + ex.Message);
                }
            }
        }

        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {
            HitungTotalOtomatis();
        }

        private void HitungTotalOtomatis()
        {
            if (double.TryParse(txtJumlah.Text, out double jumlah))
            {
                txtTotal.Text = (jumlah * hargaSayurSatuKilo).ToString();
            }
            else
            {
                txtTotal.Text = "0";
            }
        }

        // KETENTUAN: Simpan transaksi menggunakan STORED PROCEDURE
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbPembeli.SelectedIndex == -1 || cbSayur.SelectedIndex == -1 || string.IsNullOrEmpty(txtJumlah.Text))
            {
                MessageBox.Show("Mohon lengkapi data transaksi!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Memanggil Stored Procedure sp_InsertTransaksi
                    SqlCommand cmd = new SqlCommand("sp_InsertTransaksi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Pembeli", cbPembeli.Text);
                    cmd.Parameters.AddWithValue("@Sayur", cbSayur.Text);
                    cmd.Parameters.AddWithValue("@Jumlah", int.Parse(txtJumlah.Text));
                    cmd.Parameters.AddWithValue("@Total", double.Parse(txtTotal.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Transaksi Berhasil (via Stored Procedure)!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Jika stok kurang, SP akan memberikan error yang kita tangkap di sini
                    MessageBox.Show("Gagal Transaksi: " + ex.Message);
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

    }
}
