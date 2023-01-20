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
    public partial class FormTambahJadwal : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rdr;
        public FormTambahJadwal()
        {
            InitializeComponent();
        }

        // koneksi
        Koneksi Konn = new Koneksi();

        void Bersihkan()
        {
            txtKodeJadwal.Clear();
            txtKodeEvent.Clear();
            txtNamaEvent.Clear();
            txtKodeTimA.Clear();
            txtKodePesertaA.Clear();
            txtNamaTimA.Clear();
            txtKodeTimB.Clear();
            txtKodePesertaB.Clear();
            txtNamaTimB.Clear();
        }

        void AutoKodeJadwal()
        {
            long hitung;
            string urutan;
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            string ssql = "SELECT Kode_Jadwal FROM Jadwal WHERE Kode_Jadwal in(SELECT MAX(Kode_Jadwal) FROM Jadwal ) ORDER By Kode_Jadwal DESC";
            cmd = new SqlCommand(ssql, conn);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                hitung = Convert.ToInt64(rdr[0].ToString().Substring(rdr["Kode_Jadwal"].ToString().Length - 5, 5)) + 1;
                string kode = "00000" + hitung;
                urutan = "J" + kode.Substring(kode.Length - 5, 5);
            }
            else
            {
                urutan = "J00001";
            }
            rdr.Close();
            txtKodeJadwal.Text = urutan;
            conn.Close();

        }
        void AutoKodeTimA()
        {
            long hitung;
            string urutan;
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            string ssql = "SELECT Kode_TimA FROM Tim_A WHERE Kode_TimA in(SELECT MAX(Kode_TimA) FROM Tim_A ) ORDER By Kode_TimA DESC";
            cmd = new SqlCommand(ssql, conn);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                hitung = Convert.ToInt64(rdr[0].ToString().Substring(rdr["Kode_TimA"].ToString().Length - 5, 5)) + 1;
                string kode = "000" + hitung;
                urutan = "TA" + kode.Substring(kode.Length - 4, 4);
            }
            else
            {
                urutan = "TA0001";
            }
            rdr.Close();
            txtKodeTimA.Text = urutan;
            conn.Close();
        }

        void AutoKodeTimB()
        {
            long hitung;
            string urutan;
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            string ssql = "SELECT Kode_TimB FROM Tim_B WHERE Kode_TimB in(SELECT MAX(Kode_TimB) FROM Tim_B) ORDER By Kode_TimB DESC";
            cmd = new SqlCommand(ssql, conn);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                hitung = Convert.ToInt64(rdr[0].ToString().Substring(rdr["Kode_TimB"].ToString().Length - 5, 5)) + 1;
                string kode = "000" + hitung;
                urutan = "TB" + kode.Substring(kode.Length - 4, 4);
            }
            else
            {
                urutan = "TB0001";
            }
            rdr.Close();
            txtKodeTimB.Text = urutan;
            conn.Close();
        }

        void TampilDataJadwal()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT Kode_Jadwal,Kode_Event,Nama_Event,Tanggal,Tim_A.Kode_TimA,Tim_A.Kode_Tim,P1.Nama_Tim As Nama_TimA , Tim_B.Kode_TimB,Tim_B.Kode_Tim as Kode_Tim2 , P2.Nama_Tim as Nama_TimB FROM Jadwal INNER JOIN Tim_A ON Tim_A.Kode_TimA = Jadwal.Kode_TimA\r\nINNER JOIN Tim_B ON Tim_B.Kode_TimB = Jadwal.Kode_TimB\r\nINNER JOIN Peserta AS P1 ON P1.Kode_Tim = Tim_A.Kode_Tim \r\nINNER JOIN Peserta As P2 ON P2.Kode_Tim = Tim_B.Kode_Tim", conn);
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
        
        

        private void btLihatEvent_Click(object sender, EventArgs e)
        {
            FormLihatEvent frmsearch = new FormLihatEvent();
            frmsearch.ShowDialog();

            txtKodeEvent.Text = Program.kdEvent;
            txtNamaEvent.Text = Program.nmEvent;
        }

        private void bttambahTim1_Click(object sender, EventArgs e)
        {
            FormLihatPeserta frmsearch = new FormLihatPeserta();
            frmsearch.ShowDialog();

            if(txtKodeTimA.Text == "" || txtKodePesertaA.Text == "" || txtNamaTimA.Text == "")
            {
                txtKodePesertaA.Text = Program.kdPsrt;
                txtNamaTimA.Text = Program.nmTim;
            }
            else
            {
                MessageBox.Show("Data Telah Diisi, Mohon dihapus!");
            }
        }

        private void btTambahTim2_Click(object sender, EventArgs e)
        {
            FormLihatPeserta frmsearch = new FormLihatPeserta();
            frmsearch.ShowDialog();

            if (txtKodeTimB.Text == "" || txtKodePesertaB.Text == "" || txtNamaTimB.Text == "")
            {
                txtKodePesertaB.Text = Program.kdPsrt;
                txtNamaTimB.Text = Program.nmTim;
            }
            else
            {
                MessageBox.Show("Data Telah Diisi, Mohon dihapus!");
            }
        }

        private void FormTambahJadwal_Load(object sender, EventArgs e)
        {
            txtKodeJadwal.Enabled = false;
            txtKodeTimA.Enabled = false;
            txtKodeTimB.Enabled = false;
            TampilDataJadwal();
            Bersihkan();
            AutoKodeJadwal();
            AutoKodeTimA();
            AutoKodeTimB();
        }

        private void btsimpan_Click(object sender, EventArgs e)
        {
            if(txtKodeJadwal.Text.Trim() == "" || txtKodeEvent.Text.Trim() == "" || txtNamaEvent.Text.Trim() == "" || dTPJadwal.Value.ToString() == ""  )
            {
                MessageBox.Show("Isi Data Terlebih Dahulu");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                conn.Open();
                string ssql = "SELECT * FROM Jadwal WHERE Kode_Jadwal = '" + txtKodeJadwal.Text + "'";
                cmd = new SqlCommand(ssql,conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    ssql = "UPDATE Jadwal set Kode_event = '" + txtKodeEvent.Text + "', Nama_Event= '" + txtNamaEvent.Text + "', Tanggal = '" + dTPJadwal.Value.Date.ToString("MM-dd-yyyy") + "',Kode_TimA='"+ txtKodeTimA.Text + "',Kode_TimB = '" + txtKodeTimB.Text + "'WHERE Kode_Jadwal = '" +txtKodeJadwal.Text + "'";
                    rdr.Close();
                    cmd = new SqlCommand(ssql, conn);
                    cmd.ExecuteNonQuery();

                    
                    if(txtKodeTimA.Text != "")
                    {
                        ssql = "UPDATE Tim_A set Kode_Tim ='" + txtKodePesertaA.Text + "' WHERE kode_TimA = '" + txtKodeTimA.Text + "'";
                        cmd = new SqlCommand(ssql, conn);
                        cmd.ExecuteNonQuery();

                        if(txtKodeTimB.Text != "")
                        {
                            ssql = "UPDATE Tim_B set Kode_Tim ='" + txtKodePesertaA.Text + "' WHERE kode_TimB = '" + txtKodeTimA.Text + "'";
                            cmd = new SqlCommand(ssql, conn);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Data Berhasil Diupdate");
                    Bersihkan();
                    TampilDataJadwal();
                    AutoKodeJadwal();
                    AutoKodeTimA();
                    AutoKodeTimB();

                }
                else
                {
                    ssql = "INSERT INTO Jadwal VALUES ('" + txtKodeJadwal.Text + "','" + txtKodeEvent.Text + "','" + txtNamaEvent.Text + "','" + dTPJadwal.Value.Date.ToString("MM-dd-yyyy") + "','" + txtKodeTimA.Text + "','" + txtKodeTimB.Text + "')";
                    rdr.Close();
                    cmd = new SqlCommand(ssql, conn);
                    cmd.ExecuteNonQuery();

                    if(txtKodeTimA.Text != "")
                    {
                        ssql = "INSERT INTO Tim_A Values ( '" + txtKodeTimA.Text + "','" + txtKodePesertaA.Text + "')";
                        cmd = new SqlCommand(ssql, conn);
                        cmd.ExecuteNonQuery();

                        if(txtKodeTimB.Text !="")
                        {
                            ssql = "INSERT INTO Tim_B Values ( '" + txtKodeTimB.Text + "','" + txtKodePesertaB.Text + "')";
                            cmd = new SqlCommand(ssql, conn);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Data Berhasil DiTambahkan");
                    Bersihkan();
                    TampilDataJadwal();
                    AutoKodeJadwal();
                    AutoKodeTimA();
                    AutoKodeTimB();

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
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
        }
    }
}
