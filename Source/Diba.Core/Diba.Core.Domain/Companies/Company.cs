using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class Company : BaseEntity<long>
    {
        public string Name { get; private set; }
        public virtual ICollection<Brand> Brands { get; set; }

        public Company() { }
        public Company(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}