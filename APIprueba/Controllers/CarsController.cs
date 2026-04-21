using APIprueba.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIprueba.Models;

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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cars cars)
        {
            if (id != cars.Id)
                return BadRequest(new { exito = false, mensaje = "El ID no coincide" });

            var existing = await _db.Cars.FindAsync(id);

            if (existing == null)
                return NotFound(new { exito = false, mensaje = "El ID no fue encontrado" });

            existing.Name = cars.Name;
            existing.Color = cars.Color;

            await _db.SaveChangesAsync();

            return Ok(new { exito = true, existing });
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
