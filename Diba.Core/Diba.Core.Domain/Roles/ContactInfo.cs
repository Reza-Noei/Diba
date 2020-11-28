using Diba.Core.Common;
using System.Text;

namespace Diba.Core.Domain
{
    public class ContactInfo
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string CalleeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
