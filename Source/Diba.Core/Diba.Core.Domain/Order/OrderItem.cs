namespace Diba.Core.Domain
{
    public class OrderItem
    {
        public long ServiceId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }

        public OrderItem(long serviceId, decimal unitPrice, int units)
         {
             ServiceId = serviceId;
             UnitPrice = unitPrice;
             Units = units;
         }
    }
}