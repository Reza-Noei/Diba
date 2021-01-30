using Diba.Core.Domain.Base;
using System;
using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class Authority: IEditable
    {
        public long Id { get; set; }

        public bool Active { get; set; }

        #region Editable ...
        public virtual User Modifier { get; set; }
        public DateTime Modification { get; set; }
        public virtual User Creator { get; set; }
        public DateTime Creation { get; set; }
        #endregion

        public virtual ICollection<AuthorityPermission> Permissions { get; set; }

        public Authority()
        {
            Permissions = new HashSet<AuthorityPermission>();
        }
    }
}