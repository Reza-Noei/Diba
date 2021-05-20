using Diba.Core.Domain.Products.ProductConstraints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Diba.Core.Domain.Products
{
    public class ProductClass : BaseEntity<int>
    {
        public string Name { get; private set; }
        public virtual ICollection<ProductConstraint> Constraints { get; set; }
        public virtual ICollection<Service> Services { get; set; }

        protected ProductClass()
        {
            Constraints = new HashSet<ProductConstraint>();
        }

        public ProductClass(string name, List<ProductConstraint> constraints)
        {
            GuardAgainstDuplicateConstraint(constraints);

            this.Name = name;
            Constraints = new HashSet<ProductConstraint>();
        }

        public void Update(string name)
        {
            this.Name = name;
        }

        private static void GuardAgainstDuplicateConstraint(List<ProductConstraint> constraints)
        {
            var anyDuplicate = constraints.GroupBy(a => a.Id, (key, value) => new { key, value })
                .Any(a => a.value.Count() > 1);
            if (anyDuplicate)
                throw new DuplicateProductConstraintException();
        }
    }
}
