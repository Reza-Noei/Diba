using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Diba.Core.Data")]
namespace Diba.Core.Domain
{
    public class RolePermission
    {
        public long Id { get; set; }
        public ActionEnum Action { get; set; }
        public bool IsGranted { get; set; }

        public RolePermission(ActionEnum Action, bool IsGranted)
        {
            this.Action = Action;
            this.IsGranted = IsGranted;
        }

        public RolePermission()
        {

        }
    }

    public class AuthorityPermission
    {
        public long Id { get; set; }
        public long AuthorityId { get; set; }
        public virtual Authority Authority { get; set; }

        public ActionEnum Action { get; set; }
        public bool IsGranted { get; set; }

        public AuthorityPermission(ActionEnum Action, bool IsGranted)
        {
            this.Action = Action;
            this.IsGranted = IsGranted;
        }

        internal AuthorityPermission()
        {

        }
    }
}