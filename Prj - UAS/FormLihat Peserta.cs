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
    public partial class FormLihat_Peserta : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        public FormLihat_Peserta()
        {
            InitializeComponent();
        }

        //Koneksi
        Koneksi Konn = new Koneksi();

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

        private void FormLihat_Peserta_Load(object sender, EventArgs e)
        {
            TampilData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            Program.kdPsrt = row.Cells["Kode_Tim"].Value.ToString();
            Program.nmTim = row.Cells["Nama_Tim"].Value.ToString();
            
            this.Close();
        }
    }
}
