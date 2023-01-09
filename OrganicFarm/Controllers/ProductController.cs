using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganicFarm.Models;
using OrganicFarm.OrganicFarmData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFarm.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IOrganicProduct _OrganicProduct;

        public ProductController(IOrganicProduct organicProduct)
        {
            _OrganicProduct = organicProduct;
        }
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult getOrganicProduct()
        {
            return Ok(_OrganicProduct.getOrganicProduct());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult getOrganicProduct(int id)
        {
            return Ok(_OrganicProduct.getOrganicProduct(id));
        }


        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult addOrganicProduct(Product organicProduct)
        {
            return Ok(_OrganicProduct.AddOrganicProduct(organicProduct));
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult deleteOrganicProduct(int id)
        {
            var op = _OrganicProduct.getOrganicProduct(id);

            if (op != null)
            {
                _OrganicProduct.DeleteOrganicProduct(op);
                return Ok();
            }
            else
            {
                return NotFound("Not Found");
            }


        }

        [HttpPut]
        [Route("api/[controller]/{id}")]

        public IActionResult editOrganicProduct(int id)
        {
            var op = _OrganicProduct.getOrganicProduct(id);

            if (op != null)
            {

                return Ok(_OrganicProduct.EditOrganicProduct(op));
            }
            else
            {
                return NotFound("Not Found");
            }


        }
    }
}
