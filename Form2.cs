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
        string connectionString = "Data Source=LAPTOP-V3CL2RKG\\BEBEB;Initial Catalog=DBDistributorsayur;Integrated Security=True";
        string userRole = "";
        string tabelAktif = "";

        private BindingSource bindingSource = new BindingSource();
        private DataTable dtData = new DataTable();

        public Form2(string role)
        {
            InitializeComponent();
            this.userRole = role;

            // Konfigurasi Grid
            bindingNavigator1.BindingSource = bindingSource;
            dgvData.DataSource = bindingSource;
            AturHakAkses();
        }

        private void AturHakAkses()
        {
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.MultiSelect = false;
            dgvData.ReadOnly = true;
            dgvData.AllowUserToAddRows = false;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadData(string viewName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Gunakan query yang lebih aman
                    string query = "SELECT * FROM " + viewName;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtData = new DataTable();
                    da.Fill(dtData);
                    bindingSource.DataSource = dtData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat tabel " + viewName + ": " + ex.Message);
            }
        }


        // --- Menu Event Handlers ---
        private void btnLogStok_Click(object sender, EventArgs e) { tabelAktif = "v_LogStok"; LoadData(tabelAktif); }
        private void btnKeuangan_Click(object sender, EventArgs e) { tabelAktif = "v_LaporanKeuangan"; LoadData(tabelAktif); }
        private void btnSayur_Click(object sender, EventArgs e) { tabelAktif = "v_DataSayur"; LoadData(tabelAktif); }
        private void btnPetani_Click(object sender, EventArgs e) { tabelAktif = "v_DataPetani"; LoadData(tabelAktif); }
        private void btnPembeli_Click(object sender, EventArgs e) { tabelAktif = "v_DataPembeli"; LoadData(tabelAktif); }
        private void btnCetakStruk_Click(object sender, EventArgs e) { tabelAktif = "v_DaftarTransaksi"; LoadData(tabelAktif); }

        // --- SEARCH SP ---
        private void btnCari_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tabelAktif)) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string spName = tabelAktif.Contains("Sayur") ? "sp_SearchSayur" : "sp_SearchPetani";
                    SqlCommand cmd = new SqlCommand(spName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", txtCari.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dtData = new DataTable();
                    da.Fill(dtData);
                    bindingSource.DataSource = dtData;
                }
            }
            catch (Exception ex) { MessageBox.Show("Cari Gagal: " + ex.Message); }
        }

        // --- TEST INJECTION (MIMIC MODUL: HACKED EFFECT) ---
        // --- TEST INJECTION (Visual Studio / Form2.cs) ---
        private void btnTes_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // TARUH DI SINI: Ini adalah perintah 'jahat' yang akan mengubah data
                    string query = "UPDATE Sayur SET NamaSayur = 'HACKED' WHERE NamaSayur = '" + txtCari.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    int barisTerubah = cmd.ExecuteNonQuery();

                    MessageBox.Show("SQL Injection Berhasil! " + barisTerubah + " baris menjadi HACKED.");

                    // Refresh tabel agar tulisan HACKED muncul
                    tabelAktif = "v_DataSayur";
                    LoadData(tabelAktif);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Injection: " + ex.Message);
            }
        }


        // --- RESET DATA ---
        private void btnRiset_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // KODE RESET YANG SUDAH DIPERBAIKI UNTUK IDENTITY COLUMN
                    string query = @"
                IF OBJECT_ID('dbo.Sayur_Backup') IS NOT NULL
                BEGIN
                    DELETE FROM dbo.Sayur;
                    
                    -- Mengizinkan pengisian kolom Identity secara manual
                    SET IDENTITY_INSERT dbo.Sayur ON;
                    
                    INSERT INTO dbo.Sayur (SayurID, NamaSayur, Kategori, Stok, HargaJual)
                    SELECT SayurID, NamaSayur, Kategori, Stok, HargaJual FROM dbo.Sayur_Backup;
                    
                    SET IDENTITY_INSERT dbo.Sayur OFF;
                END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    txtCari.Clear();
                    MessageBox.Show("Data Berhasil Direcovery dari Backup!");

                    // Reload tampilan
                    tabelAktif = "v_DataSayur";
                    LoadData(tabelAktif);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset gagal: " + ex.Message);
            }
        }



        // --- CRUD ---
        private void btnRead_Click(object sender, EventArgs e) { if (tabelAktif != "") LoadData(tabelAktif); }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0 && tabelAktif != "")
            {
                if (MessageBox.Show("Hapus data?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string idData = dgvData.SelectedRows[0].Cells[0].Value.ToString();
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string spName = tabelAktif.Contains("Sayur") ? "sp_ManageSayur" : (tabelAktif.Contains("Petani") ? "sp_ManagePetani" : "sp_ManagePembeli");
                        SqlCommand cmd = new SqlCommand(spName, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "DELETE");
                        cmd.Parameters.AddWithValue("@ID", idData);
                        cmd.ExecuteNonQuery();
                        LoadData(tabelAktif);
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tabelAktif.Contains("Petani") || tabelAktif.Contains("Pembeli"))
                new FormDataPetaniDanPembeli(tabelAktif.Contains("Petani") ? "Petani" : "Pembeli", "").ShowDialog();
            else if (tabelAktif.Contains("Sayur"))
                new FormTambahSayur("").ShowDialog();
            btnRead_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                string id = dgvData.SelectedRows[0].Cells[0].Value.ToString();
                if (tabelAktif.Contains("Sayur")) new FormTambahSayur(id).ShowDialog();
                else new FormDataPetaniDanPembeli(tabelAktif.Contains("Petani") ? "Petani" : "Pembeli", id).ShowDialog();
                btnRead_Click(sender, e);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) { this.Hide(); new Form1().Show(); }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e) { Application.Exit(); }
        private void Form2_Load(object sender, EventArgs e) { }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e) { }
        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e) { printDocument1_PrintPage(sender, e); }
    }
}
