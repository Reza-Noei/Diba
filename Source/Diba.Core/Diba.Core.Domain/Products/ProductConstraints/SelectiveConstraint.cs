using System.Collections.Generic;
using System.Linq;

namespace Diba.Core.Domain.Products.ProductConstraints
{
    public class SelectiveConstraint : ProductConstraint
    {
        private List<Option> options;
        public virtual IReadOnlyList<Option> Options => options.AsReadOnly();

        protected SelectiveConstraint()
        {

        }

        public SelectiveConstraint(IEnumerable<Option> options)
        {
            GuardAgaintsDuplicateValueIn(options);

            this.options = options.ToList();
        }

        private static void GuardAgaintsDuplicateValueIn(IEnumerable<Option> options)
        {
            var hasDuplicateValue = options
                .GroupBy(product => product.Key,
                                    (key, value) => new { key, Count = value.Count() })
                .Any(group => group.Count > 1);

            if (hasDuplicateValue)
                throw new DuplicateOptionException();
        }

        public void Update(string title) => this.Title = title;

        public bool Validate(int value)
        {
            return options.Any(a => a.Key == value);
        }
    }
}