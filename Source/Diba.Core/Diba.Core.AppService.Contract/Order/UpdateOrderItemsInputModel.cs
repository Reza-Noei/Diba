using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public class UpdateOrderItemsInputModel
    {
        public long OrderId { get; set; }
        public IList<OrderItemViewModel> OrderItems { get; set; }
    }
}