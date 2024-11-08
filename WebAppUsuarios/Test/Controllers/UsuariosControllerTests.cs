using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAppUsuarios.Controllers;
using WebAppUsuarios.Models;
using WebAppUsuarios.Services;
using Xunit;

namespace WebAppUsuarios.Test.Controllers
{
    public class UsuariosControllerTests
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService;
        private readonly UsuariosController _controller;

        public UsuariosControllerTests()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _controller = new UsuariosController(_mockUsuarioService.Object);
        }

        [Fact]
        public async Task CrearUsuario_ReturnsCreatedAtActionResult()
        {
            var nuevoUsuario = new Usuarios
            {
                PrimerNombre = "Carlos",
                PrimerApellido = "Lopez",
                FechaNacimiento = new DateTime(1985, 7, 15),
                Sueldo = 3000000
            };

            _mockUsuarioService.Setup(service => service.CrearUsuarioAsync(It.IsAny<Usuarios>()))
                .ReturnsAsync(nuevoUsuario);

            var result = await _controller.CrearUsuario(nuevoUsuario);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            var usuarioCreado = Assert.IsType<Usuarios>(actionResult.Value);
            Assert.Equal("Carlos", usuarioCreado.PrimerNombre);
            Assert.Equal("Lopez", usuarioCreado.PrimerApellido);
        }

        [Fact]
        public async Task ActualizarUsuario_ReturnsNoContent()
        {
            var usuarioExistente = new Usuarios { Id = 1, PrimerNombre = "Carlos", PrimerApellido = "Lopez"};

            _mockUsuarioService.Setup(service => service.ActualizarUsuarioAsync(It.IsAny<int>(), It.IsAny<Usuarios>()))
                .ReturnsAsync(usuarioExistente);

            var result = await _controller.ActualizarUsuario(1, usuarioExistente);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task EliminarUsuario_ReturnsNoContent()
        {
            var usuarioExistente = new Usuarios { Id = 1, PrimerNombre = "Carlos", PrimerApellido = "Lopez" };

            _mockUsuarioService.Setup(service => service.EliminarUsuarioAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            var result = await _controller.EliminarUsuario(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task ObtenerUsuarioId_ReturnsOkObjectResult()
        {
            var usuarioExistente = new Usuarios { Id = 1, PrimerNombre = "Carlos", PrimerApellido = "Lopez", FechaNacimiento = new DateTime(1990, 5, 8), Sueldo = 7000000 };
        
            _mockUsuarioService.Setup(service => service.ObtenerUsuarioIdAsync(It.IsAny<int>()))
                .ReturnsAsync(usuarioExistente);
        
            var result = await _controller.ObtenerUsuarioId(1);
        
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var usuario = Assert.IsType<Usuarios>(actionResult.Value);
            Assert.Equal("Carlos", usuario.PrimerNombre);
            Assert.Equal("Lopez", usuario.PrimerApellido);
        }
    }
}
