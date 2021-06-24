using System.Collections.Generic;
using Diba.Core.Common;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.Domain.Products
{
    public abstract class Product : BaseEntity<int>
    {
        public string Name { get; private set; }
        public long? ParentProductId { get; private set; }

        protected Product(string name) : this(name, null)
        {
        }
        protected Product(string name, GenericProduct parentProduct)
        {
            this.Name = name;
            if (parentProduct != null)
                this.ParentProductId = parentProduct.Id;
        }
        public void Update(string name)
        {
            this.Name = name;
        }
    }
}
