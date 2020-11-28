using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain
{
    public abstract class OrganizationMembership
    {
        public long Id { get; set; }
        public virtual long OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public long AuthorityId { get; set; }
        public virtual Authority Authority { get; set; }
        public OrganizationMembership(Authority Authority, Organization Organization)
        {
            this.OrganizationId = Organization.Id;
            this.Organization = Organization;
            this.Authority = Authority;
        }

        protected OrganizationMembership()
        {

        }
    }
}
