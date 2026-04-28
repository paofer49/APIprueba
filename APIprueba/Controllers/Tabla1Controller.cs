using APIprueba.Data;
using APIprueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Text.Json;

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
            consulta.Cantidad = registro.Cantidad;
            consulta.Descripcion = registro.Descripcion;

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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTabla1(int id, [FromBody] Dictionary<string, object> actualizar) 
        {
            var consulta = await _db.Tabla1.FindAsync(id);

            foreach (var item in actualizar)
            {
                switch (item.Key.ToLower())
                {
                    case "nombre":
                        consulta.Nombre = item.Value.ToString();
                        break;

                    case "cantidad":
                        consulta.Cantidad = ConvertInt(item.Value);
                        break;

                    case "descripcion":
                        consulta.Descripcion = item.Value.ToString();
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

        private int ConvertInt(object valor)
        {
            if (valor == null)
            {
                return 0;
            }
            if (valor is JsonElement elementoJson)
            {
                return elementoJson.GetInt32();
            }
            if (valor is string cadenaValor)
            {
                return int.Parse(cadenaValor);
            }

            return Convert.ToInt32(valor);
        }
    }
}
