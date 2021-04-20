namespace Diba.Core.AppService.Contract.Brands
{
    public class UpdateBrandInputModel
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
    }
}