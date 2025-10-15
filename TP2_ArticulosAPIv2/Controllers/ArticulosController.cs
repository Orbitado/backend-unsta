using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP2_ArticulosAPIv2.Dtos;
using TP2_ArticulosAPIv2.Models;
using TP2_ArticulosAPIv2.Repositorio.IRepositorio;

namespace TP2_ArticulosAPIv2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticulosController : ControllerBase
{
    private readonly IArticuloRepositorio _repositorio;
    private readonly IMapper _mapper;

    public ArticulosController(IArticuloRepositorio repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ArticuloDto>> GetArticulos()
    {
        var articulos = _repositorio.GetArticulos();
        var articulosDto = _mapper.Map<IEnumerable<ArticuloDto>>(articulos);
        return Ok(articulosDto);
    }

    [HttpGet("{id}")]
    public ActionResult<ArticuloDto> GetArticuloById(int id)
    {
        var articulo = _repositorio.GetArticuloById(id);
        if (articulo == null)
        {
            return NotFound();
        }
        var articuloDto = _mapper.Map<ArticuloDto>(articulo);
        return Ok(articuloDto);
    }

    [HttpPost]
    public ActionResult<ArticuloDto> CreateArticulo(ArticuloDto articuloDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var articulo = _mapper.Map<Articulo>(articuloDto);
        var articuloCreado = _repositorio.CreateArticulo(articulo);
        var articuloCreadoDto = _mapper.Map<ArticuloDto>(articuloCreado);

        return CreatedAtAction(nameof(GetArticuloById), new { id = articuloCreadoDto.Id }, articuloCreadoDto);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteArticulo(int id)
    {
        var articulo = _repositorio.GetArticuloById(id);
        if (articulo == null)
        {
            return NotFound();
        }

        _repositorio.DeleteArticulo(id);
        return NoContent();
    }
}
