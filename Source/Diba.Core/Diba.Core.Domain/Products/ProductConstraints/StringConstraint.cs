namespace Diba.Core.Domain.Products.ProductConstraints
{
    public class StringConstraint : ProductConstraint
    {
        public long MaxLength { get; private set; }
        public string Format
        { get; private set; }

        public StringConstraint(long maxLength)
        {
            MaxLength = maxLength;
        }
    }
}