using System.Collections.Generic;
using System.Linq;

namespace Diba.Core.Domain.Products.ProductConstraints
{
    public class SelectiveConstraint : ProductConstraint
    {
        private List<Option> options;
        public IReadOnlyList<Option> Options => options.AsReadOnly();

        public SelectiveConstraint(long constraintId, List<Option> options)
            : base(constraintId)
        {
            GuardAgaintsDuplicateValueIn(options);

            this.options = options;
        }

        private static void GuardAgaintsDuplicateValueIn(List<Option> options)
        {
            var hasDuplicateValue = options
                .GroupBy(product => product.Key,
                                    (key, value) => new { key, Count = value.Count() })
                .Any(group => group.Count > 1);

            if (hasDuplicateValue)
                throw new DuplicateOptionException();
        }

        public bool Validate(int value)
        {
            return options.Any(a => a.Key == value);
        }
    }
}