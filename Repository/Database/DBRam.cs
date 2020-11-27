using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Repository.Database
{
    public class DBRam : IRam
    {
        private readonly IDB db;
        SqlConnection con;
        public DBRam(IDB _db)
        {
            this.db = _db;
        }

        public List<Model.RAM> Rams()
        {
            //DB = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
             con = this.db.getDB();

            SqlCommand cmd = new SqlCommand("Select * from Ram", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<RAM> rams = new List<RAM>();
            while (reader.Read())
            {
                rams.Add(new RAM
                {
                    ID = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString()
                });
            }
            con.Close();
            return rams;
        }
    }
}
