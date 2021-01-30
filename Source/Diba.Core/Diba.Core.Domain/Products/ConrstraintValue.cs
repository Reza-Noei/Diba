using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.Domain.Products
{
    public abstract class ConrstraintValue
    {
        public virtual ProductClassConstraint Constraint { get; set; }
    }

    public class StringConstraintValue: ConrstraintValue
    {
        public string Value { get; set; }
    }
}