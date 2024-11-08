# WebAppUsuarios

Este proyecto es una API REST desarrollada en .NET 8 que implementa operaciones CRUD para la gestión de usuarios. Está estructurada siguiendo principios de arquitectura en capas, con separación de responsabilidades en modelos, controladores, servicios, repositorios y pruebas unitarias y base de datos SQL SERVER 2019.

## Estructura del Proyecto

El proyecto sigue la siguiente estructura de carpetas:


### 1. **Controllers**

La carpeta `Controllers` contiene el controlador principal `UsuariosController.cs`, que expone los endpoints de la API para gestionar usuarios. Implementa operaciones CRUD y permite búsquedas con paginación.

### 2. **Models**

La carpeta `Models` contiene las clases que representan las entidades y parámetros de búsqueda:

- `Usuarios.cs`: Define el modelo de datos para un usuario.
- `UsuariosBusquedaParams.cs`: Clase para los parámetros de búsqueda paginada.

### 3. **Data**

- `ApplicationDbContext.cs`: Clase que extiende `DbContext` de Entity Framework Core para interactuar con la base de datos.

### 4. **Repositories**

La carpeta `Repositories` contiene interfaces y clases concretas para el acceso a datos.

- `IUsuarioRepository.cs`: Define las operaciones de acceso a datos.
- `UsuarioRepository.cs`: Implementación concreta de `IUsuarioRepository`.

### 5. **Services**

Los servicios encapsulan la lógica de negocio.

- `IUsuarioService.cs`: Define las operaciones del servicio de usuarios.
- `UsuarioService.cs`: Implementación concreta del servicio, utiliza el repositorio.

### 6. **Tests**

La carpeta `Tests` incluye pruebas unitarias para asegurar la funcionalidad del controlador `UsuariosController`.

## Instalación y Configuración

1. **Clonar el repositorio:**

   ```bash   
   git clone https://github.com/julioGaravito/WebAppUsuarios.git
2. **appsettings.json**
   
   En la raiz de la solucion en el archivo de `appsettings.json` se debe cambiar el apuntamiento a la base de datos en este caso sql server.
   
   "ConnectionStrings": {"DefaultConnection": "Server=localhost;Database=database;User Id=user;Password=password;TrustServerCertificate=True;"}
3. **Ejecutar**
   
   Antes de ejecutar limpiar y compilar.
