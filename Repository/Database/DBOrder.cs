using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repository.Database
{
    public class DBOrder : IOrder
    {
        private readonly IDB db;
        List<Model.Order> orders;
        SqlConnection con;
        public DBOrder(IDB _db)
        {
            db = _db;
        }
        public IEnumerable<Model.Order> GetOrder()
        {
            con = db.getDB();
            con.Open();
            orders = new List<Model.Order>();
            SqlCommand cmd = new SqlCommand("SELECT [Order].ID,[Order].Name,[Order].Surname,COMPUTER.ID,Computer.Name,[Order].Address1,[Order].Address2,Detail.Price,Computer_Order.Quantity " +
                "from((Computer INNER JOIN Computer_Order on Computer.ID = Computer_Order.ComputerID) " +
                "INNER JOIN[Order] on[Order].ID = Computer_Order.OrderID) " +
                "Inner Join Detail on Detail.ComputerID = Computer.ID", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (orders.Where(x => x.ID == Convert.ToInt32(reader[0])).ToList().Count == 0)
                {
                    List<Computer> computers = new List<Computer>();
                    Detail a = new Detail();
                    a.price = Convert.ToSingle(reader[7]);
                    for (int i = 0; i < Convert.ToInt32(reader[8]); i++)
                    {
                        computers.Add(new Computer { ID = Convert.ToInt32(reader[3]), Name = reader[4].ToString(), Detail = a });
                    }
                    orders.Add(new Order
                    {
                        ID = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString(),
                        Surname = reader[2].ToString(),
                        Address1 = reader[5].ToString(),
                        Address2 = reader[6].ToString(),
                        Computers = computers
                    });
                }
                else
                {
                    Detail det = new Detail();
                    det.price = Convert.ToSingle(reader[7]);
                    Order a = orders.Where(x => x.ID == Convert.ToInt32(reader[0])).FirstOrDefault();
                    for (int i = 0; i < Convert.ToInt32(reader[8]); i++)
                    {

                        a.Computers.Add(new Computer
                        {
                            ID = Convert.ToInt32(reader[3]),
                            Name = reader[4].ToString(),
                            Detail = det

                        });
                    }
                }
            }
            con.Close();
            return orders;
        }
        public IEnumerable<Model.Order> GetOrderByID(int ID)
        {
            con = db.getDB();
            con.Open();
            orders = new List<Model.Order>();
            SqlCommand cmd = new SqlCommand("SELECT [Order].ID,[Order].Name,[Order].Surname,COMPUTER.ID,Computer.Name,[Order].Address1,[Order].Address2,Detail.Price,Computer_Order.Quantity " +
                "from((Computer INNER JOIN Computer_Order on Computer.ID = Computer_Order.ComputerID) " +
                "INNER JOIN[Order] on[Order].ID = Computer_Order.OrderID)  " +
                "Inner Join Detail on Detail.ComputerID = Computer.ID where [Order].ID =" + ID, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (orders.Where(x => x.ID == Convert.ToInt32(reader[0])).ToList().Count == 0)
                {
                    List<Computer> computers = new List<Computer>();
                    Detail a = new Detail();
                    a.price = Convert.ToSingle(reader[7]);
                    for (int i = 0; i < Convert.ToInt32(reader[8]); i++)
                    {
                        computers.Add(new Computer { ID = Convert.ToInt32(reader[3]), Name = reader[4].ToString(), Detail = a });
                    }
                    orders.Add(new Order
                    {
                        ID = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString(),
                        Surname = reader[2].ToString(),
                        Address1 = reader[5].ToString(),
                        Address2 = reader[6].ToString(),
                        Computers = computers
                    });
                }
                else
                {
                    Detail det = new Detail();
                    det.price = Convert.ToSingle(reader[7]);
                    Order a = orders.Where(x => x.ID == Convert.ToInt32(reader[0])).FirstOrDefault();
                    for (int i = 0; i < Convert.ToInt32(reader[8]); i++)
                    {

                        a.Computers.Add(new Computer
                        {
                            ID = Convert.ToInt32(reader[3]),
                            Name = reader[4].ToString(),
                            Detail = det

                        });
                    }
                }
            }
            con.Close();
            return orders;
        }
        public void SetOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
