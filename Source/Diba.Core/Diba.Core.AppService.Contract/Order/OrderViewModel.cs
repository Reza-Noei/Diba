using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public class OrderViewModel
    {
        public long Id { get; set; }

        public IList<RequestItemViewModel> RequestItems { get; set; }
    }
}
