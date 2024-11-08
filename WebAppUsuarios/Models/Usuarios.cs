using System.ComponentModel.DataAnnotations;

namespace WebAppUsuarios.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
    
        [Required(ErrorMessage = "El campo PrimerNombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo PrimerNombre no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo PrimerNombre solo puede contener letras.")]
        public string PrimerNombre { get; set; } = default!;

        [MaxLength(50, ErrorMessage = "El campo SegundoNombre no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo SegundoNombre solo puede contener letras.")]
        public string SegundoNombre { get; set; } = default!;

        [Required(ErrorMessage = "El campo PrimerApellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo PrimerApellido no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo PrimerApellido solo puede contener letras.")]
        public string PrimerApellido { get; set; } = default!;

        [MaxLength(50, ErrorMessage = "El campo SegundoApellido no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo SegundoApellido solo puede contener letras.")]
        public string SegundoApellido { get; set; } = default!;
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Sueldo es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a cero.")]
        public decimal Sueldo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}