using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.Database
{
    internal class DatabaseConnection
    {


        public void DBConnect(ref SqlConnection cnBogsy) 
        
        {
            cnBogsy = new SqlConnection("Data Source=.\\MSSQL2025;Initial Catalog=bogsyDatabase;User ID=sa;Password=12345678;TrustServerCertificate=True");
        }

    }
}
