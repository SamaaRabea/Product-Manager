using AutoMapper;
using Shop.DAL;
using Shope.BL.Dto;

namespace Shope.BL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product_VersionDto, Product_Version>();
            CreateMap<Product_Version, Product_VersionDto>();
            CreateMap<Product, ProductDto>();

        }
    }
}
