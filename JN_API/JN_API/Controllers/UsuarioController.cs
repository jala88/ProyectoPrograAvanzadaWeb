using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JN_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult ConsultarUsuarios() 
        {
            var resultado = 750000;
            return Ok(resultado);
        }
    }
}
