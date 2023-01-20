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
    public partial class FormTambahEvent : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rdr;
        public FormTambahEvent()
        {
            InitializeComponent();
        }

        //Koneksi
        Koneksi Konn = new Koneksi();

        void Bersihkan()
        {
            txtKodeEvent.Text = "";
            txtNamaEvent.Text = "";
            txtPenyelenggara.Text = "";
            txtLokasi.Text = "";
        }

        void AutoKode()
        {
            long hitung;
            string urutan;
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            string ssql = "SELECT Kode_Event FROM Event WHERE Kode_Event in(SELECT MAX(Kode_Event) FROM Event ) ORDER By Kode_Event DESC";
            cmd = new SqlCommand(ssql, conn);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                hitung = Convert.ToInt64(rdr[0].ToString().Substring(rdr["Kode_Event"].ToString().Length - 5, 5)) + 1;
                string kode = "00000" + hitung;
                urutan = "E" + kode.Substring(kode.Length - 5, 5);
            }
            else
            {
                urutan = "E0001";
            }
            rdr.Close();
            txtKodeEvent.Text = urutan;
            conn.Close();

        }

        void TampilData()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Event", conn);
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

        private void FormTambahEvent_Load(object sender, EventArgs e)
        {
            txtKodeEvent.Enabled = true;
            TampilData();
            Bersihkan();
            AutoKode();

        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            if (txtKodeEvent.Text.Trim() == "" || txtNamaEvent.Text.Trim() == "" || txtPenyelenggara.Text.Trim() == "" || txtLokasi.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                conn.Open();
                String ssql = "SELECT * " +
                              "FROM Event " +
                              "WHERE Kode_Event = '" + txtKodeEvent.Text + "'";
                cmd = new SqlCommand(ssql, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    ssql = "UPDATE Event SET Nama_Event ='" + txtNamaEvent.Text + "',Penyelenggara ='" + txtPenyelenggara.Text + "',Lokasi='" + txtLokasi.Text + "'WHERE Kode_Event ='" + txtKodeEvent.Text + "'";
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
                    ssql = "INSERT INTO Event VALUES('" + txtKodeEvent.Text + "','" + txtNamaEvent.Text + "','" + txtPenyelenggara.Text + "','" + txtLokasi.Text + "')";
                    rdr.Close();
                    cmd = new SqlCommand(ssql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Ditambahkan");
                    TampilData();
                    Bersihkan();
                    AutoKode();
                }
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtKodeEvent.Text = row.Cells["Kode_Event"].Value.ToString();
            txtNamaEvent.Text = row.Cells["Nama_Event"].Value.ToString();
            txtPenyelenggara.Text = row.Cells["Penyelenggara"].Value.ToString();
            txtLokasi.Text = row.Cells["Lokasi"].Value.ToString();
            
        }
    }
}   
