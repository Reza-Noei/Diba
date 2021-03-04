using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.Domain.Products
{
    public abstract class ConstraintValue
    {
        public virtual ProductConstraint Constraint { get; set; }
    }

    public class StringConstraintValue: ConstraintValue
    {
        public string Value { get; set; }
    }
}