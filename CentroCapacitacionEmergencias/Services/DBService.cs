using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

namespace CentroCapacitacionEmergencias.Services
{
    public class DBService
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

            return new SqlConnection(connectionString);
        }

        public static void TestConnection()
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
            }
        }
    }
}