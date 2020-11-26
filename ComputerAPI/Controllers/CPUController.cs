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
    public class CPUController : Controller
    {
        private readonly ICPU cpu;
        public CPUController(ICPU _cpu)
        {
            cpu = _cpu;
        }
        [HttpGet]
        public ActionResult<List<CPU>> Get()
        {
            return cpu.Processors();
        }
    }
}
