using System.Threading.Tasks;
using WebAppUsuarios.Models;

namespace WebAppUsuarios.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuarios> GetByIdAsync(int id);
        Task<List<Usuarios>> GetByNameOrLastNameAsync(string firstName, string lastName, int page, int pageSize);
        Task AddAsync(Usuarios usuario);
        Task UpdateAsync(Usuarios usuario);
        Task DeleteAsync(Usuarios usuario);
    }
}
