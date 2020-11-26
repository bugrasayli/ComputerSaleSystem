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
    public class ComputerController : ControllerBase
    {
        private readonly IComputer com;
        public ComputerController(IComputer _computer)
        {
            com = _computer;
        }

        [HttpGet]
        public List<Model.Computer> Get()
        {
            return com.Computers();
        }


        [Route("[action]/{ID}")]
        public ActionResult<List<Model.Computer>> GetByBrand(int ID)
        {
            return Ok(com.Computers(new Brand { ID = ID }));
        }
        [Route("[action]/{ID}")]
        public ActionResult<List<Model.Computer>> GetByCPU(int ID)
        {
            return Ok(com.Computers(new CPU { ID = ID }));
        }

        [Route("[action]/{ID}")]
        public ActionResult<List<Model.Computer>> GetByGraphic(int ID)
        {
            return Ok(com.Computers(new GraphicCard { ID = ID }));
        }

        [Route("[action]/{ID}")]
        public ActionResult<List<Model.Computer>> GetByMemory(int ID)
        {
            return Ok(com.Computers(new Memory { ID = ID }));
        }

        [Route("[action]/{ID}")]
        public ActionResult<List<Model.Computer>> GetByType(int ID)
        {
            return Ok(com.Computers(new Model.Type { ID = ID }));
        }
        [Route("[action]/{ID}")]
        public ActionResult<List<Model.Computer>> GetByRam(int ID)
        {
            return Ok(com.Computers(new RAM { ID = ID }));
        }
    }
}

