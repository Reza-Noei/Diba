namespace Diba.Core.Domain
{
    public class Request
    {
        public Request()
        {
        }

        public string Items { get; set; }

        public decimal AnnouncedPrice { get; set; }

        Request(string items, decimal announcedPrice)
        {
            this.Items = items;
            this.AnnouncedPrice = announcedPrice;
        }

        public static Request Create(string items, decimal announcedPrice)
        {
            return new Request(items, announcedPrice);
        }
    }
}