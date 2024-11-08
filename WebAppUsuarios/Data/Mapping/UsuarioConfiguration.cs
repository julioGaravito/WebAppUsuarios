using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppUsuarios.Models;

namespace WebAppUsuarios.Data.Mapping
{
    public class UsuarioConfiguration
    {
        public UsuarioConfiguration(EntityTypeBuilder<Usuarios> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.PrimerNombre).HasMaxLength(50);
            entityBuilder.Property(x => x.SegundoNombre).HasMaxLength(50).IsRequired(false);
            entityBuilder.Property(x => x.PrimerApellido).HasMaxLength(50);
            entityBuilder.Property(x => x.SegundoApellido).HasMaxLength(50).IsRequired(false);
            entityBuilder.Property(x => x.FechaNacimiento);
            entityBuilder.Property(x => x.Sueldo);
            entityBuilder.Property(x => x.FechaCreacion);
            entityBuilder.Property(x => x.FechaActualizacion);
        }
    }
}
