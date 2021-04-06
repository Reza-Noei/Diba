using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public class CreateOrderInputModel
    {
        public long CustomerId { get; set; }

        public IList<RequestItemViewModel> RequestItems { get; set; }
    }
}