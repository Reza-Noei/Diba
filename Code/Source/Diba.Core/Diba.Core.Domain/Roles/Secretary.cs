using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class Secretary
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public virtual BaseRole Role { get; set; }

        public virtual ICollection<SecretaryMembership> Memberships { get; set; }

        public Secretary()
        {
            Memberships = new HashSet<SecretaryMembership>();
        }
    }
}
