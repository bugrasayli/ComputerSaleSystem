using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace ComputerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeController : Controller
    {
        private readonly IType type;

        public TypeController(IType _type)
        {
            this.type= _type;
        }
        [HttpGet]
        public ActionResult<List<Model.Type>> get()
        {
            return Ok(type.Types());
        }
    }
}
