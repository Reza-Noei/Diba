namespace Diba.Core.Domain.Products.ProductConstraints
{
    public abstract class ProductConstraint
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Title { get; set; }

        protected ProductConstraint()
        {

        }
    }
}