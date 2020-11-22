using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;

namespace ComputerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IComputer com;
        
        public WeatherForecastController(IComputer _computer)
        {
            com = _computer; 
        }

        [HttpGet]
        public List<Model.Computer> Get()
        {
            return com.Computers();
        }
    }
}
