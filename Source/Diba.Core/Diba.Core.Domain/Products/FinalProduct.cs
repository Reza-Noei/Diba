using System.Collections.Generic;

namespace Diba.Core.Domain.Products
{
    public class FinalProduct : Product
    {
        public virtual ICollection<Service> Services { get; set; }

        public FinalProduct(string name) : base(name)
        {
        }

        public FinalProduct(string name, GenericProduct parentProduct)
            : base(name, parentProduct)
        {
        }
    }
}