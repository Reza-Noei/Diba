using Diba.Core.AppService.Contract.Product.Model.InputModels;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.Product.Model.InputModels
{
    public class UpdateProductConstraintsViewModel
    {
        public int ProductId { get; set; }
        public IList<ProductStringConstraintsViewModel> StringConstraints { get; set; }
        public IList<ProductSelectiveConstraintsViewModel> SelectiveConstraints { get; set; }
    }
}