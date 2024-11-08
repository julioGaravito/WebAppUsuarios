using Microsoft.AspNetCore.Mvc;
using WebAppUsuarios.Models;
using WebAppUsuarios.Services;

namespace WebAppUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuarios usuario)
        {
            var createdUser = await _usuarioService.CrearUsuarioAsync(usuario);
            return CreatedAtAction(nameof(ObtenerUsuarioId), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] Usuarios usuario)
        {
            var updatedUser = await _usuarioService.ActualizarUsuarioAsync(id, usuario);
            if (updatedUser == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var success = await _usuarioService.EliminarUsuarioAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> ObtenerUsuarioId(int id)
        {
            var user = await _usuarioService.ObtenerUsuarioIdAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost("buscar")]
        public async Task<IActionResult> GetByNameOrLastName([FromBody] UsuariosBusquedaParams requestUsuariosBusquedaParams)
        {
            var users = await _usuarioService.GetUsuariosByCriteriaAsync(
                requestUsuariosBusquedaParams.PrimerNombre,
                requestUsuariosBusquedaParams.PrimerApellido,
                requestUsuariosBusquedaParams.Page,
                requestUsuariosBusquedaParams.PageSize
            );
            return Ok(users);
        }
    }
}
