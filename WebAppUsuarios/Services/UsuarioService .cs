using WebAppUsuarios.Models;
using WebAppUsuarios.Repositories;

namespace WebAppUsuarios.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuarios> CrearUsuarioAsync(Usuarios usuario)
        {
            usuario.FechaCreacion = DateTime.UtcNow;
            usuario.FechaActualizacion = DateTime.UtcNow;
            await _usuarioRepository.AddAsync(usuario);
            return usuario;
        }

        public async Task<Usuarios> ActualizarUsuarioAsync(int id, Usuarios usuario)
        {
            var existingUser = await _usuarioRepository.GetByIdAsync(id);
            if (existingUser == null) return null;

            existingUser.PrimerNombre = usuario.PrimerNombre;
            existingUser.SegundoNombre = usuario.SegundoNombre;
            existingUser.PrimerApellido = usuario.PrimerApellido;
            existingUser.SegundoApellido = usuario.SegundoApellido;
            existingUser.FechaNacimiento = usuario.FechaNacimiento;
            existingUser.Sueldo = usuario.Sueldo;
            existingUser.FechaActualizacion = DateTime.UtcNow;

            await _usuarioRepository.UpdateAsync(existingUser);
            return existingUser;
        }

        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            var user = await _usuarioRepository.GetByIdAsync(id);
            if (user == null) return false;

            await _usuarioRepository.DeleteAsync(user);
            return true;
        }

        public async Task<Usuarios> ObtenerUsuarioIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<List<Usuarios>> GetUsuariosByCriteriaAsync(string firstName, string lastName, int page, int pageSize)
        {
            return await _usuarioRepository.GetByNameOrLastNameAsync(firstName, lastName, page, pageSize);
        }
    }
}
