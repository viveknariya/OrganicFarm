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
    public class ShopController : ControllerBase
    {
        private IOrganicShop _shop;
        public ShopController(IOrganicShop shop)
        {
            _shop = shop;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult getShop()
        {
            return Ok(_shop.getOrganicShop());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult getShop(int id)
        {
            return Ok(_shop.getOrganicShop(id));
        }


        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult addShop(OrganicShop shop)
        {
            return Ok(_shop.AddOrganicShop(shop));
        }
    }
}

