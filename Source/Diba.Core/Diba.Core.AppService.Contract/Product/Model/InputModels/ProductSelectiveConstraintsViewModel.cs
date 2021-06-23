using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.Product.Model.InputModels
{
    public class ProductSelectiveConstraintsViewModel
    {
        public string Title { get; set; }
        public IList<OptionViewModel> Options { get; set; }
    }
}