using Microsoft.EntityFrameworkCore;
using WebAppUsuarios.Data.Mapping;
using WebAppUsuarios.Models;

namespace WebAppUsuarios.Data
{
    public class UsuariosDbContext(DbContextOptions<UsuariosDbContext> options) : DbContext(options)
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UsuarioConfiguration(modelBuilder.Entity<Usuarios>());
        }
    }
}
