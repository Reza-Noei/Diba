using Diba.Core.Common;
using System.Text;

namespace Diba.Core.Domain
{
    public class ContactInfo: BaseEntity<long>
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public string CalleeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
