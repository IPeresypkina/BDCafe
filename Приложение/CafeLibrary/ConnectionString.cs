using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeLibrary
{
    class ConnectionString
    {
        public bool Open(SqlConnection conn)
        {
            try
            {
                conn.ConnectionString = "Data Source=DESKTOP-5E5L14V;Initial Catalog=cafe;Integrated Security=True";
                conn.Open();
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }

        }
    }
}
