using Dapper;
using JN_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices.Marshalling;

namespace JN_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("RegistrarUsuario")]
        public async Task<IActionResult> RegistrarUsuario(Usuario ent)
        {
            Respuesta resp = new Respuesta();
            using (var context = new SqlConnection("Server=DESKTOP-236UN97;Database=JUEVES_BD;Trusted_Connection=true;TrustServerCertificate=true"))
            {

                var result = await context.ExecuteAsync("RegistrarUsuario", new { ent.Identificacion, ent.Nombre, ent.Correo, ent.Contrasenna }, commandType: System.Data.CommandType.StoredProcedure);
                if (result > 0)
                {
                    resp.Codigo = 1;
                    resp.Mensaje = "OK";
                    resp.Contenido = true;
                    return Ok(resp);

                }
                else
                {
                    resp.Codigo = 10;
                    resp.Mensaje = "La información del usuario ya se encuentra registrada";
                    resp.Contenido = false;
                    return Ok(resp);

                }
            }
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion(Usuario ent)
        {
            Respuesta resp = new Respuesta();
            using (var context = new SqlConnection("Server=DESKTOP-236UN97;Database=JUEVES_BD;Trusted_Connection=true;TrustServerCertificate=true"))
            {

                var result = await context.QueryAsync<Usuario>("IniciarSesion", new {  ent.Correo, ent.Contrasenna }, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    resp.Codigo = 1;
                    resp.Mensaje = "OK";
                    resp.Contenido = result;
                    return Ok(resp);

                }
                else
                {
                    resp.Codigo = 10;
                    resp.Mensaje = "No hay un usuario con la informaci[on ingresada";
                    resp.Contenido = false;
                    return Ok(resp);

                }
            }
        }
    }
}
