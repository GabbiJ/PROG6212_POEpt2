using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEClassLibrary
{
    public class Connections
    {
        public static SqlConnection GetConnection()
        {
            string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PROG6212_POEPART2;Integrated Security=True";
            return new SqlConnection(strCon);
        }
    }
}
