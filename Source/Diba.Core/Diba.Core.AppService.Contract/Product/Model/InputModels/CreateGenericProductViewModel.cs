using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.Product.Model.InputModels
{
    public class CreateGenericProductViewModel
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public IList<ProductStringConstraintsViewModel> StringConstraints { get; set; }
        public IList<ProductSelectiveConstraintsViewModel> SelectiveConstraints { get; set; }
    }
}