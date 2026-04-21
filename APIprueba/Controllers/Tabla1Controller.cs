using APIprueba.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Tabla1Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Tabla1Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
