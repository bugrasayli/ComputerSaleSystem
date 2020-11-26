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
        public OrderController(IOrder _order)
        {
            order = _order;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return order.GetOrder();
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] Order value)
        {
        }
    }
}
