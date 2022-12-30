using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj___UAS
{
    internal static class Program
    {
        public static string kdEvent, nmEvent, plg, lok;
        public static string kdPsrt, nmTim;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTambahJadwal());
        }
    }
}
