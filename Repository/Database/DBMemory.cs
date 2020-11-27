using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Repository.Database
{
    public class DBMemory : IMemory
    {
        private readonly IDB db;
        SqlConnection con;
        public DBMemory(IDB _db)
        {
            this.db = _db;
        }

        public List<Model.Memory> Memories()
        {
            //DB = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
             con = this.db.getDB();

            SqlCommand cmd = new SqlCommand("Select * from Memory", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Memory> memories = new List<Memory>();
            while (reader.Read())
            {
                memories.Add(new Memory
                {
                    ID = Convert.ToInt32(reader[0]),
                    HDD= reader[1].ToString(),
                    SSD = reader[2].ToString()
                });
            }
            con.Close();
            return memories;
        }
    }
}
