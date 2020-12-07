namespace Diba.Core.Domain.Products.ProductConstraints
{
    public abstract class ProductConstraint
    {
        public int Id { get; set; }
        public long ConstraintId { get; set; }


        protected ProductConstraint()
        {

        }
    }
}