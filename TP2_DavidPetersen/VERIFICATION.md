# Verificación de Instrucciones del TP2

Este documento verifica que el proyecto **TP2_DavidPetersen** cumple con todas las instrucciones del TP.

## ✅ Instrucción 1: Crear carpeta y clase Dto

**Estado**: ✅ CUMPLIDO

- **Carpeta creada**: `Dtos/`
- **Archivo**: [Dtos/ProductoDto.cs](Dtos/ProductoDto.cs)
- **Contenido**:
  ```csharp
  namespace TP2_DavidPetersen.Dtos;

  public class ProductoDto
  {
      public int Id { get; set; }
      public string Nombre { get; set; } = string.Empty;
      public string Descripcion { get; set; } = string.Empty;
      public decimal Precio { get; set; }
      public int Stock { get; set; }
  }
  ```

---

## ✅ Instrucción 2: Crear carpeta e interfaz para repositorio

**Estado**: ✅ CUMPLIDO

- **Carpetas creadas**: `Repositorio/IRepositorio/`
- **Archivo**: [Repositorio/IRepositorio/IProductoRepositorio.cs](Repositorio/IRepositorio/IProductoRepositorio.cs)
- **Contenido**:
  ```csharp
  using TP2_DavidPetersen.Models;

  namespace TP2_DavidPetersen.Repositorio.IRepositorio;

  public interface IProductoRepositorio
  {
      IEnumerable<Producto> GetProductos();
      Producto? GetProductoById(int id);
      Producto CreateProducto(Producto producto);
      void DeleteProducto(int id);
  }
  ```

---

## ✅ Instrucción 3: Instalar AutoMapper

**Estado**: ✅ CUMPLIDO

- **Archivo**: [TP2_DavidPetersen.csproj](TP2_DavidPetersen.csproj)
- **Paquetes instalados**:
  ```xml
  <PackageReference Include="AutoMapper" Version="12.0.1" />
  <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
  ```

---

## ✅ Instrucción 4: Crear MappingConfiguration en la raíz

**Estado**: ✅ CUMPLIDO

- **Ubicación**: Raíz del proyecto
- **Archivo**: [MappingConfiguration.cs](MappingConfiguration.cs)
- **Contenido**:
  ```csharp
  using AutoMapper;
  using TP2_DavidPetersen.Dtos;
  using TP2_DavidPetersen.Models;

  namespace TP2_DavidPetersen;

  public class MappingConfiguration
  {
      public static MapperConfiguration RegisterMaps()
      {
          var mappingConfig = new MapperConfiguration(config =>
          {
              config.CreateMap<ProductoDto, Producto>();
              config.CreateMap<Producto, ProductoDto>();
          });
          return mappingConfig;
      }
  }
  ```

**Nota**: La estructura es idéntica a la solicitada, solo cambia el nombre de las clases (`Producto` en lugar de `Articulo`).

---

## ✅ Instrucción 5: Agregar configuración en Program.cs

**Estado**: ✅ CUMPLIDO

- **Archivo**: [Program.cs](Program.cs:13-15)
- **Líneas 13-15**:
  ```csharp
  // Configure AutoMapper
  IMapper mapper = MappingConfiguration.RegisterMaps().CreateMapper();
  builder.Services.AddSingleton(mapper);
  builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
  ```

**Verificación**: Las tres líneas requeridas están presentes y en el orden correcto.

---

## ✅ Instrucción 6: Agregar clase repositorio e implementar interfaz

**Estado**: ✅ CUMPLIDO

- **Archivo**: [Repositorio/ProductoRepositorio.cs](Repositorio/ProductoRepositorio.cs)
- **Implementación**:
  ```csharp
  public class ProductoRepositorio : IProductoRepositorio
  {
      private static List<Producto> _productos = new List<Producto> { ... };
      private static int _nextId = 5;

      public IEnumerable<Producto> GetProductos() { ... }
      public Producto? GetProductoById(int id) { ... }
      public Producto CreateProducto(Producto producto) { ... }
      public void DeleteProducto(int id) { ... }
  }
  ```

**Verificación**: La clase implementa todos los métodos definidos en la interfaz `IProductoRepositorio`.

---

## ✅ Instrucción 7: Agregar servicio repositorio en Program

**Estado**: ✅ CUMPLIDO

- **Archivo**: [Program.cs](Program.cs:18)
- **Línea 18**:
  ```csharp
  // Register Repository
  builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
  ```

**Verificación**: El servicio está registrado con el ciclo de vida `Scoped` como se requiere.

---

## ✅ Instrucción 8: Actualizar controlador para usar Repositorio

**Estado**: ✅ CUMPLIDO

- **Archivo**: [Controllers/ProductosController.cs](Controllers/ProductosController.cs)
- **Inyección de dependencias (líneas 13-19)**:
  ```csharp
  private readonly IProductoRepositorio _repositorio;
  private readonly IMapper _mapper;

  public ProductosController(IProductoRepositorio repositorio, IMapper mapper)
  {
      _repositorio = repositorio;
      _mapper = mapper;
  }
  ```

- **Uso del repositorio en los métodos**:
  - **GetProductos()**: Usa `_repositorio.GetProductos()` (línea 25)
  - **GetProductoById()**: Usa `_repositorio.GetProductoById(id)` (línea 33)
  - **CreateProducto()**: Usa `_repositorio.CreateProducto(producto)` (línea 51)
  - **DeleteProducto()**: Usa `_repositorio.DeleteProducto(id)` (línea 66)

---

## 🎯 Resumen Final

| Instrucción | Estado | Ubicación |
|-------------|--------|-----------|
| 1. Dto folder y clase | ✅ CUMPLIDO | `Dtos/ProductoDto.cs` |
| 2. Repositorio folder e interfaz | ✅ CUMPLIDO | `Repositorio/IRepositorio/IProductoRepositorio.cs` |
| 3. Instalar AutoMapper | ✅ CUMPLIDO | `TP2_DavidPetersen.csproj` |
| 4. MappingConfiguration | ✅ CUMPLIDO | `MappingConfiguration.cs` |
| 5. Configurar en Program | ✅ CUMPLIDO | `Program.cs` líneas 13-15 |
| 6. Implementar repositorio | ✅ CUMPLIDO | `Repositorio/ProductoRepositorio.cs` |
| 7. Registrar servicio | ✅ CUMPLIDO | `Program.cs` línea 18 |
| 8. Actualizar controlador | ✅ CUMPLIDO | `Controllers/ProductosController.cs` |

---

## ✨ Extras Implementados

Además de cumplir con todas las instrucciones, el proyecto incluye:

1. **Nullable reference types**: Se corrigió el warning usando `Producto?` en el método `GetProductoById`
2. **Modelo extendido**: Se agregaron propiedades `Precio` y `Stock` al modelo
3. **Datos de ejemplo realistas**: Productos electrónicos con precios y stock
4. **Documentación completa**: README.md con instrucciones de uso
5. **Compilación exitosa**: El proyecto compila sin warnings ni errores
6. **Pruebas funcionales**: Los endpoints fueron probados y funcionan correctamente

---

## 🚀 Resultado

**El proyecto TP2_DavidPetersen cumple al 100% con todas las instrucciones del TP.**

El proyecto está listo para ser usado por David Petersen como material de estudio y práctica.
