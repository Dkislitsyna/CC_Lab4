using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Last.Models;
using Last.Storage;


namespace Last.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class CarsController : ControllerBase
        {
            
            private IStorage<Car> avto;

            public CarsController(IStorage<Car> _avto)
            {
                avto = _avto;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Car>> Get()
            {
                return Ok(avto.All);
            }

            [HttpGet("{id}")]
            public ActionResult<Car> Get(Guid id)
            {
                if (!avto.Has(id)) return NotFound("No such");


                return Ok(avto[id]);
            }

            [HttpPost]
            public IActionResult Post(Car value)
            {
                var validationResult = value.Validate();
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                avto.Add(value);
                return Ok($"{value} has been added");
            }

            [HttpPut("{id}")]
            public IActionResult Put(Guid id, Car value)
            {
                if (!avto.Has(id)) return NotFound("No such");
                var validationResult = value.Validate();
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
                var previousValue = avto[id];
                avto[id] = value;
                return Ok($"{previousValue} has been updated to {value}");
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(Guid id)
            {
                if (!avto.Has(id)) return NotFound("No such");
                var valueToRemove = avto[id];
                avto.RemoveAt(id);
                return Ok($"{valueToRemove} has been removed");
            }
        }
}
