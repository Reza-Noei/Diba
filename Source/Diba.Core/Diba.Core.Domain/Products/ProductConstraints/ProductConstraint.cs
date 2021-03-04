namespace Diba.Core.Domain.Products.ProductConstraints
{
    // TODO: [RezaNoei] Product Constraint should be a value object member of the product in a 
    // way that value object no longer makes sense by it's own. and it's completly dependent to product.
    public abstract class ProductConstraint: BaseEntity<int>
    {
        public string Title { get; set; }

        public int ProductId { get; set; }

        public virtual ProductClass Product { get; set; }

        protected ProductConstraint()
        {

        }        
    }
}