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
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<CreateProductViewModel, ProductViewModel>().ForMember(x => x.Id, opt => opt.Ignore()); ;
            CreateMap<CreateProductViewModel, Product>();
        }
    }
}