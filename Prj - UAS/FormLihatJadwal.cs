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
    public partial class FormLihatJadwal : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        public FormLihatJadwal()
        {
            InitializeComponent();
        }

        //Koneksi
        Koneksi Konn = new Koneksi();

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

        private void FormLihatJadwal_Load(object sender, EventArgs e)
        {
            TampilDataJadwal();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            Program.kdJdwl = row.Cells["Kode_Jadwal"].Value.ToString();
            Program.kdEvent = row.Cells["Kode_Event"].Value.ToString();
            Program.nmEvent = row.Cells["Nama_Event"].Value.ToString();
            Program.ttg = row.Cells["Tanggal"].Value.ToString();
            Program.kdTimA = row.Cells["Kode_TimA"].Value.ToString();
            Program.kdtim1 = row.Cells["Kode_Tim"].Value.ToString();
            Program.nmTimA = row.Cells["Nama_TimA"].Value.ToString();
            Program.kdTimB = row.Cells["Kode_TimB"].Value.ToString();
            Program.kdtim2 = row.Cells["Kode_Tim2"].Value.ToString();
            Program.nmTimB = row.Cells["Nama_TimB"].Value.ToString();

            this.Close();
        }

        
    }
}
