using Microsoft.EntityFrameworkCore;
using ReservaVuelos.Models;

namespace ReservaVuelos.Servicios.Contrato
{
    //Se obtiene el correo y contrasena del usuario
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);

    }
}