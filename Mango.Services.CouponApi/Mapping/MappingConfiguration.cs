using AutoMapper;
using Mango.Services.CouponApi.DTOS;
using Mango.Services.CouponApi.Models;
using Mapster;

namespace Mango.Services.CouponApi.Mapping
{
    public class MappingConfiguration 
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Coupon, CouponDto>
                .NewConfig();
            TypeAdapterConfig<CouponDto, Coupon>
                .NewConfig();
        }
    }
}
