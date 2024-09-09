using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AGREGADA: Configuracion Para La Autentificacion De Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {

        // Configura el nombre del parametro de URL para redireccionamiento no autorizado
        options.ReturnUrlParameter = "unauthorized";

        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {
                // Cambia el codigo de estado a no autorizado
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                // Establece el tipo de contenido  como JSON (u otro formato):
                context.Response.ContentType = "application/json";

                // Objeto:
                var message = new { error = "No autorizado", message = "Debe iniciar sesion para acceder a este recurso" };

                // Serializa el Objeto en formato JSON 
                var jsonMessage = JsonSerializer.Serialize(message);

                return context.Response.WriteAsync(jsonMessage);
            }
        };

    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Agregada En este Orden
app.UseAuthorization();
app.MapControllers();

app.Run();
