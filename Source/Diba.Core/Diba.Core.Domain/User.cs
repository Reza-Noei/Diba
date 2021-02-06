using Diba.Core.Domain.Base;
using System;
using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class User: ICreatable
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        #region Editable ...
        public long? CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public DateTime Creation { get; set; }
        #endregion

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<ContactInfo> ContactInfos { get; set; }

        public User(User creator):this()
        {
            Creator = creator;
            ContactInfos = new HashSet<ContactInfo>();
        }

        public User()
        {
            Creation = DateTime.Now;
            ContactInfos = new HashSet<ContactInfo>();
        }
    }
}
