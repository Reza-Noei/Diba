using Diba.Core.Domain.Products.ProductConstraints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Diba.Core.Domain.Products
{
    public class Product : BaseEntity<int>
    {
        private List<ProductConstraint> _constraints;
        //private List<ProductConstraint> constraints;

        public string Name { get; private set; }
        public ReadOnlyCollection<ProductConstraint> Constraints => _constraints.AsReadOnly();

        public Product(string name, List<ProductConstraint> constraints)
        {
            GuardAgainstDuplicateConstraint(constraints);

            this.Name = name;
            this._constraints = constraints;
        }

        public void Update(string name)
        {
            this.Name = name;
        }

        private static void GuardAgainstDuplicateConstraint(List<ProductConstraint> constraints)
        {
            var anyDuplicate = constraints.GroupBy(a => a.ConstraintId, (key, value) => new { key, value })
                .Any(a => a.value.Count() > 1);
            if (anyDuplicate)
                throw new DuplicateProductConstraintException();
        }
    }
}
