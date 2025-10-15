using AutoMapper;
using TP2_DavidPetersen;
using TP2_DavidPetersen.Repositorio;
using TP2_DavidPetersen.Repositorio.IRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configure AutoMapper
IMapper mapper = MappingConfiguration.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register Repository
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();

// Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
