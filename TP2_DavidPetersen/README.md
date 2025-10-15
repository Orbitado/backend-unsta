# TP2 - API de Productos (David Petersen)

Este es un proyecto de API REST desarrollado en .NET 9.0 que implementa operaciones CRUD para productos electrónicos.

## Características

- **Framework**: .NET 9.0
- **Patrón de Diseño**: Repository Pattern
- **Mapeo de Objetos**: AutoMapper
- **Arquitectura**: API RESTful
- **Almacenamiento**: In-Memory (Lista estática)

## Estructura del Proyecto

```
TP2_DavidPetersen/
├── Controllers/
│   └── ProductosController.cs     # Controlador con endpoints CRUD
├── Models/
│   └── Producto.cs                # Modelo de dominio
├── Dtos/
│   └── ProductoDto.cs             # Data Transfer Object
├── Repositorio/
│   ├── IRepositorio/
│   │   └── IProductoRepositorio.cs  # Interfaz del repositorio
│   └── ProductoRepositorio.cs       # Implementación del repositorio
├── MappingConfiguration.cs        # Configuración de AutoMapper
└── Program.cs                     # Punto de entrada y configuración
```

## Modelo de Datos

El modelo `Producto` incluye los siguientes campos:

- **Id** (int): Identificador único
- **Nombre** (string): Nombre del producto
- **Descripcion** (string): Descripción detallada
- **Precio** (decimal): Precio del producto
- **Stock** (int): Cantidad en inventario

## Endpoints Disponibles

### GET /api/Productos
Obtiene todos los productos

### GET /api/Productos/{id}
Obtiene un producto específico por ID

### POST /api/Productos
Crea un nuevo producto

**Body ejemplo:**
```json
{
  "nombre": "iPad Pro",
  "descripcion": "Tablet profesional de Apple",
  "precio": 799.99,
  "stock": 20
}
```

### DELETE /api/Productos/{id}
Elimina un producto por ID

## Datos de Ejemplo

El repositorio incluye 4 productos precargados:
1. iPhone 15 Pro - $1299.99
2. Samsung Galaxy S24 - $999.99
3. MacBook Air M3 - $1499.99
4. AirPods Pro - $249.99

## Cómo Ejecutar

1. Asegúrate de tener .NET 9.0 SDK instalado
2. Navega a la carpeta del proyecto
3. Restaura las dependencias:
   ```bash
   dotnet restore
   ```
4. Compila el proyecto:
   ```bash
   dotnet build
   ```
5. Ejecuta la aplicación:
   ```bash
   dotnet run
   ```
6. Accede a la API en: `https://localhost:5001` o `http://localhost:5000`
7. Explora la documentación OpenAPI en: `https://localhost:5001/openapi`

## Dependencias

- AutoMapper (v12.0.1)
- AutoMapper.Extensions.Microsoft.DependencyInjection (v12.0.1)
- Microsoft.AspNetCore.OpenApi (v9.0.10)
- Microsoft.EntityFrameworkCore.SqlServer (v9.0.10)

## Autor

David Petersen
