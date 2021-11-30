using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PayrollSystem
{
    class Connection
    {
        SqlConnection conn;

        public SqlConnection getConnect()
        {
            conn = new SqlConnection("Data Source=DESKTOP-R3P2SAF\\SQLEXPRESS;Initial Catalog=PayrollSystemWInsert;Integrated Security=True");
            return conn;
        }
    }
}
