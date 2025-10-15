using TP2_ArticulosAPIv2.Models;

namespace TP2_ArticulosAPIv2.Repositorio.IRepositorio;

public interface IArticuloRepositorio
{
    IEnumerable<Articulo> GetArticulos();
    Articulo GetArticuloById(int id);
    Articulo CreateArticulo(Articulo articulo);
    void DeleteArticulo(int id);
}
