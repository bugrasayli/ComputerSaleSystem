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
    public class MemoryController : Controller
    {
        private readonly IMemory memory;

        public MemoryController(IMemory _memory)
        {
            this.memory = _memory;

        }
        [HttpGet]
        public ActionResult<List<Memory>> get()
        {
            return Ok(memory.Memories());
        }
    }
}
