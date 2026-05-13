namespace SistemManajemenDistributorSayur
{
    partial class FormDataPetaniDanPembeli
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
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtNoTelp = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dBDistributorSayurDataSet = new SistemManajemenDistributorSayur.DBDistributorSayurDataSet();
            this.petaniBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.petaniTableAdapter = new SistemManajemenDistributorSayur.DBDistributorSayurDataSetTableAdapters.PetaniTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dBDistributorSayurDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petaniBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAlamat
            // 
            this.txtAlamat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.petaniBindingSource, "Alamat", true));
            this.txtAlamat.Location = new System.Drawing.Point(144, 102);
            this.txtAlamat.Multiline = true;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(278, 42);
            this.txtAlamat.TabIndex = 15;
            // 
            // txtNoTelp
            // 
            this.txtNoTelp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.petaniBindingSource, "NoTelepon", true));
            this.txtNoTelp.Location = new System.Drawing.Point(144, 150);
            this.txtNoTelp.Multiline = true;
            this.txtNoTelp.Name = "txtNoTelp";
            this.txtNoTelp.Size = new System.Drawing.Size(278, 42);
            this.txtNoTelp.TabIndex = 14;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Petani",
            "Pembeli"});
            this.cbStatus.Location = new System.Drawing.Point(144, 198);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(278, 24);
            this.cbStatus.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "No.Telp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Alamat";
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNama.Location = new System.Drawing.Point(40, 60);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(57, 22);
            this.lblNama.TabIndex = 9;
            this.lblNama.Text = "Nama";
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSimpan.Location = new System.Drawing.Point(222, 250);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(121, 39);
            this.btnSimpan.TabIndex = 17;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // txtNama
            // 
            this.txtNama.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.petaniBindingSource, "NamaPetani", true));
            this.txtNama.Location = new System.Drawing.Point(144, 54);
            this.txtNama.Multiline = true;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(278, 28);
            this.txtNama.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 22);
            this.label4.TabIndex = 19;
            this.label4.Text = "Status";
            // 
            // dBDistributorSayurDataSet
            // 
            this.dBDistributorSayurDataSet.DataSetName = "DBDistributorSayurDataSet";
            this.dBDistributorSayurDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // petaniBindingSource
            // 
            this.petaniBindingSource.DataMember = "Petani";
            this.petaniBindingSource.DataSource = this.dBDistributorSayurDataSet;
            // 
            // petaniTableAdapter
            // 
            this.petaniTableAdapter.ClearBeforeFill = true;
            // 
            // FormDataPetaniDanPembeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 373);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtNoTelp);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNama);
            this.Name = "FormDataPetaniDanPembeli";
            this.Text = "DataPetaniDanPembeli";
            this.Load += new System.EventHandler(this.FormDataPetaniDanPembeli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dBDistributorSayurDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petaniBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtNoTelp;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNama;
        private DBDistributorSayurDataSet dBDistributorSayurDataSet;
        private System.Windows.Forms.BindingSource petaniBindingSource;
        private DBDistributorSayurDataSetTableAdapters.PetaniTableAdapter petaniTableAdapter;
    }
}