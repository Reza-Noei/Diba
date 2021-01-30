using Diba.Core.Domain.Products.ProductConstraints;
using System.Collections.Generic;

namespace Diba.Core.Domain.Products
{
    public class Product
    {
        public long Id { get; set; }
        
        public string Title => ProductClass.Name;
        
        public virtual ProductClass ProductClass { get; set; }

        public ICollection<ConrstraintValue> ConstraintValue { get; set; }
    }

    public class ProductClass : BaseEntity<int>
    {
        public ProductClass()
        {

        }

        public virtual ICollection<ProductClassConstraint> Constraints { get; set; }

        public string Name { get; private set; }

        public ProductClass(string name, List<ProductClassConstraint> constraints)
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
