using Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel
{
    public class ProductSelectiveConstraintViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<OptionViewModel> Options { get; set; }
    }
    public class ProductSelectiveConstraintsViewModel
    {
        public IList<ProductSelectiveConstraintViewModel> Constraints { get; set; }
    }
}