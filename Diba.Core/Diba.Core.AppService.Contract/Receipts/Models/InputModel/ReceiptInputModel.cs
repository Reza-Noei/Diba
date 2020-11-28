using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Diba.Core.AppService.Contract
{
    public class ReceiptInputModel
    {
        [JsonIgnore]
        public long SecretaryId { get; set; }
        public long CustomerId { get; set; }
        public IEnumerable<ReceiptItemInputModel> Items { get; set; }
    }
}
