using Diba.Core.Domain.Products.ProductConstraints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Diba.Core.Domain.Products
{
    public class Product : BaseEntity<int>
    {
        public Product()
        {

        }

        public virtual List<ProductConstraint> Constraints { get; set; }

        public string Name { get; private set; }

        public Product(string name, List<ProductConstraint> constraints)
        {
            //GuardAgainstDuplicateConstraint(constraints);

            this.Name = name;
            this.Constraints = constraints;
        }

        public void Update(string name)
        {
            this.Name = name;
        }

        //private static void GuardAgainstDuplicateConstraint(List<ProductConstraint> constraints)
        //{
        //    var anyDuplicate = constraints.GroupBy(a => a.ConstraintId, (key, value) => new { key, value })
        //        .Any(a => a.value.Count() > 1);
        //    if (anyDuplicate)
        //        throw new DuplicateProductConstraintException();
        //}
    }
}
