using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IOrder
    {
        void SetOrder(Order order);
        IEnumerable<Order> GetOrder();
        IEnumerable<Order> GetOrderByID(int ID);
    }
}
