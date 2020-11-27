using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Repository.Database
{
    public class DBBrand : IBrand
    {
        
        List<Brand> brands;
        private readonly IDB db;
        SqlConnection con;
        public DBBrand(IDB _db)
        {
            this.db = _db;
        }

        public List<Model.Brand> Brands()
        {
            //DB = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
             con = this.db.getDB();

            SqlCommand cmd = new SqlCommand("Select * from Brand", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Brand> brands = new List<Brand>();
            while (reader.Read())
            {
                brands.Add(new Brand
                {
                    ID = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString()
                });
            }
            con.Close();
            return brands;
        }
    }
}
