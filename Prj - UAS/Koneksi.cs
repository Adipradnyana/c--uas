using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Prj___UAS
{
    internal class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = @"Data Source = localhost\sqlexpress; initial catalog = event_olahraga; integrated security = true";
            return Conn;
        }
    }
}
