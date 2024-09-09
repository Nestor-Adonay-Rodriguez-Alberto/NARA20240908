using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NARA20240908.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        // Listas De Obejtos:  
        static List<object> Lista_Notas = new List<object>();


        // GET: api/<ProtetedController>
        // Muestra Todos Los Registros De La Lista:
        [HttpGet]
        [AllowAnonymous] // Acceso Publico
        public IEnumerable<object> ObtenerNotas()
        {
            return Lista_Notas;
        }


        // POST api/<ProtetedController>
        // Agrega Un Nuevo Registro A La Lista:
        [HttpPost]
        [Authorize] // Acceso Privado
        public IActionResult RegistrarNotas(string nota)
        {
            Lista_Notas.Add(new { nota});

            return Ok();
        }


    }
}
