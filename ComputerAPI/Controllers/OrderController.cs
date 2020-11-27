using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Interfaces;
namespace ComputerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder order;
        IEnumerable<Order> orders= new List<Order>();
        public OrderController(IOrder _order)
        {
            order = _order;
        }
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            
            orders = order.GetOrderByID(1);
            return orders;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public IEnumerable<Order> Post([FromBody] Order value)
        {
            if (value == null || value.Computers.Count == 0)
            {
                return order.GetOrder();
            }
            else
            {
                order.SetOrder(value);
                return order.GetOrder();
            }
        }
    }
}
