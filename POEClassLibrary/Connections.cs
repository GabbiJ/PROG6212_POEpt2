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
            string strCon = @"Server=tcp:st10034968server.database.windows.net,1433;Initial Catalog=ST10034968_PROG6212_POE;Persist Security Info=False;User ID=ST10034968;Password=@Dvtech123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return new SqlConnection(strCon);
        }
    }
}
