namespace Diba.Core.Domain
{
    public class Brand
    {
        public long companyId { get; private set; }
        public string Name { get; private set; }

        public Brand(long companyId, string name)
        {
            this.companyId = companyId;
            Name = name;
        }
    }
}