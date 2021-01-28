using Diba.Core.AppService.Contract.Product.Model.InputModels;

namespace Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel
{
    public class UpdateProductStringConstraintsViewModel//: UpdateProductViewModel
    {
        public string Title { get; set; }
        public int MaxLength { get; set; }
        public string Format { get; set; }
    }
}