using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain
{
    public class SuperAdminMembership: OrganizationMembership
    {
        public long SuperAdminId { get; set; }
        public virtual SuperAdmin SuperAdmin { get; }
        public SuperAdminMembership(SuperAdmin SuperAdmin, Authority Authority, Organization Organization):base(Authority, Organization)
        {
            this.SuperAdmin = SuperAdmin;
        }

        public SuperAdminMembership()
        {

        }
    }
}
