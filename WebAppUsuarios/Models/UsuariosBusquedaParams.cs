using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppUsuarios.Models
{
    public class UsuariosBusquedaParams
    {
        [DefaultValue("")]
        public string PrimerNombre { get; set; } = default!;

        [DefaultValue("")]
        public string PrimerApellido { get; set; } = default!;

        [Required(ErrorMessage = "El campo Page es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo Page debe ser mayor que 0.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Page debe ser un número entero.")]
        [DefaultValue(1)]
        public int Page { get; set; } = 1;

        [Required(ErrorMessage = "El campo Page es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo Page debe ser mayor que 0.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo PageSize debe ser un número entero.")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
