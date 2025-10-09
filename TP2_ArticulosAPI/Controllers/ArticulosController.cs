using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP2_ArticulosAPI.Models;
using TP2_ArticulosAPI.Repositorio.IRepositorio;
using TP2_ArticulosAPI.ViewModels;

namespace TP2_ArticulosAPI.Controllers;

public class ArticulosController : Controller
{
    private readonly IArticuloRepositorio _repositorio;
    private readonly IMapper _mapper;

    public ArticulosController(IArticuloRepositorio repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var articulos = _repositorio.GetArticulos();
        var articulosViewModel = _mapper.Map<List<ArticuloViewModel>>(articulos);
        return View(articulosViewModel);
    }

    public IActionResult Details(int id)
    {
        var articulo = _repositorio.GetArticuloById(id);
        if (articulo == null)
        {
            return NotFound();
        }
        var articuloViewModel = _mapper.Map<ArticuloViewModel>(articulo);
        return View(articuloViewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ArticuloViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var articulo = _mapper.Map<Articulo>(viewModel);
        _repositorio.CreateArticulo(articulo);
        return RedirectToAction("Index");
    }
}
