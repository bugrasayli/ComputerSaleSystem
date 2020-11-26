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
            computer = _computer;
            orders = new List<Order>();
            List<Computer> computers = new List<Computer>();
            computers.Add(computer.Computers().Where(x => x.ID == 0).FirstOrDefault());
            computers.Add(computer.Computers().Where(x => x.ID == 1).FirstOrDefault());
            
            
            List<Computer> computers2 = new List<Computer>();
            computers2.Add(computer.Computers().Where(x => x.ID == 3).FirstOrDefault());
            computers2.Add(computer.Computers().Where(x => x.ID == 3).FirstOrDefault());
            computers2.Add(computer.Computers().Where(x => x.ID == 4).FirstOrDefault());
            Order order = new Order();

            orders.Add(new Order
            {
                Name = "Bugra",
                Surname = "Sayli",
                Address1 = "Griciup G.9 Kaunas/Lithuania",
                Address2 = "A.Pureno G20",
                Computers = computers,
                Email = "bugrasayli@gmail.com",
                OrderedTime = DateTime.Now,
                Phone = "+37064641038"
            });
            orders.Add(new Order
            {
                Name = "Kemal",
                Surname = "Yeğin",
                Address1 = "Griciupu G.9 Kaunas/Lithuania",
                Address2 = "A.Pureno G35",
                Computers = computers2,
                Email = "kemalyegin@gmail.com",
                OrderedTime = DateTime.Now,
                Phone = "+37062623134"
            });
        }
        public IEnumerable<Order> GetOrder()
        {
            return orders;
        }

        public void SetOrder()
        {
            Order order = new Order();
            throw new NotImplementedException();
        }
    }
}
