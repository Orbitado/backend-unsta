using TP2_DavidPetersen.Models;
using TP2_DavidPetersen.Repositorio.IRepositorio;

namespace TP2_DavidPetersen.Repositorio;

public class ProductoRepositorio : IProductoRepositorio
{
    private static List<Producto> _productos = new List<Producto>
    {
        new Producto { Id = 1, Nombre = "iPhone 15 Pro", Descripcion = "Smartphone Apple de última generación", Precio = 1299.99m, Stock = 25 },
        new Producto { Id = 2, Nombre = "Samsung Galaxy S24", Descripcion = "Smartphone Samsung con tecnología AI", Precio = 999.99m, Stock = 30 },
        new Producto { Id = 3, Nombre = "MacBook Air M3", Descripcion = "Laptop ultraligera con chip M3", Precio = 1499.99m, Stock = 15 },
        new Producto { Id = 4, Nombre = "AirPods Pro", Descripcion = "Auriculares inalámbricos con cancelación de ruido", Precio = 249.99m, Stock = 50 }
    };

    private static int _nextId = 5;

    public IEnumerable<Producto> GetProductos()
    {
        return _productos;
    }

    public Producto? GetProductoById(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public Producto CreateProducto(Producto producto)
    {
        producto.Id = _nextId++;
        _productos.Add(producto);
        return producto;
    }

    public void DeleteProducto(int id)
    {
        var producto = _productos.FirstOrDefault(p => p.Id == id);
        if (producto != null)
        {
            _productos.Remove(producto);
        }
    }
}
