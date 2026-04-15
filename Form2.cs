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


        // 3. Sistem Pembatasan Akses
        private void AturHakAkses()
        {
           
            btnCreate.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

       
            btnLogStok.Enabled = true;
            btnKeuangan.Enabled = true;

            btnCreate.BringToFront();
            btnUpdate.BringToFront();
            btnDelete.BringToFront();
        }
       
        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            printDocument1_PrintPage(sender, e);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                // Ambil data dari baris yang dipilih di tabel
                string pembeli = dgvData.SelectedRows[0].Cells["NamaPembeli"].Value.ToString();
                string sayur = dgvData.SelectedRows[0].Cells["NamaSayur"].Value.ToString();
                string jumlah = dgvData.SelectedRows[0].Cells["Jumlah"].Value.ToString();
                string total = dgvData.SelectedRows[0].Cells["TotalHarga"].Value.ToString();
                string tanggal = dgvData.SelectedRows[0].Cells["Tanggal"].Value.ToString();

                Graphics g = e.Graphics;
                Font fJudul = new Font("Arial", 14, FontStyle.Bold);
                Font fTeks = new Font("Arial", 10, FontStyle.Regular);

                // Bagian Gambar Struk
                g.DrawString("VESTRA - VEGETABLE CENTRAL", fJudul, Brushes.Black, 50, 20);
                g.DrawString("------------------------------------------", fTeks, Brushes.Black, 20, 50);
                g.DrawString("Tanggal : " + tanggal, fTeks, Brushes.Black, 20, 75);
                g.DrawString("Pembeli : " + pembeli, fTeks, Brushes.Black, 20, 100);
                g.DrawString("Sayur   : " + sayur, fTeks, Brushes.Black, 20, 125);
                g.DrawString("Jumlah  : " + jumlah + " Kg", fTeks, Brushes.Black, 20, 150);
                g.DrawString("------------------------------------------", fTeks, Brushes.Black, 20, 180);
                g.DrawString("TOTAL   : Rp " + total, fJudul, Brushes.Black, 20, 210);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Render Struk: " + ex.Message);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ini akan memastikan proses .exe di Task Manager benar-benar mati
            Application.Exit();
        }
        private void BuatDataGridView()
        {
            dgvData.Name = "dgvData";
            dgvData.Location = new System.Drawing.Point(180, 80);
            dgvData.Size = new System.Drawing.Size(700, 350);
            dgvData.BackgroundColor = System.Drawing.Color.White;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.AllowUserToAddRows = false;
            dgvData.ReadOnly = true;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.MultiSelect = false;

            this.Controls.Add(dgvData);
            dgvData.BringToFront();
        }

        private void LoadDataKeGrid(string querySQL)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(querySQL, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error");
                }
            }
        }

        // --- KODE TOMBOL NAVIGASI ---
        private void btnLogStok_Click(object sender, EventArgs e)
        {
            tabelAktif = "LogStok";
            LoadDataKeGrid("SELECT * FROM LogStok");
        }

        private void btnKeuangan_Click(object sender, EventArgs e)
        {
            tabelAktif = "Keuangan";
            LoadDataKeGrid("SELECT * FROM Keuangan");
        }

        private void btnSayur_Click(object sender, EventArgs e)
        {
            tabelAktif = "Sayur";
            LoadDataKeGrid("SELECT * FROM Sayur");
        }

        private void btnPetani_Click(object sender, EventArgs e)
        {
            tabelAktif = "Petani";
            LoadDataKeGrid("SELECT * FROM Petani");
        }

        private void btnPembeli_Click(object sender, EventArgs e)
        {
            tabelAktif = "Pembeli";
            LoadDataKeGrid("SELECT * FROM Pembeli");
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void Form2_Load(object sender, EventArgs e) { }
    }
}