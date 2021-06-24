using Diba.Core.AppService.Contract.Product.Model.InputModels;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.Product.Model.InputModels
{
    public class UpdateGenericProductViewModel
    {
        public int ProductId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public IList<ProductStringConstraintsViewModel> StringConstraints { get; set; }
        public IList<ProductSelectiveConstraintsViewModel> SelectiveConstraints { get; set; }
    }
}