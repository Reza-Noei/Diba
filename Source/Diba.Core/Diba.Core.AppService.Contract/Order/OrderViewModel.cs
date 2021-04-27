using System;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public int State { get; set; }
        public string RequestItems { get; set; }
        public int AnnouncedPrice { get; set; }
        public int? CollectorId { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string CollectionLocation { get; set; }
        public int? DelivelerId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryLocation { get; set; }
        public IList<OrderItemViewModel> OrderItems { get; set; }
    }
}
