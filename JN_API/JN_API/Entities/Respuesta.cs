using System.Reflection.Metadata.Ecma335;

namespace JN_API.Entities
{
    public class Respuesta
    {
        public int Codigo { get; set; } = 0;
        public string? Mensaje { get; set; } = "OK";
        public object? Contenido { get; set; }
    }
}
