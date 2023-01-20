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

namespace Prj___UAS
{
    public partial class FormTambahPeserta : Form
    {

        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rdr;

        public FormTambahPeserta()
        {
            InitializeComponent();
        }

        //Koneksi
        Koneksi Konn = new Koneksi();

        void Bersihkan()
        {
            txtKodeTim.Text = "";
            txtNamaTim.Text = "";
            txtAsalTim.Text = "";
            txtNamaKapten.Text = "";
        }

        void AutoKode()
        {
            long hitung;
            string urutan;
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            string ssql = "SELECT Kode_Tim FROM Peserta WHERE Kode_Tim in(SELECT MAX(Kode_Tim) FROM Peserta ) ORDER By Kode_Tim DESC";
            cmd = new SqlCommand(ssql, conn);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                hitung = Convert.ToInt64(rdr[0].ToString().Substring(rdr["Kode_Tim"].ToString().Length - 5, 5)) + 1;
                string kode = "00000" + hitung;
                urutan = "P" + kode.Substring(kode.Length - 5,5);
            }
            else
            {
                urutan = "P00001";
            }
            rdr.Close();
            txtKodeTim.Text = urutan;
            conn.Close();
        }



        void TampilData()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Peserta", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "event_olahraga");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "event_olahraga";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                

            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void FormTambahPeserta_Load(object sender, EventArgs e)
        {
            txtKodeTim.Enabled = false;
            TampilData();
            Bersihkan();
            AutoKode();
        }
        
        private void btSimpan_Click(object sender, EventArgs e)
        {
            if (txtKodeTim.Text.Trim() == "" || txtNamaTim.Text.Trim() == "" || txtAsalTim.Text.Trim() == "" || txtNamaKapten.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                conn.Open();
                String ssql = "SELECT * " +
                              "FROM Peserta " +
                              "WHERE Kode_Tim = '" + txtKodeTim.Text + "'";
                cmd = new SqlCommand(ssql, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    ssql = "UPDATE Peserta SET Nama_Tim ='" + txtNamaTim.Text + "',Asal_Tim ='" + txtAsalTim.Text + "',Nama_Kapten='" + txtNamaKapten.Text + "'WHERE Kode_Tim ='" + txtKodeTim.Text + "'";
                    rdr.Close();
                    cmd = new SqlCommand(ssql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil DiUpdate");
                    TampilData();
                    Bersihkan();
                    AutoKode();
                }
                else
                {
                    ssql = "INSERT INTO Peserta VALUES('" + txtKodeTim.Text + "','" + txtNamaTim.Text + "','" + txtAsalTim.Text + "','" + txtNamaKapten.Text + "')";
                    rdr.Close();
                    cmd = new SqlCommand(ssql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Ditambahkan");
                    TampilData();
                    Bersihkan();
                    AutoKode();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtKodeTim.Text = row.Cells["Kode_Tim"].Value.ToString();
            txtNamaTim.Text = row.Cells["Nama_Tim"].Value.ToString();
            txtAsalTim.Text = row.Cells["Asal_Tim"].Value.ToString();
            txtNamaKapten.Text = row.Cells["Nama_Kapten"].Value.ToString();
        }
    }
}
