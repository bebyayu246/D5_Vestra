using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace SistemManajemenDistributorSayur
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
      
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e) 
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();


            string connectionString = @"Data Source=LAPTOP-V3CL2RKG\BEBEB;Initial Catalog=DBDistributorsayur;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    string query = "SELECT Role FROM Users WHERE Username = @username AND Password = HASHBYTES('SHA2_256', CAST(@password as varchar(100)))";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", user);
                    cmd.Parameters.AddWithValue("@password", pass);

                    conn.Open();
                    // Mengambil hasil pertama (Role)
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string userRole = result.ToString();
                        MessageBox.Show($"Login Berhasil sebagai {userRole}!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2 fMain = new Form2(userRole);
                        fMain.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(txtPassword.UseSystemPasswordChar == true && txtPassword.Multiline == false)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Multiline = true;
            } else if (txtPassword.UseSystemPasswordChar == false && txtPassword.Multiline == true)
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.Multiline = false;
            }
        }
    }
}