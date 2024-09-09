using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NARA20240908.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        // METODO #1:
        [HttpPost("login")]
        public IActionResult Login(string login, string password)
        {

            // Validar Las Credenciales:
            if (login == "admin" && password == "12345")
            {
                // Lista reclamaciones (claims):
                var claims = new List<Claim>
                {
                    // agrega una reclamacion de nombre con el valor de login:
                    new Claim(ClaimTypes.Name, login),
                };


                // Crea una identidad de reclamaciones (Claim Identity)
                // Con el esquema de autentificacion por cookies
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                // Crea propiedades de autorizacion adicionales:
                var authProperties = new AuthenticationProperties { };


                // Inicia sesion del usuario:
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);

                // Respuesta Exitosa:
                return Ok("Inicio Sesion Correctamente.");
            }
            else
            {
                // Respuesta Denegada:
                return Unauthorized("Credenciales Incorrectas");
            }
        }



        // METODO #2:
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Cierra La Session Del Usuario:
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Debuelve la respuesta Exitosa:
            return Ok("Cerro Cesion Correctamente");
        }


    }
}
