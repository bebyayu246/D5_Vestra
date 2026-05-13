namespace SistemManajemenDistributorSayur
{
    partial class FormTambahSayur
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.dBDistributorSayurDataSet = new SistemManajemenDistributorSayur.DBDistributorSayurDataSet();
            this.sayurBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sayurTableAdapter = new SistemManajemenDistributorSayur.DBDistributorSayurDataSetTableAdapters.SayurTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dBDistributorSayurDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayurBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = " Nama      :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stok         :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Harga      :";
            // 
            // txtStok
            // 
            this.txtStok.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sayurBindingSource, "Stok", true));
            this.txtStok.Location = new System.Drawing.Point(113, 113);
            this.txtStok.Multiline = true;
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(278, 42);
            this.txtStok.TabIndex = 6;
            // 
            // txtNama
            // 
            this.txtNama.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sayurBindingSource, "NamaSayur", true));
            this.txtNama.Location = new System.Drawing.Point(113, 60);
            this.txtNama.Multiline = true;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(278, 35);
            this.txtNama.TabIndex = 7;
            // 
            // txtHarga
            // 
            this.txtHarga.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sayurBindingSource, "HargaJual", true));
            this.txtHarga.Location = new System.Drawing.Point(113, 175);
            this.txtHarga.Multiline = true;
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(278, 42);
            this.txtHarga.TabIndex = 8;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSimpan.Location = new System.Drawing.Point(152, 268);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(131, 38);
            this.btnSimpan.TabIndex = 9;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // dBDistributorSayurDataSet
            // 
            this.dBDistributorSayurDataSet.DataSetName = "DBDistributorSayurDataSet";
            this.dBDistributorSayurDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sayurBindingSource
            // 
            this.sayurBindingSource.DataMember = "Sayur";
            this.sayurBindingSource.DataSource = this.dBDistributorSayurDataSet;
            // 
            // sayurTableAdapter
            // 
            this.sayurTableAdapter.ClearBeforeFill = true;
            // 
            // FormTambahSayur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 402);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormTambahSayur";
            this.Text = "formTambahSayur";
            this.Load += new System.EventHandler(this.FormTambahSayur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dBDistributorSayurDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayurBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.Button btnSimpan;
        private DBDistributorSayurDataSet dBDistributorSayurDataSet;
        private System.Windows.Forms.BindingSource sayurBindingSource;
        private DBDistributorSayurDataSetTableAdapters.SayurTableAdapter sayurTableAdapter;
    }
}