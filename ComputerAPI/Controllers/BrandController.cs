using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Interfaces;

namespace ComputerAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        private readonly IBrand brand;

        public BrandController(IBrand _brand)
        {
            this.brand = _brand;

        }
        [HttpGet]
        public ActionResult<List<Brand>> get()
        {
            return Ok(brand.Brands());
        }
    }
}
