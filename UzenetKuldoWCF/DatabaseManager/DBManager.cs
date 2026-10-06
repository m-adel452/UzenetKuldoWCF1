using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace UzenetKuldoWCF.DatabaseManager
{
    public class DBManager
    {
        string connectionString = "SERVER = localhost;" +
                         "DATABASE= uzenetkuldo;" +
                         "UID = root;" +
                         "PASSWORD =;";
        public MySqlConnection OpenDB()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            return conn;
        }
    }
}