using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository
{
    public class SqlDB : IDB
    {
        private string SqlConnection = "Server=DESKTOP-4B177VT\\BUGRA;Database=Computer;Trusted_Connection=True;";
        public SqlConnection getDB()
        {
            SqlConnection con = new SqlConnection(SqlConnection);
            return con;
        }
    }
}
