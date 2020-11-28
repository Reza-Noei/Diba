using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain
{
    public class DeliveryMembership: OrganizationMembership
    {
        public long DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual ICollection<CustomerOrder> Orders { get; set; }
        public DeliveryMembership(Delivery Delivery, Authority Authority, Organization Organization) : base(Authority, Organization)
        {
            this.Delivery = Delivery;
            Orders = new HashSet<CustomerOrder>();
        }

        internal DeliveryMembership()
        {

        }
    }
}
