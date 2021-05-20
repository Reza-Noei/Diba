using System.Collections.Generic;

namespace Diba.Core.Domain.Products
{
    public class Product
    {
        public string Name { get; set; }
        
        public ProductClass Class { get; set; }
    
        public virtual ICollection<ConstraintValue> ConstraintValues { get; set; }

        public Product(ProductClass productClass)
        {
            Class = productClass;
        }
    }
}
