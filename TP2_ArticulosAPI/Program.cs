using AutoMapper;
using TP2_ArticulosAPI.Models;
using TP2_ArticulosAPI.Repositorio;
using TP2_ArticulosAPI.Repositorio.IRepositorio;
using TP2_ArticulosAPI.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register Repository
builder.Services.AddSingleton<IArticuloRepositorio, ArticuloRepositorio>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Configure AutoMapper
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Articulo, ArticuloViewModel>().ReverseMap();
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
