using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel
{

    public class ProductStringConstraintsViewModel
    {
        public IList<ProductStringConstraintViewModel> Constraints { get; set; }
    }

    public class ProductStringConstraintViewModel//: ProductViewModel
    {

        //public int ProductId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int MaxLength { get; set; }
        public string Format { get; set; }
    }
}