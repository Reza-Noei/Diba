using System.Collections.Generic;
using Diba.Core.Common;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.Domain.Products
{
    public class GenericProduct : Product
    {
        public virtual IReadOnlyCollection<ProductConstraint> Constraints => _constraints.AsReadOnly();

        private List<ProductConstraint> _constraints;

        public GenericProduct(string name) : base(name)
        {
            _constraints = new List<ProductConstraint>();
        }
        public GenericProduct(string name, GenericProduct parentProduct)
            : base(name, parentProduct)
        {
            _constraints = new List<ProductConstraint>();
        }

        public void UpdateConstraints(List<ProductConstraint> constraints)
        {
            this._constraints.UpdateFrom(constraints);

            //_products.Modify(GenerateActualProductsWithConstraints());
        }

        //private List<Product> GenerateActualProductsWithConstraints()
        //{
        //    var actualProductNames = new List<string>();
        //    var products = new List<Product>();

        //    foreach (var constraint in _constraints)
        //    {
        //        if (!(constraint is SelectiveConstraint selectiveConstraint)) continue;

        //        actualProductNames.AddRange(selectiveConstraint.Options.Select(option => this.Name + ' ' + constraint.Title + ' ' + option.Value));
        //    }

        //    actualProductNames.ForEach(name => products.Add(new Product(name, this)));

        //    return products;
        //}
    }
}