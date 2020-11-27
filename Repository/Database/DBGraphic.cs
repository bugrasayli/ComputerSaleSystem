using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Repository.Database
{
    public class DBGraphic : IGraphicCard
    {
        
        List<Brand> graphics;
        private readonly IDB db;
        SqlConnection con;
        public DBGraphic(IDB _db)
        {
            this.db = _db;
        }

        public List<Model.GraphicCard> GraphicCards()
        {
            //DB = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
             con = this.db.getDB();

            SqlCommand cmd = new SqlCommand("Select * from GraphicCard", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<GraphicCard> graphics = new List<GraphicCard>();
            while (reader.Read())
            {
                graphics.Add(new GraphicCard
                {
                    ID = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString() + " "+reader[2].ToString()
                });
            }
            con.Close();
            return graphics;
        }
    }
}
