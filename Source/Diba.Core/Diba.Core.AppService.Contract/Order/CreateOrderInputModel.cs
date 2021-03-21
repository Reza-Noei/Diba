using Diba.Core.AppService.Contract.RequestItem;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.Order
{
    public class CreateOrderInputModel
    {
        public long CustomerId { get; set; }

        public IList<RequestItemViewModel> RequestItems { get; set; }
    }
}