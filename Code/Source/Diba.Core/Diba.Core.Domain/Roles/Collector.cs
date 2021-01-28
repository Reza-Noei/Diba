using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class Collector
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public virtual BaseRole Role { get; set; }

        public virtual ICollection<CollectorMembership> Memberships { get; set; }
        public Collector()
        {
            Memberships = new HashSet<CollectorMembership>();
        }
    }
}
