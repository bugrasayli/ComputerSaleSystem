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
            String a = "Select Type.ID,Type.Name,Count(Computer.ID) from Type LEFT JOIN Computer on Computer.TypeID = Type.ID group by Type.Name,Type.ID";
            SqlCommand cmd = new SqlCommand(a,con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                types.Add(new Model.Type
                {
                    ID = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString(),
                    Count = Convert.ToInt32(reader[2])
                }); ;
            }
            con.Close();
            return types;
        }
    }
}
