using AutoMapper;
using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.AppService.ProductConstraint
{
    public class ProductStringConstraintsConfig : Profile
    {
        public ProductStringConstraintsConfig()
        {
            CreateMap<StringConstraint, ProductStringConstraintViewModel>();

            CreateMap<ProductStringConstraintViewModel, StringConstraint>();

            CreateMap<CreateProductStringConstraintsViewModel, ProductStringConstraintsViewModel>();
            CreateMap<CreateProductStringConstraintsViewModel, StringConstraint>();
        }
    }
}