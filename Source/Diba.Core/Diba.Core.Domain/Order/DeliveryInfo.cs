using System;
using Diba.Core.Common;

namespace Diba.Core.Domain
{
    public class DeliveryInfo
    {
        public int? DelivelerId { get; private set; }

        public DateTime? DeliveryDate { get; private set; }

        public string DeliveryLocation { get; private set; }

        private DeliveryInfo(int? delivelerId, DateTime? deliveryDate, string deliveryLocation)
        {
            this.DelivelerId = delivelerId;
            this.DeliveryDate = deliveryDate;
            this.DeliveryLocation = deliveryLocation;
        }

        public static DeliveryInfo Create(int? delivelerId, DateTime? deliveryDate, string deliveryLocation)
        {
            return new DeliveryInfo(delivelerId, deliveryDate, deliveryLocation);
        }

        public bool IsComplete => !this.DelivelerId.IsNullOrValue(0)  && this.DeliveryDate.HasValue && !String.IsNullOrEmpty(this.DeliveryLocation);
    }
}