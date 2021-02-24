namespace Diba.Core.Domain
{
    public class Service
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public decimal Fee { get; private set; }
        public int ProductId { get; private set; }
        public Service(int id, string title, decimal fee, int productId)
        {
            Id = id;
            Title = title;
            Fee = fee;
            ProductId = productId;
        }
    }
}