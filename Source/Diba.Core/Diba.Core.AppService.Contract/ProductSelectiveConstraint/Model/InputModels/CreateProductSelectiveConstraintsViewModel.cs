using Diba.Core.AppService.Contract.Product.Model.InputModels;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel
{
    public class CreateProductSelectiveConstraintsViewModel
    {
        public string Title { get; set; }
        public IList<OptionViewModel> Options { get; set; }
    }

    public class OptionViewModel
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}