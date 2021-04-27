using System.Collections.Generic;
using Diba.Core.Common;

namespace Diba.Core.Domain
{
    public class OrderItem : ValueObject<OrderItem>
    {
        public long ServiceId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }

        public OrderItem() { }

        public OrderItem(long serviceId, decimal unitPrice, int units)
         {
             ServiceId = serviceId;
             UnitPrice = unitPrice;
             Units = units;
         }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return this.ServiceId;
            yield return this.UnitPrice;
            yield return this.Units;
        }
    }
}