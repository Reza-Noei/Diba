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

        public virtual ICollection<SecretaryMembership> SecretaryMemberships { get; set; }
        public virtual ICollection<SuperAdminMembership> SuperAdminMemberships { get; set; }
        public virtual ICollection<AdminMembership> AdminMemberships { get; set; }
        public virtual ICollection<CustomerMembership> CustomerMemberships { get; set; }
        public virtual ICollection<DeliveryMembership> DeliveryMemberships { get; set; }
        public virtual ICollection<CollectorMembership> CollectorMemberships { get; set; }        

        #region Editable ...
        public long? ModifierId { get; set; }
        public virtual User Modifier { get; set; }
        public DateTime Modification { get; set; }

        public long? CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public DateTime Creation { get; set; }
        #endregion

        public Organization(string title): this()
        {
            Title = title;
        }

        public Organization()
        {
            Creation = DateTime.Now;

            SecretaryMemberships = new HashSet<SecretaryMembership>();
            SuperAdminMemberships = new HashSet<SuperAdminMembership>();
            AdminMemberships = new HashSet<AdminMembership>();
            CustomerMemberships = new HashSet<CustomerMembership>();
            DeliveryMemberships = new HashSet<DeliveryMembership>();
            CollectorMemberships = new HashSet<CollectorMembership>();
        }
}
}
