namespace Diba.Core.Domain.Products.ProductConstraints
{
    public abstract class ProductConstraint
    {
        public long ConstraintId { get; set; }
        protected ProductConstraint(long constraintId)
        {
            ConstraintId = constraintId;
        }
    }
}