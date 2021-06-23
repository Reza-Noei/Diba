using System.Collections.Generic;
using Diba.Core.Common;

namespace Diba.Core.Domain.Products.ProductConstraints
{
    public abstract class ProductConstraint : ValueObject<ProductConstraint>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ProductId { get; set; }

        public virtual ProductClass Product { get; set; }

        protected ProductConstraint()
        {

        }

        protected ProductConstraint(int id, string title)
        {
            Id = id;
            Title = title;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return this.Title;
        }
    }
}