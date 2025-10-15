using AutoMapper;
using TP2_DavidPetersen.Dtos;
using TP2_DavidPetersen.Models;

namespace TP2_DavidPetersen;

public class MappingConfiguration
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductoDto, Producto>();
            config.CreateMap<Producto, ProductoDto>();
        });
        return mappingConfig;
    }
}
