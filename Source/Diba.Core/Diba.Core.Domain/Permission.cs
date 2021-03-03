namespace Diba.Core.Domain
{
    public class Permission
    {
        public Permission()
        {

        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Scope { get; set; }
    }
}