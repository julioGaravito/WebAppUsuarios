using Microsoft.EntityFrameworkCore;
using WebAppUsuarios.Data;
using WebAppUsuarios.Models;

namespace WebAppUsuarios.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuariosDbContext _context;

        public UsuarioRepository(UsuariosDbContext context)
        {
            _context = context;
        }

        public async Task<Usuarios> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<List<Usuarios>> GetByNameOrLastNameAsync(string firstName, string lastName, int page, int pageSize)
        {
            var query = _context.Usuarios.AsQueryable();

            if (!string.IsNullOrWhiteSpace(firstName))
                query = query.Where(u => u.PrimerNombre.Contains(firstName));

            if (!string.IsNullOrWhiteSpace(lastName))
                query = query.Where(u => u.PrimerApellido.Contains(lastName));

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(Usuarios usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Usuarios usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
