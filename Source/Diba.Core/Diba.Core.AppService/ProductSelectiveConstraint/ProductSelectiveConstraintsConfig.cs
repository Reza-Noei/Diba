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
            CreateMap<SelectiveConstraint, ProductSelectiveConstraintsViewModel>();
            CreateMap<ProductSelectiveConstraintsViewModel, SelectiveConstraint>();

            CreateMap<CreateProductSelectiveConstraintsViewModel, ProductSelectiveConstraintsViewModel>().ForMember(x => x.Id, opt => opt.Ignore()); ;
            CreateMap<CreateProductSelectiveConstraintsViewModel, SelectiveConstraint>();

            CreateMap<OptionViewModel, Option>();


        }
    }
}
