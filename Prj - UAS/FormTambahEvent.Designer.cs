namespace Prj___UAS
{
    partial class FormTambahEvent
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKodeEvent = new System.Windows.Forms.TextBox();
            this.txtNamaEvent = new System.Windows.Forms.TextBox();
            this.txtPenyelenggara = new System.Windows.Forms.TextBox();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.btSimpan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode Event";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 215);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(689, 285);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama Event";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Penyelengara";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lokasi";
            // 
            // txtKodeEvent
            // 
            this.txtKodeEvent.Location = new System.Drawing.Point(144, 28);
            this.txtKodeEvent.Name = "txtKodeEvent";
            this.txtKodeEvent.Size = new System.Drawing.Size(178, 20);
            this.txtKodeEvent.TabIndex = 5;
            // 
            // txtNamaEvent
            // 
            this.txtNamaEvent.Location = new System.Drawing.Point(144, 58);
            this.txtNamaEvent.Name = "txtNamaEvent";
            this.txtNamaEvent.Size = new System.Drawing.Size(178, 20);
            this.txtNamaEvent.TabIndex = 6;
            // 
            // txtPenyelenggara
            // 
            this.txtPenyelenggara.Location = new System.Drawing.Point(144, 88);
            this.txtPenyelenggara.Name = "txtPenyelenggara";
            this.txtPenyelenggara.Size = new System.Drawing.Size(178, 20);
            this.txtPenyelenggara.TabIndex = 7;
            // 
            // txtLokasi
            // 
            this.txtLokasi.Location = new System.Drawing.Point(144, 119);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(266, 20);
            this.txtLokasi.TabIndex = 8;
            // 
            // btSimpan
            // 
            this.btSimpan.Location = new System.Drawing.Point(144, 161);
            this.btSimpan.Name = "btSimpan";
            this.btSimpan.Size = new System.Drawing.Size(131, 33);
            this.btSimpan.TabIndex = 9;
            this.btSimpan.Text = "Simpan";
            this.btSimpan.UseVisualStyleBackColor = true;
            this.btSimpan.Click += new System.EventHandler(this.btSimpan_Click);
            // 
            // FormTambahEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 529);
            this.Controls.Add(this.btSimpan);
            this.Controls.Add(this.txtLokasi);
            this.Controls.Add(this.txtPenyelenggara);
            this.Controls.Add(this.txtNamaEvent);
            this.Controls.Add(this.txtKodeEvent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "FormTambahEvent";
            this.Text = "FormTambahEvent";
            this.Load += new System.EventHandler(this.FormTambahEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKodeEvent;
        private System.Windows.Forms.TextBox txtNamaEvent;
        private System.Windows.Forms.TextBox txtPenyelenggara;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.Button btSimpan;
    }
}