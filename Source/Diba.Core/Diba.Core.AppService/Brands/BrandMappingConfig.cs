using AutoMapper;
using Diba.Core.AppService.Contract.Brands;
using Diba.Core.Domain;

namespace Diba.Core.AppService.Brands
{
    public class BrandMappingConfig : Profile
    {
        public BrandMappingConfig()
        {
            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandViewModel, Brand>();

            CreateMap<CreateBrandInputModel, Brand>();
            CreateMap<Brand, CreateBrandInputModel>();
        }
    }
}