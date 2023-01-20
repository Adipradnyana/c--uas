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
    public partial class FormLihatSkor : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        public FormLihatSkor()
        {
            InitializeComponent();
        }

        //Koneksi
        Koneksi Konn = new Koneksi();

        void TampilSkor()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT Kode_Hasil,Tim_A.Kode_TimA,Tim_A.Kode_Tim,P1.Nama_Tim,Skor_TimA,Tim_B.Kode_TimB,Tim_B.Kode_Tim,P2.Nama_Tim,Skor_TimB FROM HASIL \r\nINNER JOIN Tim_A ON Tim_A.Kode_TimA = Hasil.Kode_TimA\r\nINNER JOIN Tim_B ON Tim_B.Kode_TimB = Hasil.Kode_TimB\r\nINNER JOIN Peserta AS P1 ON P1.Kode_Tim = Tim_A.Kode_Tim\r\nINNER JOIN Peserta AS P2 ON P2.Kode_Tim = Tim_B.Kode_Tim", conn);
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

        private void FormLihatSkor_Load(object sender, EventArgs e)
        {
            TampilSkor();
        }
    }
}
