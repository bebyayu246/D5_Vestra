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

            
            if (tipeOrang == "Petani")
            {
                lblNama.Text = "Nama Petani";
                this.Text = "Kelola Data Petani";
            }
            else
            {
                lblNama.Text = "Nama Pembeli";
                this.Text = "Kelola Data Pembeli";
            }

            
            if (cbStatus.SelectedIndex == -1 && cbStatus.Items.Count > 0)
            {
                cbStatus.SelectedIndex = 0;
            }

            if (idEdit != "")
            {
                MuatDataLama();
            }
        }

        private void MuatDataLama()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    
                    string tabel = (tipeOrang == "Petani") ? "Petani" : "Pembeli";
                    string kolomID = (tipeOrang == "Petani") ? "ID_Petani" : "ID_Pembeli";

                    string sql = $"SELECT * FROM {tabel} WHERE {kolomID} = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", idEdit);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        // Nama kolom NamaPetani atau NamaPembeli
                        string kolomNama = (tipeOrang == "Petani") ? "NamaPetani" : "NamaPembeli";

                        txtNama.Text = dr[kolomNama].ToString();
                        txtAlamat.Text = dr["Alamat"].ToString();
                        txtTelepon.Text = dr["NoTelepon"].ToString();
                        cbStatus.Text = dr["Status"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data lama: " + ex.Message);
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtNama.Text))
            {
                MessageBox.Show("Nama harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "";
                    string tabel = (tipeOrang == "Petani") ? "Petani" : "Pembeli";
                    string kolomNama = (tipeOrang == "Petani") ? "NamaPetani" : "NamaPembeli";
                    string kolomID = (tipeOrang == "Petani") ? "ID_Petani" : "ID_Pembeli";

                    if (idEdit == "")
                    {
                        sql = $"INSERT INTO {tabel} ({kolomNama}, Alamat, NoTelepon, Status) VALUES (@n, @a, @t, @s)";
                    }
                    else
                    {
                        sql = $"UPDATE {tabel} SET {kolomNama}=@n, Alamat=@a, NoTelepon=@t, Status=@s WHERE {kolomID}=@id";
                    }

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtNama.Text);
                    cmd.Parameters.AddWithValue("@a", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@t", txtTelepon.Text);
                    cmd.Parameters.AddWithValue("@s", cbStatus.Text); 
                    if (idEdit != "") cmd.Parameters.AddWithValue("@id", idEdit);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Data {tipeOrang} berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

