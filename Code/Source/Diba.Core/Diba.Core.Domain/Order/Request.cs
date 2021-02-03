using System;

namespace Diba.Core.Domain
{
    public class Request
    {
        public string Client { get; private set; }

        public string Items { get; private set; }

        public int? Collector { get; private set; }

        public DateTime? CollectionDate { get; private set; }

        public string CollectionLocation { get; private set; }

        public int? Deliveler { get; private set; }

        public DateTime? DeliveryDate { get; private set; }

        public string DeliveryLocation { get; private set; }

        public decimal AnnouncedPrice { get; private set; }

        private Request(string client, string items, int? collector, DateTime? collectionDate, string collectionLocation, int? deliveler, DateTime? deliveryDate, string deliveryLocation, decimal announcedPrice)
        {
            this.Client = client;
            this.Items = items;
            this.Collector = collector;
            this.CollectionDate = collectionDate;
            this.CollectionLocation = collectionLocation;
            this.Deliveler = deliveler;
            this.DeliveryDate = deliveryDate;
            this.DeliveryLocation = deliveryLocation;
            this.AnnouncedPrice = announcedPrice;
        }

        public static Request Create(string client, string items, int? collector, DateTime? collectionDate, string collectionLocation,
            int? deliveler, DateTime? deliveryDate, string deliveryLocation, decimal announcedPrice)
        {
            return new Request(client, items, collector, collectionDate, collectionLocation, deliveler, deliveryDate, deliveryLocation, announcedPrice);
        }
    }
}