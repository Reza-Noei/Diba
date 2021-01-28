using AutoMapper;
using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.AppService.ProductConstraint
{
    public class ProductSelectiveConstraintsConfig : Profile
    {
        public ProductSelectiveConstraintsConfig()
        {
            CreateMap<SelectiveConstraint, ProductSelectiveConstraintViewModel>();
            CreateMap<ProductSelectiveConstraintViewModel, SelectiveConstraint>();

            CreateMap<CreateProductSelectiveConstraintsViewModel, ProductSelectiveConstraintsViewModel>();
            CreateMap<CreateProductSelectiveConstraintsViewModel, SelectiveConstraint>();

            CreateMap<OptionViewModel, Option>();

            CreateMap<Option, OptionViewModel>();

        }
    }
}
