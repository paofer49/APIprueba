using APIprueba.Data;
using APIprueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIprueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tabla1Controller : ControllerBase
    {
        private readonly AppDBcontext _db;

        public Tabla1Controller(AppDBcontext db)
        {
            _db = db;
        }

        // GET: api/<Tabla1Controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consulta = _db.Tabla1.ToListAsync();
            return Ok(new { exito = true, consulta});
        }

        // GET api/<Tabla1Controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var consulta = _db.Tabla1.Where(x => x.Id.Equals(id)).ToListAsync();
            return Ok(new { exito = true, consulta });
        }

        // POST api/<Tabla1Controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tabla1 registro)
        {
            _db.Tabla1.Add(registro);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { Id = registro.Id },
                new
                {
                    OK = true,
                    mensaje = "Registro creado exitosamente",
                    data = registro
                });
        }

        // PUT api/<Tabla1Controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tabla1 registro)
        {
            var consulta = await _db.Tabla1.FindAsync(id);
            consulta.Id = registro.Id;
            consulta.Nombre = registro.Nombre;

            _db.Entry(consulta).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok(
                new
                {
                    OK = true,
                    mensaje = "Registro creado exitosamente",
                    data = registro
                });
        }

        // DELETE api/<Tabla1Controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _db.Tabla1.FindAsync(id);
            _db.Tabla1.Remove(consulta);

            await _db.SaveChangesAsync();

            return Ok(
                new
                {
                    OK = true,
                    mensaje = "Registro creado exitosamente",
                    data = consulta
                });
        }
    }
}
