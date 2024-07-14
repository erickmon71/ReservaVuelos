using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReservaVuelos.Models;
using ReservaVuelos.Servicios.Contrato;

namespace ReservaVuelos.Servicios.Implementacion
{
    //se anade herencia del contrato service y se verifica con el context 
    public class UsuarioService : IUsuarioService
    {
        private readonly TravelBookingDbContext _dbContext;
        public UsuarioService(TravelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave)
                 .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}