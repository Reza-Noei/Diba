using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class Admin
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public virtual BaseRole Role { get; set; }
        public virtual ICollection<AdminMembership> Memberships { get; set; }

        public Admin()
        {            
            Memberships = new HashSet<AdminMembership>();
        }
    }
}
