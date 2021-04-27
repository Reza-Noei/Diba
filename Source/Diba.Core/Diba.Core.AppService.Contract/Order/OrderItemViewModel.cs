using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public class OrderItemViewModel
    {
        public long ServiceId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Units { get; set; }
    }

    public class OrderItemsViewModel
    {
        public IList<OrderItemViewModel> OrderItems { get; set; }
    }
}