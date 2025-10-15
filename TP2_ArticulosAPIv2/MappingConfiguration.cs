using AutoMapper;
using TP2_ArticulosAPIv2.Dtos;
using TP2_ArticulosAPIv2.Models;

namespace TP2_ArticulosAPIv2;

public class MappingConfiguration
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ArticuloDto, Articulo>();
            config.CreateMap<Articulo, ArticuloDto>();
        });
        return mappingConfig;
    }
}
