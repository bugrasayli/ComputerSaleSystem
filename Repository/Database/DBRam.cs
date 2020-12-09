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

            String a = "Select Ram.ID,Ram.Size,Count(Computer.ID) from Ram LEFT JOIN Computer on Computer.RamID = Ram.ID group by Ram.Size,Ram.ID";
            SqlCommand cmd = new SqlCommand(a, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<RAM> rams = new List<RAM>();
            while (reader.Read())
            {
                rams.Add(new RAM
                {
                    ID = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString(),
                    Count = Convert.ToInt32(reader[2])
                }) ;
            }
            con.Close();
            return rams;
        }
    }
}
