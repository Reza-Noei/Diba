namespace Diba.Core.Domain
{
    public class TransportationService : Service
    {
        public decimal Fee { get; private set; }
        public TransportationService(int id, string title, decimal fee) : base(id, title)
        {
            Fee = fee;
        }
        public override void AcceptVisitor(IServiceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}