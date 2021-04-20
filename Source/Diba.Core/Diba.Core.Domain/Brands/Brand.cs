namespace Diba.Core.Domain
{
    public class Brand : BaseEntity<long>
    {
        public long CompanyId { get; private set; }
        public string Name { get; private set; }
        public virtual Company Company { get; set; }

        public Brand() { }
        public Brand(long id, long companyId, string name)
        {
            this.Id = id;
            this.CompanyId = companyId;
            Name = name;
        }
    }
}