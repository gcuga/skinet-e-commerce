using AutoMapper;

using Skinet.Core;
using Skinet.WebApi.Dtos;

namespace Skinet.WebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<ProductType, ProductTypeToReturnDto>();
            CreateMap<ProductBrand, ProductBrandToReturnDto>();
        }
    }
}
