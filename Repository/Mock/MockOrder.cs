using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Linq;

namespace Repository.Repo
{
    public class MockOrder : IOrder
    {
        private readonly IComputer computer;
        private List<Order> orders;
        public MockOrder(IComputer _computer)
        {
            orders =  new List<Order>(); 
            computer = _computer;
            List<Computer> Cart = new List<Computer>();
            Cart.Add(computer.Computers().Where(x => x.ID == 0).FirstOrDefault());
            Cart.Add(computer.Computers().Where(x => x.ID == 1).FirstOrDefault());
            
            Order Order1 = new Order();
            Order1.ID = 1;
            Order1.Name = "Buğra";
            Order1.Surname = "Sayli";
            Order1.Address1= "Griciup G.9 Kaunas/Lithuania";
            Order1.Address2= "A.Pureno G20";
            Order1.Email= "bugrasayli@gmail.com";
            Order1.OrderedTime = DateTime.Now;
            Order1.Phone = "+37064641038";

            List<Computer> OrderCom = new List<Computer>();
            foreach (var item in Cart)
            {
                if (item.Detail.StockSize > 0)
                {
                    OrderCom.Add(item);
                    item.Detail.StockSize -= 1;
                }
            }
            Order1.Computers = OrderCom;
            orders.Add(Order1);

            List<Computer> Cart2 = new List<Computer>();
            Cart2.Add(computer.Computers().Where(x => x.ID == 3).FirstOrDefault());
            Cart2.Add(computer.Computers().Where(x => x.ID == 3).FirstOrDefault());
            Cart2.Add(computer.Computers().Where(x => x.ID == 4).FirstOrDefault());



            Order order2= new Order();
            order2.ID = 2 ;
            order2.Name = "Kemal";
            order2.Surname = "Yeğin";
            order2.Address1 = "Griciupu G.9 Kaunas/Lithuania";
            order2.Address2 = "A.Pureno G35";
            order2.Email = "kemalyegin@gmail.com";
            order2.OrderedTime= DateTime.Now ;
            order2.Phone = "+37062623134";

            List<Computer> OrderCom2 = new List<Computer>();
            foreach (var item in Cart2)
            {
                if(item.Detail.StockSize>0)
                {
                    OrderCom2.Add(item);
                    item.Detail.StockSize -= 1;
                }
            }
            order2.Computers = OrderCom2;
            orders.Add(order2);

        }
        public IEnumerable<Order> GetOrder()
        {
            return orders;
        }

        public IEnumerable<Order> GetOrderByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void SetOrder(Order order)
        {
            List<Computer> Computers = new List<Computer>();
            foreach (var item in order.Computers)
            {
                Computer computer = this.computer.Computer(item.ID);
                if(computer.Detail.StockSize != 0)
                {
                    computer.Detail.StockSize -= 1;
                    Computers.Add(computer);
                }
            }
            order.Computers = Computers;
            order.OrderedTime = DateTime.Now;
            orders.Add(order);
        }
    }
}
