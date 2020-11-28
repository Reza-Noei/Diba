using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain
{
    public class SecretaryMembership: OrganizationMembership
    {
        public long SecretaryId { get; set; }
        public virtual Secretary Secretary { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public SecretaryMembership(Secretary Secretary, Authority Authority, Organization Organization): base(Authority, Organization)
        {
            this.Secretary = Secretary;
            Invoices = new HashSet<Invoice>();
        }

        public SecretaryMembership()
        {

        }
    }
}
