using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Database
{
    public class DBType : IType
    {
        private readonly IDB db;
        List<Model.Type> types;
        SqlConnection con;

        public DBType(IDB _db)
        {
            db = _db;
        }

        public List<Model.Type> Types()
        {
            con = db.getDB();
            con.Open();
            types = new List<Model.Type>();
            SqlCommand cmd = new SqlCommand("Select * from Type",con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                types.Add(new Model.Type
                {
                    ID = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString()
                }); ;
            }
            con.Close();
            return types;
        }
    }
}
