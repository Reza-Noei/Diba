using AutoMapper;
using Diba.Core.AppService.Contract.Product.Model.InputModels;
using Diba.Core.AppService.Contract.Product.Model.ViewModels;
using Diba.Core.Domain.Products;

namespace Diba.Core.AppService.Products
{
    public class ProductMappingConfig : Profile
    {
        public ProductMappingConfig()
        {
            CreateMap<ProductClass, ProductViewModel>();
            CreateMap<ProductViewModel, ProductClass>();

            CreateMap<CreateProductViewModel, ProductViewModel>().ForMember(x => x.Id, opt => opt.Ignore()); ;
            CreateMap<CreateProductViewModel, ProductClass>();
        }
    }
}