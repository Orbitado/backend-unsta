# Diferencias entre TP2_ArticulosAPIv2 y TP2_DavidPetersen

Este documento muestra las principales diferencias entre ambos proyectos.

## Cambios Principales

### 1. Nombre del Proyecto
- **Original**: TP2_ArticulosAPIv2
- **Nueva**: TP2_DavidPetersen

### 2. Dominio de Negocio
- **Original**: Artículos (genérico)
- **Nueva**: Productos electrónicos (específico)

### 3. Modelo de Datos

#### Original (Articulo)
```csharp
public class Articulo
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
}
```

#### Nuevo (Producto)
```csharp
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }      // ✨ NUEVO
    public int Stock { get; set; }           // ✨ NUEVO
}
```

### 4. Datos de Ejemplo

#### Original
- Laptop - Laptop de alta gama para desarrollo
- Mouse - Mouse inalámbrico ergonómico
- Teclado - Teclado mecánico RGB

#### Nuevo
- iPhone 15 Pro - Smartphone Apple de última generación ($1299.99, Stock: 25)
- Samsung Galaxy S24 - Smartphone Samsung con tecnología AI ($999.99, Stock: 30)
- MacBook Air M3 - Laptop ultraligera con chip M3 ($1499.99, Stock: 15)
- AirPods Pro - Auriculares inalámbricos con cancelación de ruido ($249.99, Stock: 50)

### 5. Namespaces

Todos los namespaces fueron actualizados:
- `TP2_ArticulosAPIv2.*` → `TP2_DavidPetersen.*`

### 6. Nombres de Clases y Archivos

| Original | Nuevo |
|----------|-------|
| `Articulo.cs` | `Producto.cs` |
| `ArticuloDto.cs` | `ProductoDto.cs` |
| `IArticuloRepositorio.cs` | `IProductoRepositorio.cs` |
| `ArticuloRepositorio.cs` | `ProductoRepositorio.cs` |
| `ArticulosController.cs` | `ProductosController.cs` |

### 7. Endpoints

- **Original**: `/api/Articulos`
- **Nuevo**: `/api/Productos`

### 8. Mejoras de Código

- Se corrigió el warning de nullable reference en el método `GetProductoById`
- Se agregó el tipo de retorno nullable `Producto?` para manejar correctamente casos donde no se encuentra un producto

## Similitudes

Ambos proyectos mantienen:
- ✅ La misma arquitectura (Repository Pattern)
- ✅ Las mismas dependencias NuGet
- ✅ La misma versión de .NET (9.0)
- ✅ La misma configuración de AutoMapper
- ✅ Los mismos endpoints CRUD
- ✅ La misma configuración de launchSettings

## Uso Educativo

Este proyecto es perfecto para que David Petersen:
1. Aprenda la estructura de una API REST en .NET
2. Entienda el patrón Repository
3. Practique con AutoMapper
4. Experimente con diferentes dominios de negocio
5. Pueda modificar y extender sin conflictos con tu proyecto original
