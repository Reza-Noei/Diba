namespace Diba.Core.Domain.Products.ProductConstraints
{
    public abstract class ProductConstraint: BaseEntity<int>
    {
        public string Title { get; private set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        protected ProductConstraint()
        {

        }        
    }
}