using System;

namespace Diba.Core.Domain
{
    public class RequestItem
    {
        public string Title { get; private set; }

        public decimal AnnouncedPrice { get; private set; }

        private RequestItem(string title, decimal announcedPrice)
        {
            this.Title = title;
            this.AnnouncedPrice = announcedPrice;
        }

        public static RequestItem Create(string items, decimal announcedPrice)
        {
            return new RequestItem(items, announcedPrice);
        }
    }
