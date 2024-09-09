using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NARA20240908.Models;

namespace NARA20240908.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Acceso Privado
    public class MatriculaController : ControllerBase
    {
        // Listas De Obejtos:  
        static List<Matricula> Lista_Matriculas = new List<Matricula>();



        // GET: api/<ProtetedController>/5
        // Obtiene Un Registro Con Ese ID:
        [HttpGet]
        public Matricula ObtenerPorIdMatricula(int id)
        {
            Matricula Objeto_Obtenido = Lista_Matriculas.FirstOrDefault(x => x.IdMatricula == id);

            return Objeto_Obtenido;
        }


        // POST api/<ProtetedController>
        // Agrega Un Nuevo Registro A La Lista:
        [HttpPost]
        public IActionResult CrearMatricula([FromBody] Matricula matricula)
        {
            Lista_Matriculas.Add(matricula);

            return Ok();
        }

        // PUT : Obtiene un Objeto con ese ID Y Lo Modifica:
        [HttpPut("{id}")]
        public IActionResult ModificarMatricula(int id, [FromBody] Matricula matricula)
        {
            Matricula Objeto_Obtenido = Lista_Matriculas.FirstOrDefault(x => x.IdMatricula == id);

            if (Objeto_Obtenido != null)
            {
                Objeto_Obtenido.IdMatricula = matricula.IdMatricula;
                Objeto_Obtenido.Carrera = matricula.Carrera;

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
