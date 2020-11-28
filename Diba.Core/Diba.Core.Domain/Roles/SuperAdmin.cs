using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class SuperAdmin
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public virtual BaseRole Role { get; set; }

        public virtual ICollection<SuperAdminMembership> Memberships { get; set; }

        public SuperAdmin()
        {
            Memberships = new HashSet<SuperAdminMembership>();
        }
    }
}
