using TP2_DavidPetersen.Models;

namespace TP2_DavidPetersen.Repositorio.IRepositorio;

public interface IProductoRepositorio
{
    IEnumerable<Producto> GetProductos();
    Producto? GetProductoById(int id);
    Producto CreateProducto(Producto producto);
    void DeleteProducto(int id);
}
