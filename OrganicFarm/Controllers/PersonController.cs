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
    public class PersonController : ControllerBase
    {
        private IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult getPerson()
        {
            return Ok(_person.getPerson());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult getPerson(int id)
        {
            return Ok(_person.getPerson(id));
        }


        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult addPerson(Person person)
        {
            return Ok(_person.AddPerson(person));
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult deletePerson(int id)
        {
            var p = _person.getPerson(id);

            if(p != null)
            {
                _person.DeletePerson(p);
                return Ok();
            }
            else
            {
                return NotFound("Not Found");
            }

            
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]

        public IActionResult editPerson(int id)
        {
            var p = _person.getPerson(id);

            if (p != null)
            {

                return Ok(_person.EditPerson(p));
            }
            else
            {
                return NotFound("Not Found");
            }


        }
    }
}
