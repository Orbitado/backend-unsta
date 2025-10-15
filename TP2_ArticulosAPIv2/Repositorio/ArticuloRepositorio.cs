using TP2_ArticulosAPIv2.Models;
using TP2_ArticulosAPIv2.Repositorio.IRepositorio;

namespace TP2_ArticulosAPIv2.Repositorio;

public class ArticuloRepositorio : IArticuloRepositorio
{
    private static List<Articulo> _articulos = new List<Articulo>
    {
        new Articulo { Id = 1, Nombre = "Laptop", Descripcion = "Laptop de alta gama para desarrollo" },
        new Articulo { Id = 2, Nombre = "Mouse", Descripcion = "Mouse inalámbrico ergonómico" },
        new Articulo { Id = 3, Nombre = "Teclado", Descripcion = "Teclado mecánico RGB" }
    };

    private static int _nextId = 4;

    public IEnumerable<Articulo> GetArticulos()
    {
        return _articulos;
    }

    public Articulo GetArticuloById(int id)
    {
        return _articulos.FirstOrDefault(a => a.Id == id);
    }

    public Articulo CreateArticulo(Articulo articulo)
    {
        articulo.Id = _nextId++;
        _articulos.Add(articulo);
        return articulo;
    }

    public void DeleteArticulo(int id)
    {
        var articulo = _articulos.FirstOrDefault(a => a.Id == id);
        if (articulo != null)
        {
            _articulos.Remove(articulo);
        }
    }
}
