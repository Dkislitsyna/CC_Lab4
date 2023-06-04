using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Last.Models;

namespace Last.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class CarsController : ControllerBase
        {
            private static List<Car> avto = new List<Car>();

            [HttpGet]
            public ActionResult<IEnumerable<Car>> Get()
            {
                return avto;
            }

            [HttpGet("{id}")]
            public ActionResult<Car> Get(int id)
            {
                if (avto.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

                return avto[id];
            }

            [HttpPost]
            public void Post(Car value)
            {
                avto.Add(value);
            }

            [HttpPut("{id}")]
            public void Put(int id, Car value)
            {
                if (avto.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

                avto[id] = value;
            }

            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                if (avto.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

                avto.RemoveAt(id);
            }
        }
}
