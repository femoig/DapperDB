using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDB.ConsoleApp.DAO
{
    public class DatabaseConnection
    {
        string _connectionString = "";


        public DatabaseConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
