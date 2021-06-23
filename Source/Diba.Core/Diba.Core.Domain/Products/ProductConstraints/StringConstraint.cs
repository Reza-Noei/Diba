using System;

namespace Diba.Core.Domain.Products.ProductConstraints
{
    public class StringConstraint : ProductConstraint
    {
        public int MaxLength { get; private set; }
        public string Format { get; private set; }

        public StringConstraint()
        {
        }

        public StringConstraint(int maxLength, string format, int id, string title) : base(id ,title)
        {
            MaxLength = maxLength;
            MaxLength = maxLength;
            Format = format;
        }
    }
}