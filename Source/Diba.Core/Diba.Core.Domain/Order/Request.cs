using System;

namespace Diba.Core.Domain
{
    public class Request
    {

        public string Items { get; private set; }

        public decimal AnnouncedPrice { get; private set; }

        private Request(string items, decimal announcedPrice)
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