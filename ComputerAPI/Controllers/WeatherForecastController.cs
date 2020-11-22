using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
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
        [Route("[action]/{ID}")]
        public ActionResult< List<Model.Computer>> GetByBrand(int ID)
        {
            return Ok( com.Computers(new Brand {ID=ID }));
        }
        [Route("[action]/{ID}")]
        public ActionResult< List<Model.Computer>> GetByCPU(int ID)
        {
            return Ok( com.Computers(new CPU{ID=ID }));
        }
        public ActionResult< List<Model.Computer>> GetByGraphic(int ID)
        {
            return Ok( com.Computers(new GraphicCard{ID=ID }));
        }
        public ActionResult< List<Model.Computer>> GetByMemory(int ID)
        {
            return Ok( com.Computers(new Memory{ID=ID }));
        }
    }
}
