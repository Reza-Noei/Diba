using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class Order
    {
        public Order()
        {

        }

        public long Id { get; private set; }

        public long CustomerId { get; private set; }

        public virtual Customer Customer { get; set; }

        //public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        //public OrderState State { get; private set; }

        public virtual ICollection<RequestItem> RequestItems { get; set; }

        //public CollectionInfo CollectionInfo { get; private set; }

        //public DeliveryInfo DeliveryInfo { get; private set; }

        //private List<OrderItem> _items;

        public Order(long customerId, List<RequestItem> requestItems)
        {
            //this._items = new List<OrderItem>();

            this.CustomerId = customerId;

            this.RequestItems = requestItems;

            //this.State = new RequestedState();
        }

        public void Update(int customerId, List<RequestItem> requestItems, CollectionInfo collectionInfo, DeliveryInfo deliveryInfo)
        {
            this.CustomerId = customerId;

            this.RequestItems = requestItems;

            //if (State.CollectionInfoCanModify())
            //    this.CollectionInfo = collectionInfo;

            //if (State.DeliveryInfoCanModify())
            //    this.DeliveryInfo = deliveryInfo;
        }

        //public void UpdateItems(List<OrderItem> itmes)
        //{
        //    if (!State.ItemsCanModify())
        //        throw new Exception();

        //    this._items.Update(itmes);
        //}

        //public void Collect()
        //{
        //    if (this.CollectionInfo.IsComplete)
        //        this.State = State.Collect();
        //}

        //public void Calculate()
        //{
        //    this.State = this.State.Calculate();
        //}

        //public void Process()
        //{
        //    this.State = this.State.Process();
        //}

        //public void Deliver()
        //{
        //    if (this.DeliveryInfo.IsComplete)
        //        this.State = this.State.Deliver();
        //}

        //public void Balance()
        //{
        //    this.State = this.State.Balance();
        //}
    }
}