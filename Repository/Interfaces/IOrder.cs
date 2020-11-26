using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IOrder
    {
        void SetOrder();
        IEnumerable<Order> GetOrder();
    }
}
