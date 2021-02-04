using Diba.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain
{
    public class Organization: IEditable
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Prefix { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        #region Editable ...
        public long? ModifierId { get; set; }
        public virtual User Modifier { get; set; }
        public DateTime Modification { get; set; }

        public long? CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public DateTime Creation { get; set; }
        #endregion

        public Organization(string title)
        {
            Title = title;
            Creation = DateTime.UtcNow;
            Customers = new HashSet<Customer>();
        }

        public Organization()
        {
            Creation = DateTime.Now;
            Creation = DateTime.UtcNow;
            Customers = new HashSet<Customer>();
        }
    }
}
