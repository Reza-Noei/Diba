using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Diba.Core.AppService.Contract
{
    public class CreateInvoiceInputModel
    {
        [JsonIgnore]
        public long SecretaryId { get; set; }
        public string SerialNumber { get; set; }
        public long CustomerMembershipId { get; set; }
        public decimal EarnestMoney { get; set; }
        public IEnumerable<CreateCustomerOrderInputModel> Orders { get; set; }
    }

    public class CreateCustomerOrderInputModel
    {
        public long UnitId { get; set; }
        public long ServiceTypeId { get; set; }
        public int Count { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public PaymentType PaymentType { get; set; }
        public string ServiceDescription { get; set; }
    }

    public enum PaymentType
    {
        Cash = 1,
        NonCash = 3
    }
}
