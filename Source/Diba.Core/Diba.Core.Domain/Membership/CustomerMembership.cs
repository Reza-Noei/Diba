using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Diba.Core.Data")]
namespace Diba.Core.Domain
{
    public class CustomerMembership : OrganizationMembership
    {
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public CustomerMembership(Customer Customer, Authority Authority, Organization Organization) : base(Authority, Organization)
        {
            this.Customer = Customer;
            Invoices = new HashSet<Invoice>();
        }

        protected CustomerMembership()
        {

        }
    }
}
