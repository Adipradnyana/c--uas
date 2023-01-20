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
    public partial class FormTambahHasil : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rdr;

        public FormTambahHasil()
        {
            InitializeComponent();
        }

        //Koneksi 
        Koneksi Konn = new Koneksi();

        void Bersihkan()
        {
            txtKodeHasil.Clear();
            txtKodeJadwal.Clear();
            txtKodeEvent.Clear();
            txtNamaEvent.Clear();
            txtKodeTimA.Clear();
            txtKodePesertaA.Clear();
            txtNamaTimA.Clear();
            txtKodeTimB.Clear();
            txtSkorA.Clear();
            txtHasilA.Clear();
            txtKodePesertaB.Clear();
            txtNamaTimB.Clear();
            txtSkorB.Clear();
            txtHasilB.Clear();
        }

        void EnableFalse()
        {
            txtKodeHasil.Enabled = false;
            txtKodeJadwal.Enabled = false;
            txtKodeEvent.Enabled = false;
            txtNamaEvent.Enabled = false;
            dTPJadwal.Enabled = false;
            txtKodeTimA.Enabled = false;
            txtKodePesertaA.Enabled = false;
            txtNamaTimA.Enabled = false;
            txtKodeTimB.Enabled = false;
            txtKodePesertaB.Enabled = false;
            txtNamaTimB.Enabled = false;
        }
        void AutoKode()
        {
            long hitung;
            string urutan;
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            string ssql = "SELECT Kode_Hasil FROM Hasil WHERE Kode_Hasil in(SELECT MAX(Kode_Hasil) FROM Hasil ) ORDER By Kode_Hasil DESC";
            cmd = new SqlCommand(ssql, conn);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                hitung = Convert.ToInt64(rdr[0].ToString().Substring(rdr["Kode_Hasil"].ToString().Length - 5, 5)) + 1;
                string kode = "00000" + hitung;
                urutan = "H" + kode.Substring(kode.Length - 5, 5);
            }
            else
            {
                urutan = "H00001";
            }
            rdr.Close();
            txtKodeHasil.Text = urutan;
            
            conn.Close();
        }

        void TampilHasil()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT Kode_Hasil,Jadwal.Kode_Jadwal,Jadwal.Kode_Event,Jadwal.Nama_Event,Jadwal.Tanggal,Tim_A.Kode_TimA,Tim_A.Kode_Tim,P1.Nama_Tim As Nama_TimA ,Skor_TimA,Hasil_TimA,Tim_B.Kode_TimB,Tim_B.Kode_Tim as Kode_Tim2 , P2.Nama_Tim as Nama_TimB,Skor_TimB,Hasil_TimB FROM Hasil\r\nINNER JOIN Jadwal ON Jadwal.Kode_Jadwal = Hasil.Kode_Jadwal\r\nINNER JOIN Tim_A ON Tim_A.Kode_TimA = Jadwal.Kode_TimA\r\nINNER JOIN Tim_B ON Tim_B.Kode_TimB = Jadwal.Kode_TimB\r\nINNER JOIN Peserta AS P1 ON P1.Kode_Tim = Tim_A.Kode_Tim \r\nINNER JOIN Peserta As P2 ON P2.Kode_Tim = Tim_B.Kode_Tim", conn);
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

        private void FormTambahHasil_Load(object sender, EventArgs e)
        {
            EnableFalse();
            Bersihkan();
            AutoKode();
            TampilHasil();

        }

        private void btLihatJadwal_Click(object sender, EventArgs e)
        {
            FormLihatJadwal frmsearch = new FormLihatJadwal();
            frmsearch.ShowDialog();

            txtKodeJadwal.Text = Program.kdJdwl;
            txtKodeEvent.Text = Program.kdEvent;
            txtNamaEvent.Text = Program.nmEvent;
            dTPJadwal.Value = Convert.ToDateTime(Program.ttg);
            txtKodeTimA.Text = Program.kdTimA;
            txtKodePesertaA.Text = Program.kdtim1;
            txtNamaTimA.Text = Program.nmTimA;
            txtKodeTimB.Text = Program.kdTimB;
            txtKodePesertaB.Text = Program.kdtim2;
            txtNamaTimB.Text = Program.nmTimB;

        }

        private void btsimpan_Click(object sender, EventArgs e)
        {
            if (txtKodeJadwal.Text.Trim() == "" || txtKodeEvent.Text.Trim() == "" || txtNamaEvent.Text.Trim() == "" || dTPJadwal.Value.ToString() == "")
            {
                MessageBox.Show("Isi Data Terlebih Dahulu");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                conn.Open();
                string ssql = "SELECT * FROM Hasil WHERE Kode_Hasil = '" + txtKodeHasil.Text + "'";
                cmd = new SqlCommand(ssql, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    ssql = "UPDATE Hasil set Kode_Jadwal = '" + txtKodeJadwal.Text + "', Kode_TimA='" + txtKodeTimA.Text + "',Kode_TimB = '" + txtKodeTimB.Text + "',Skor_TimA = '" + Convert.ToInt16(txtSkorA.Text) + "',Skor_TimB = '" + Convert.ToInt16(txtSkorB.Text) + "',Hasil_TimA = '" + txtHasilA.Text + "',Hasil_TimB = '" + txtHasilB.Text + "'WHERE Kode_Hasil = '" + txtKodeHasil.Text + "'";
                    rdr.Close();
                    cmd = new SqlCommand(ssql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Diupdate");
                    Bersihkan();
                    AutoKode();
                    TampilHasil();
                }
                else
                {

                    ssql = "INSERT INTO Hasil VALUES ('" + txtKodeHasil.Text + "','" + txtKodeJadwal.Text + "','" + txtKodeTimA.Text + "','" + txtKodeTimB.Text + "','" + Convert.ToInt16(txtSkorA.Text) + "','" + Convert.ToInt16(txtSkorB.Text) + "','" + txtHasilA.Text + "','" + txtHasilB.Text + "')";
                    rdr.Close();
                    cmd = new SqlCommand(ssql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Ditambahkan");
                    Bersihkan();
                    AutoKode();
                    TampilHasil();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtKodeHasil.Text = row.Cells["Kode_Hasil"].Value.ToString();
            txtKodeJadwal.Text = row.Cells["Kode_Jadwal"].Value.ToString();
            txtKodeEvent.Text = row.Cells["Kode_Event"].Value.ToString();
            txtNamaEvent.Text = row.Cells["Nama_Event"].Value.ToString();
            dTPJadwal.Value = Convert.ToDateTime(row.Cells["Tanggal"].Value.ToString());
            txtKodeTimA.Text = row.Cells["Kode_TimA"].Value.ToString();
            txtKodeTimB.Text = row.Cells["Kode_TimB"].Value.ToString();
            txtKodePesertaA.Text = row.Cells["Kode_Tim"].Value.ToString();
            txtNamaTimA.Text = row.Cells["Nama_TimA"].Value.ToString();
            txtKodePesertaB.Text = row.Cells["Kode_Tim2"].Value.ToString();
            txtNamaTimB.Text = row.Cells["Nama_TimB"].Value.ToString();
            txtSkorA.Text = row.Cells["Skor_TimA"].Value.ToString();
            txtSkorB.Text = row.Cells["Skor_TimB"].Value.ToString();
            txtHasilA.Text = row.Cells["Hasil_TimA"].Value.ToString();
            txtHasilB.Text = row.Cells["Hasil_TimB"].Value.ToString();

        }

        private void btHasil_Click(object sender, EventArgs e)
        {
            if(txtSkorA.Text.Trim() == "" || txtSkorB.Text.Trim() == "")
            {
                MessageBox.Show("skor belum diinput");
            }
            else
            {
                if (Convert.ToInt32(txtSkorA.Text) > Convert.ToInt32(txtSkorB.Text))
                {
                    txtHasilA.Text = "Menang";
                    txtHasilB.Text = "Kalah";
                }
                else if (Convert.ToInt32(txtSkorA.Text) < Convert.ToInt32(txtSkorB.Text))
                {
                    txtHasilA.Text = "Kalah";
                    txtHasilB.Text = "Menang";
                }
                else
                {
                    txtHasilA.Text = "Seri";
                    txtHasilB.Text = "Seri";
                }
            }
            
        }
    }
}
