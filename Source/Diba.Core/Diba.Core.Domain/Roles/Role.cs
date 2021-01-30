namespace Diba.Core.Domain
{
    public abstract class Role: BaseEntity<long>
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
