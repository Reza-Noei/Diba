using Diba.Core.AppService.Contract.Product.Model.InputModels;

namespace Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel
{
    public class CreateProductStringConstraintsViewModel//: CreateProductViewModel
    {
        public string Title { get; set; }
        public int MaxLength { get; set; }
        public string Format { get; set; }
    }
}
