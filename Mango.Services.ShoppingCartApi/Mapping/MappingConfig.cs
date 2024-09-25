using AutoMapper;
using Mango.Services.ShoppingCartApi.Dtos.Cart;
using Mango.Services.ShoppingCartApi.Models;

namespace Mango.Services.ShoppingCartApi.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
