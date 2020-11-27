using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Database
{
    public class DBCountry : ICountry
    {
        private readonly IDB db;
        List<Country> countries;
        private SqlConnection con;
        public DBCountry(IDB _db)
        {
            this.db = _db;
        }
        public List<Country> Countries()
        {
            con = db.getDB();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * form Country");
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                countries.Add(new Country
                {
                    ID = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString()
                });
            }
            con.Close();
            return countries;
        }
    }
}
