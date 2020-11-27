using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Repository.Database
{
    public class DBCPU : ICPU
    {
        
        private readonly IDB db;
        SqlConnection con;
        public DBCPU(IDB _db)
        {
            this.db = _db;
        }

        public List<Model.CPU> Processors()
        {
            //DB = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
             con = this.db.getDB();

            SqlCommand cmd = new SqlCommand("Select * from CPU", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CPU> processors= new List<CPU>();
            while (reader.Read())
            {
                processors.Add(new CPU
                {
                    ID = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString()
                });
            }
            con.Close();
            return processors;
        }
    }
}
