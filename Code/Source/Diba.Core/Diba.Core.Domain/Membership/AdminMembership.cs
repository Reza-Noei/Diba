using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain
{
    public class AdminMembership: OrganizationMembership
    {
        public long AdminId { get; set; }
        public virtual Admin Admin { get; set; }
        public AdminMembership(Admin Admin, Authority Authority, Organization Organization): base(Authority, Organization)
        {
            this.Admin = Admin;
        }

        internal AdminMembership()
        {

        }
    }
}
