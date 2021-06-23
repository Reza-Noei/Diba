using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Diba.Core.AppService.Contract.Product.Model.InputModels;
using Diba.Core.AppService.Contract.Product.Model.ViewModels;
using Diba.Core.Domain.Products;
using Diba.Core.Domain.Products.ProductConstraints;

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

            CreateMap<SelectiveConstraint, ProductSelectiveConstraintsViewModel>();
            CreateMap<ProductSelectiveConstraintsViewModel, SelectiveConstraint>();

            CreateMap<OptionViewModel, Option>();
            CreateMap<Option, OptionViewModel>();

            CreateMap<StringConstraint, ProductStringConstraintsViewModel>();
            CreateMap<ProductStringConstraintsViewModel, StringConstraint>();

        }
    }

    public static class SelectiveConstraintMappers
    {
        public static List<SelectiveConstraint> Map(IEnumerable<ProductSelectiveConstraintsViewModel> ranges)
        {
            return ranges.Select(Map).ToList();
        }

        public static SelectiveConstraint Map(ProductSelectiveConstraintsViewModel model)
        {
            if (model == null) return null;
            var options = OptionMappers.Map(model.Options); 
            return new SelectiveConstraint(options);
        }
    }

    public static class OptionMappers
    {
        public static List<Option> Map(IEnumerable<OptionViewModel> ranges)
        {
            return ranges.Select(Map).ToList();
        }

        public static Option Map(OptionViewModel model)
        {
            if (model == null) return null;
            return new Option(model.Value, model.Key);
        }
    }
}