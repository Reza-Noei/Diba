namespace Diba.Core.Domain
{
    public class CarpetCleaningService : Service
    {
        public decimal Fee { get; private set; }
        public int ProductId { get; private set; }

        public CarpetCleaningService(int id, string title, int productId, decimal fee) : base(id, title)
        {
            Fee = fee;
            ProductId = productId;
        }
        public override void AcceptVisitor(IServiceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}