using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        bdnotas2020Context db = new bdnotas2020Context();
        // GET: api/<CursosController>
        [HttpGet]
        public IEnumerable<Cursos> Get()
        {
            return db.Cursos.ToList();
        }

        // GET api/<CursosController>/5
        [HttpGet("{id}")]
        public Cursos Get(string id)
        {
            return db.Cursos.Find(id);
        }

        [HttpGet("response/{id}")]
        public ActionResult GetActionResult(string id)
        {
            Cursos obj = db.Cursos.Find(id);
            if (obj == null)
            {
                return NotFound(new ResponseStatus(404, $"No se ha encontrado el id: {id}", null));
            }
            return Ok(new ResponseStatus(200, "Se encontro con exito", obj));
        }
        // POST api/<CursosController>
        [HttpPost]
        public ActionResult Post([FromBody] Cursos value)
        {
            Cursos obj = db.Cursos.Find(value.Codcurso);
            if (obj != null)
            {
                return BadRequest(new ResponseStatus(404, $"El codigo {value.Codcurso} ya existe", null));
            }
            db.Cursos.Add(value);
            db.SaveChanges();

            return Ok(new ResponseStatus(201, "Se registro con exito", value));
        }

        // PUT api/<CursosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Cursos value)
        {
            Cursos obj = db.Cursos.Find(id);
            // si no encuentra el curso que voy a  actualizar
            if (obj == null)
            {
                return BadRequest(new ResponseStatus(404, $"El codigo no {id} existe", null));
            }

            obj.Nomcurso = value.Nomcurso;
            obj.Nhoras = value.Nhoras;
            obj.Tipo = value.Tipo;
            obj.Eliminado = value.Eliminado;

            db.SaveChanges();

            return Ok(new ResponseStatus(200, "Se actualizo con exito", value));
        }

        // DELETE api/<CursosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {

            Cursos obj = db.Cursos.Find(id);
            // si no encuentra el curso que voy a  borrar
            if (obj == null)
            {
                return BadRequest(new ResponseStatus(404, $"El codigo no {id} existe", null));
            }
            // eliminacion fisica
            // db.Cursos.Remove(obj);

            obj.Eliminado = "Si";
            db.SaveChanges();
            return Ok(new ResponseStatus(200, $"Se ha borrado con exito id: {id}", obj));
        }
    }
}
