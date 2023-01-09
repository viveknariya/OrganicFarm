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
    public class RoleController : ControllerBase
    {
        private IRole _Role;
        public RoleController(IRole role)
        {
            _Role = role;
        }


        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult getRole()
        {
            return Ok(_Role.getTblRole());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult getRole(int id)
        {
            return Ok(_Role.getTblRole(id));
        }


        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult addRole(Role role)
        {
            return Ok(_Role.AddTblRole(role));
        }
    }
}
