namespace Prj___UAS
{
    partial class FormTambahPeserta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btSimpan = new System.Windows.Forms.Button();
            this.txtNamaKapten = new System.Windows.Forms.TextBox();
            this.txtAsalTim = new System.Windows.Forms.TextBox();
            this.txtNamaTim = new System.Windows.Forms.TextBox();
            this.txtKodeTim = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btSimpan
            // 
            this.btSimpan.Location = new System.Drawing.Point(166, 171);
            this.btSimpan.Name = "btSimpan";
            this.btSimpan.Size = new System.Drawing.Size(131, 33);
            this.btSimpan.TabIndex = 18;
            this.btSimpan.Text = "Simpan";
            this.btSimpan.UseVisualStyleBackColor = true;
            this.btSimpan.Click += new System.EventHandler(this.btSimpan_Click);
            // 
            // txtNamaKapten
            // 
            this.txtNamaKapten.Location = new System.Drawing.Point(166, 129);
            this.txtNamaKapten.Name = "txtNamaKapten";
            this.txtNamaKapten.Size = new System.Drawing.Size(178, 20);
            this.txtNamaKapten.TabIndex = 17;
            // 
            // txtAsalTim
            // 
            this.txtAsalTim.Location = new System.Drawing.Point(166, 98);
            this.txtAsalTim.Name = "txtAsalTim";
            this.txtAsalTim.Size = new System.Drawing.Size(178, 20);
            this.txtAsalTim.TabIndex = 16;
            // 
            // txtNamaTim
            // 
            this.txtNamaTim.Location = new System.Drawing.Point(166, 68);
            this.txtNamaTim.Name = "txtNamaTim";
            this.txtNamaTim.Size = new System.Drawing.Size(178, 20);
            this.txtNamaTim.TabIndex = 15;
            // 
            // txtKodeTim
            // 
            this.txtKodeTim.Location = new System.Drawing.Point(166, 38);
            this.txtKodeTim.Name = "txtKodeTim";
            this.txtKodeTim.Size = new System.Drawing.Size(178, 20);
            this.txtKodeTim.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nama Kapten";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Asal Tim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nama Tim";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kode Tim";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 233);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(720, 193);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FormTambahPeserta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btSimpan);
            this.Controls.Add(this.txtNamaKapten);
            this.Controls.Add(this.txtAsalTim);
            this.Controls.Add(this.txtNamaTim);
            this.Controls.Add(this.txtKodeTim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormTambahPeserta";
            this.Text = "FormTambahPeserta";
            this.Load += new System.EventHandler(this.FormTambahPeserta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSimpan;
        private System.Windows.Forms.TextBox txtNamaKapten;
        private System.Windows.Forms.TextBox txtAsalTim;
        private System.Windows.Forms.TextBox txtNamaTim;
        private System.Windows.Forms.TextBox txtKodeTim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}