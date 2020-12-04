using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.Domain.Products
{
    public class Product
    {
        private List<ProductConstraint> _constraints;
        private List<ProductConstraint> constraints;

        public long Id { get; }
        public string Name { get; }
        public ReadOnlyCollection<ProductConstraint> Constraints => _constraints.AsReadOnly();

        public Product(long id, string name, List<ProductConstraint> constraints)
        {
            GuardAgainstDuplicateConstraint(constraints);

            this.Id = id;
            this.Name = name;
            this._constraints = constraints;
        }

        private static void GuardAgainstDuplicateConstraint(List<ProductConstraint> constraints)
        {
            var anyDuplicate = constraints.GroupBy(a => a.ConstraintId, (key, value) => new {key, value})
                .Any(a => a.value.Count() > 1);
            if (anyDuplicate)
                throw new DuplicateProductConstraintException();
        }
    }
}
