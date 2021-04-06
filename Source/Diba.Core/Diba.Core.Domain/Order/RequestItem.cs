using System;

namespace Diba.Core.Domain
{
    public class RequestItem
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public decimal AnnouncedPrice { get; set; }

        public long OrderId { get; set; }

        public virtual Order Order { get; set; }

        public RequestItem()
        {

        }

        RequestItem(string title, decimal announcedPrice)
        {
            this.Title = title;
            this.AnnouncedPrice = announcedPrice;
        }

        public static RequestItem Create(string items, decimal announcedPrice)
        {
            return new RequestItem(items, announcedPrice);
        }
    }
}