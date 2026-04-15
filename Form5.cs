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

        // Ambil harga otomatis saat sayur dipilih
        private void cbSayur_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT HargaJual FROM Sayur WHERE NamaSayur = @nama", conn);
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

        // Simpan transaksi dan potong stok
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
                    SqlTransaction trans = conn.BeginTransaction();

                    // 1. Cek Stok
                    SqlCommand cmdCek = new SqlCommand("SELECT Stok FROM Sayur WHERE NamaSayur = @nama", conn, trans);
                    cmdCek.Parameters.AddWithValue("@nama", cbSayur.Text);
                    int stokGudang = Convert.ToInt32(cmdCek.ExecuteScalar());
                    int beli = int.Parse(txtJumlah.Text);

                    if (beli > stokGudang)
                    {
                        MessageBox.Show("Stok tidak cukup! Sisa: " + stokGudang);
                        trans.Rollback();
                        return;
                    }

                    // 2. Potong Stok
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE Sayur SET Stok = Stok - @j WHERE NamaSayur = @n", conn, trans);
                    cmdUpdate.Parameters.AddWithValue("@j", beli);
                    cmdUpdate.Parameters.AddWithValue("@n", cbSayur.Text);
                    cmdUpdate.ExecuteNonQuery();

                    // 3. Simpan Nota
                    string sql = "INSERT INTO Transaksi (NamaPembeli, NamaSayur, Jumlah, TotalHarga, Tanggal) VALUES (@p, @s, @j, @t, GETDATE())";
                    SqlCommand cmdSimpan = new SqlCommand(sql, conn, trans);
                    cmdSimpan.Parameters.AddWithValue("@p", cbPembeli.Text);
                    cmdSimpan.Parameters.AddWithValue("@s", cbSayur.Text);
                    cmdSimpan.Parameters.AddWithValue("@j", beli);
                    cmdSimpan.Parameters.AddWithValue("@t", double.Parse(txtTotal.Text));
                    cmdSimpan.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Transaksi Berhasil!");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void label4_Click(object sender, EventArgs e) { }
        private void Form5_Load(object sender, EventArgs e) { }
    }
}