using Diba.Core.Domain.Base;
using System;

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

        public User(User creator):this()
        {
            Creator = creator;
        }

        public User()
        {
            Creation = DateTime.Now;
        }
    }
}
