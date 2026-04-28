using APIprueba.Data;
using APIprueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIprueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly AppDBcontext _db;

        public CarsController(AppDBcontext db)
        {
            _db = db;
        }
        // GET: api/<CarsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consulta = _db.Cars.ToListAsync();
            return Ok(new { exito = true, consulta });
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var consulta = _db.Cars.Where(x => x.Id.Equals(id)).ToListAsync();
            return Ok(new { exito = true, consulta });
        }

        // POST api/<CarsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cars car)
        {
            _db.Cars.Add(car);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {Id = car.Id},
                new
                {
                    OK = true,
                    mensaje = "Registro creado exitosamente",
                    data = car
                });
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cars cars)
        {
            var consulta = await _db.Cars.FindAsync(id);
            consulta.Id = cars.Id;
            consulta.Name = cars.Name;
            consulta.Color = cars.Color;

            _db.Entry(consulta).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok(
                new
                {
                    OK = true,
                    mensaje = "Registro creado exitosamente",
                    data = cars
                });
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _db.Cars.FindAsync(id);

            _db.Cars.Remove(consulta);
            await _db.SaveChangesAsync();

            return Ok(
                new
                {
                    OK = true,
                    mensaje = "Registro creado exitosamente",
                    data = consulta
                });

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] Dictionary<string, object> actualizar)
        {
            var consulta = await _db.Cars.FindAsync(id);

            foreach (var item in actualizar)
            {
                switch (item.Key.ToLower())
                {
                    case "name":
                        consulta.Name = item.Value.ToString();
                        break;

                    case "color":
                        consulta.Color = item.Value.ToString();
                        break;

                    default:
                        break;
                }
            }

            await _db.SaveChangesAsync();

            return Ok(
                new
                {
                    OK = true,
                    mensaje = "Registro actualizado exitosamente",
                    data = consulta
                });
        }
    }
}
