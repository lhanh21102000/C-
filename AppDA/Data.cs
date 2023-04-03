using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDA
{
    class Data
    {
        public static SqlConnection data1() {
            string datasource = @"LAPTOP-THR4ECBT\SQLEXPRESS";

            string database = "ab";
            string username = "sa";
            string password = "sa123";


             string strcon = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

           
            return Connect.ketnoi(datasource, database, username, password);
        }
    }
}
