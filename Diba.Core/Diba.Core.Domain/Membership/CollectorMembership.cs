using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain
{
    public class CollectorMembership: OrganizationMembership
    {
        public long CollectorId { get; }
        public virtual Collector Collector { get; }
        public virtual ICollection<CustomerOrder> Orders { get; set; }
        public CollectorMembership(Collector Collector, Authority Authority, Organization Organization) :base(Authority, Organization)
        {
            this.Collector = Collector;
            Orders = new HashSet<CustomerOrder>();
        }

        internal CollectorMembership() { }
    }
}
