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
    public partial class FormLihatEvent : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        public FormLihatEvent()
        {
            InitializeComponent();
        }

        //Koneksi
        Koneksi Konn = new Koneksi();
        
        //Menampilkan Data
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

        private void FormLihatEvent_Load(object sender, EventArgs e)
        {
            TampilData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            Program.kdEvent = row.Cells["Kode_Event"].Value.ToString();
            Program.nmEvent = row.Cells["Nama_Event"].Value.ToString();
            Program.plg = row.Cells["Kode_Event"].Value.ToString();
            Program.lok = row.Cells["Kode_Event"].Value.ToString();

            this.Close();
        }
    }
}
