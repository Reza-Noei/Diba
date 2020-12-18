using System;

namespace Diba.Core.Domain.Products.ProductConstraints
{
    public class StringConstraint : ProductConstraint
    {
        public int MaxLength { get; private set; }
        public string Format { get; private set; }

        public StringConstraint(int maxLength)
        {
            MaxLength = maxLength;
        }

        public void Update(string title, string format, int maxLength)
        {
            MaxLength = maxLength;
            Format = format;
            Title = title;
        }
    }
}