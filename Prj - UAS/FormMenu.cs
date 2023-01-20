using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj___UAS
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

       

        private void btInputEvent_Click(object sender, EventArgs e)
        {
            FormTambahEvent formtambahevent = new FormTambahEvent();
            formtambahevent.ShowDialog();
        }

        private void btInputPeserta_Click(object sender, EventArgs e)
        {
            FormTambahPeserta formtambahpeserta = new FormTambahPeserta();
            formtambahpeserta.ShowDialog();
        }

        private void btInputJadwal_Click(object sender, EventArgs e)
        {
            FormTambahJadwal formtambahjadwal = new FormTambahJadwal();
            formtambahjadwal.ShowDialog();
        }

        private void btInputHasil_Click(object sender, EventArgs e)
        {
            FormTambahHasil formtambahhasil = new FormTambahHasil();
            formtambahhasil.ShowDialog();
        }

        private void btLihatEvent_Click(object sender, EventArgs e)
        {
            FormLihatEvent formlihatevent = new FormLihatEvent();
            formlihatevent.ShowDialog();
        }

        private void btLihatPeserta_Click(object sender, EventArgs e)
        {
            FormLihatPeserta formlihatpeserta = new FormLihatPeserta();
            formlihatpeserta.ShowDialog();
        }

        private void btLihatJadwal_Click(object sender, EventArgs e)
        {
            FormLihatJadwal formlihatjadwal = new FormLihatJadwal();
            formlihatjadwal.ShowDialog();
        }

        private void btLihatSkor_Click(object sender, EventArgs e)
        {
            FormLihatSkor formlihatSkor = new FormLihatSkor();
            formlihatSkor.ShowDialog();
        }

        private void btLihatHasil_Click(object sender, EventArgs e)
        {
            FormLihatHasil formlihatHasil = new FormLihatHasil();
            formlihatHasil.ShowDialog();
        }
    }
}
