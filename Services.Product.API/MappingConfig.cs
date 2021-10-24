using AutoMapper;
using Services.Product.API.Models;
using Services.Product.API.Models.Dto;

namespace Services.Product.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // So here we're using automapper to transform ProductDto into Products and vice versa 
                config.CreateMap<ProductDto, Products>();
                config.CreateMap<Products, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
