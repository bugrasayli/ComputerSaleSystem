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
    public class GraphicController : Controller
    {
        private readonly IGraphicCard grap;

        public GraphicController(IGraphicCard _grap)
        {
            this.grap= _grap;

        }
        [HttpGet]
        public ActionResult<List<GraphicCard>> get()
        {
            return Ok(grap.GraphicCards());
        }
    }
}
