using Diba.Core.Domain.Products.ProductConstraints;
using System.Collections.Generic;
using System.Linq;
using Diba.Core.Common;

namespace Diba.Core.Domain.Products
{
    public class ProductClass : BaseEntity<int>
    {
        public string Name { get; private set; }
        public virtual IReadOnlyCollection<ProductConstraint> Constraints => _constraints.AsReadOnly();

        private List<ProductConstraint> _constraints;

        public virtual IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        private List<Product> _products;

        protected ProductClass()
        {
            _constraints = new List<ProductConstraint>();
            _products = new List<Product>();

        }

        public ProductClass(string name)
        {
            this.Name = name;
            _constraints = new List<ProductConstraint>();
            _products = new List<Product>();

        }

        public void UpdateConstraints(List<ProductConstraint> constraints)
        {
            this._constraints.UpdateFrom(constraints);

             _products.Modify(GenerateActualProductsWithConstraints());
        }

        private List<Product> GenerateActualProductsWithConstraints()
        {
            var actualProductNames = new List<string>();
            var products = new List<Product>();

            foreach (var constraint in _constraints)
            {
                if (!(constraint is SelectiveConstraint selectiveConstraint)) continue;

                actualProductNames.AddRange(selectiveConstraint.Options.Select(option => this.Name + ' ' + constraint.Title + ' ' + option.Value));
            }

            actualProductNames.ForEach(name => products.Add(new Product(name, this)));

            return products;
        }

        public void Update(string name)
        {
            this.Name = name;
        }
    }
}
