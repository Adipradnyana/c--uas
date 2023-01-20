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
    public partial class FormLihatHasil : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        public FormLihatHasil()
        {
            InitializeComponent();
        }

        //Koneksi
        Koneksi Konn = new Koneksi();

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

        private void FormLihatHasil_Load(object sender, EventArgs e)
        {
            TampilHasil();
        }
    }
}
