using Eksamensopgave2f.Interfaces;
using Eksamensopgave2f.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eksamensopgave2f.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {
        private readonly IGroceryRepository _repository;

        public GroceryController(IGroceryRepository repository)
        {
            _repository = repository;
        }

        // GET api/grocery
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public IEnumerable<GroceryTable> Get()
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException("Invalid");
            }

           return _repository.Get();

        }

        // POST api/grocery
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] GroceryTable value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Post(value);

            return Created("Get", value);
        }

        // PUT api/grocery/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Put(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Put(id);

            return Ok();
        }

        // DELETE api/grocery/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Delete(id);

            return Ok();

        }

    }
}
