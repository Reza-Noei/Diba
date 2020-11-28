using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class Delivery
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public virtual BaseRole Role { get; set; }

        public virtual ICollection<DeliveryMembership> Memberships { get; set; }

        public Delivery()
        {
            Memberships = new HashSet<DeliveryMembership>();
        }
    }
}
