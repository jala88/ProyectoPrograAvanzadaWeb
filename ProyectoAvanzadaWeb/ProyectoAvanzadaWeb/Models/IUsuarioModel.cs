namespace ProyectoAvanzadaWeb.Models
{
    public interface IUsuarioModel
    {
        public void RegistrarUsuario(UsuarioModel ent);
        public void IniciarSesion(UsuarioModel ent);
    }
}
