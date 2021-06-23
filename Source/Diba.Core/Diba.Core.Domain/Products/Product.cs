using System.Collections.Generic;

namespace Diba.Core.Domain.Products
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; private set; }
        public long? ParentProductId { get; private set; }
        public ProductClass Class { get; set; }
        public virtual ICollection<Service> Services { get; set; }

        public Product(string name, ProductClass productClass)
        {
            this.Name = name;
            this.Class = productClass;
            if (productClass != null)
                this.ParentProductId = productClass.Id;
        }
    }
}
