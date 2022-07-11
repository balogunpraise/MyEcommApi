using AutoMapper;
using DotnetEcommerce.Api.DTOs;
using DotnetEcommerce.Core.Entities;

namespace DotnetEcommerce.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(m => m.ProductType, o => o.MapFrom(p => p.ProductType.Name))
                .ForMember(m => m.ProductBrand, o => o.MapFrom(p => p.ProductBrand.Name))
                .ForMember(m => m.PictureUrl, o=> o.MapFrom<ProductUrlResolver>());
        }
    }
}
