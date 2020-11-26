using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Interfaces;

namespace ComputerAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RamController : Controller
    {
        private readonly IRam ram;

        public RamController(IRam _ram)
        {
            this.ram = _ram;

        }
        [HttpGet]
        public ActionResult<List<RAM>> get()
        {
            return Ok(ram.Rams());
        }
    }
}
