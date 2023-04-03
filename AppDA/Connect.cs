using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDA
{
    class Connect
    {
        public static SqlConnection ketnoi(string datasource, string database , string username, string password)
        {
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                     + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
