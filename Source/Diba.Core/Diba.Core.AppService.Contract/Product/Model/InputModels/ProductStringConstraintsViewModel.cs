namespace Diba.Core.AppService.Contract.Product.Model.InputModels
{
    public class ProductStringConstraintsViewModel
    {
        public string Title { get; set; }
        public int MaxLength { get; set; }
        public string Format { get; set; }
    }
}