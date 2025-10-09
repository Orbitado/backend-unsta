using TP2_ArticulosAPI.Models;

namespace TP2_ArticulosAPI.Repositorio.IRepositorio;

public interface IArticuloRepositorio
{
    IEnumerable<Articulo> GetArticulos();
    Articulo GetArticuloById(int id);
    Articulo CreateArticulo(Articulo articulo);
    void DeleteArticulo(int id);
}
