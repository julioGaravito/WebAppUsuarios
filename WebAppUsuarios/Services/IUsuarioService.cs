using WebAppUsuarios.Models;

namespace WebAppUsuarios.Services
{
    public interface IUsuarioService
    {
        Task<Usuarios> CrearUsuarioAsync(Usuarios usuario);
        Task<Usuarios> ActualizarUsuarioAsync(int id, Usuarios usuario);
        Task<bool> EliminarUsuarioAsync(int id);
        Task<Usuarios> ObtenerUsuarioIdAsync(int id);
        Task<List<Usuarios>> GetUsuariosByCriteriaAsync(string firstName, string lastName, int page, int pageSize);
    }
}
