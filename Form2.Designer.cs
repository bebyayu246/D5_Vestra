namespace SistemManajemenDistributorSayur
{
    partial class Form2
    {

        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnLogStok = new System.Windows.Forms.Button();
            this.btnKeuangan = new System.Windows.Forms.Button();
            this.btnSayur = new System.Windows.Forms.Button();
            this.btnPetani = new System.Windows.Forms.Button();
            this.btnPembeli = new System.Windows.Forms.Button();
            this.btnStruk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogStok
            // 
            this.btnLogStok.Location = new System.Drawing.Point(20, 117);
            this.btnLogStok.Name = "btnLogStok";
            this.btnLogStok.Size = new System.Drawing.Size(160, 35);
            this.btnLogStok.TabIndex = 2;
            this.btnLogStok.Text = "Log Stok";
            this.btnLogStok.UseVisualStyleBackColor = true;
            this.btnLogStok.Click += new System.EventHandler(this.btnLogStok_Click);
            // 
            // btnKeuangan
            // 
            this.btnKeuangan.Location = new System.Drawing.Point(20, 158);
            this.btnKeuangan.Name = "btnKeuangan";
            this.btnKeuangan.Size = new System.Drawing.Size(157, 34);
            this.btnKeuangan.TabIndex = 3;
            this.btnKeuangan.Text = "Keuangan";
            this.btnKeuangan.UseVisualStyleBackColor = true;
            this.btnKeuangan.Click += new System.EventHandler(this.btnKeuangan_Click);
            // 
            // btnSayur
            // 
            this.btnSayur.Location = new System.Drawing.Point(23, 198);
            this.btnSayur.Name = "btnSayur";
            this.btnSayur.Size = new System.Drawing.Size(154, 41);
            this.btnSayur.TabIndex = 4;
            this.btnSayur.Text = "Sayur dan Harga";
            this.btnSayur.UseVisualStyleBackColor = true;
            this.btnSayur.Click += new System.EventHandler(this.btnSayur_Click);
            // 
            // btnPetani
            // 
            this.btnPetani.Location = new System.Drawing.Point(23, 245);
            this.btnPetani.Name = "btnPetani";
            this.btnPetani.Size = new System.Drawing.Size(154, 33);
            this.btnPetani.TabIndex = 5;
            this.btnPetani.Text = "Data Petani";
            this.btnPetani.UseVisualStyleBackColor = true;
            this.btnPetani.Click += new System.EventHandler(this.btnPetani_Click);
            // 
            // btnPembeli
            // 
            this.btnPembeli.Location = new System.Drawing.Point(20, 284);
            this.btnPembeli.Name = "btnPembeli";
            this.btnPembeli.Size = new System.Drawing.Size(157, 39);
            this.btnPembeli.TabIndex = 6;
            this.btnPembeli.Text = "Data Pembeli";
            this.btnPembeli.UseVisualStyleBackColor = true;
            this.btnPembeli.Click += new System.EventHandler(this.btnPembeli_Click);
            // 
            // btnStruk
            // 
            this.btnStruk.Location = new System.Drawing.Point(20, 329);
            this.btnStruk.Name = "btnStruk";
            this.btnStruk.Size = new System.Drawing.Size(157, 37);
            this.btnStruk.TabIndex = 7;
            this.btnStruk.Text = "Cetak Struk";
            this.btnStruk.UseVisualStyleBackColor = true;
            this.btnStruk.Click += new System.EventHandler(this.btnCetakStruk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = " MENU :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(407, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "VESTRA - Vegetable Distribution Central";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(723, 29);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(195, 117);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(554, 249);
            this.dgvData.TabIndex = 14;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(431, 388);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(512, 388);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(593, 388);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(674, 388);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 18;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 531);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStruk);
            this.Controls.Add(this.btnPembeli);
            this.Controls.Add(this.btnPetani);
            this.Controls.Add(this.btnSayur);
            this.Controls.Add(this.btnKeuangan);
            this.Controls.Add(this.btnLogStok);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form2";
            this.Text = "Tampilan";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogStok;
        private System.Windows.Forms.Button btnKeuangan;
        private System.Windows.Forms.Button btnSayur;
        private System.Windows.Forms.Button btnPetani;
        private System.Windows.Forms.Button btnPembeli;
        private System.Windows.Forms.Button btnStruk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRead;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}