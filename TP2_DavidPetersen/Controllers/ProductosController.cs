using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP2_DavidPetersen.Dtos;
using TP2_DavidPetersen.Models;
using TP2_DavidPetersen.Repositorio.IRepositorio;

namespace TP2_DavidPetersen.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly IProductoRepositorio _repositorio;
    private readonly IMapper _mapper;

    public ProductosController(IProductoRepositorio repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductoDto>> GetProductos()
    {
        var productos = _repositorio.GetProductos();
        var productosDto = _mapper.Map<IEnumerable<ProductoDto>>(productos);
        return Ok(productosDto);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductoDto> GetProductoById(int id)
    {
        var producto = _repositorio.GetProductoById(id);
        if (producto == null)
        {
            return NotFound();
        }
        var productoDto = _mapper.Map<ProductoDto>(producto);
        return Ok(productoDto);
    }

    [HttpPost]
    public ActionResult<ProductoDto> CreateProducto(ProductoDto productoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var producto = _mapper.Map<Producto>(productoDto);
        var productoCreado = _repositorio.CreateProducto(producto);
        var productoCreadoDto = _mapper.Map<ProductoDto>(productoCreado);

        return CreatedAtAction(nameof(GetProductoById), new { id = productoCreadoDto.Id }, productoCreadoDto);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProducto(int id)
    {
        var producto = _repositorio.GetProductoById(id);
        if (producto == null)
        {
            return NotFound();
        }

        _repositorio.DeleteProducto(id);
        return NoContent();
    }
}
