using System;
using System.Collections.Generic;
using Diba.Core.Common;
using Microsoft.EntityFrameworkCore.Internal;

namespace Diba.Core.Domain
{
    public class Order : BaseEntity<long>
    {
        public long CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Request Request { get; set; }

        public virtual IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public OrderState State { get; private set; }

        public virtual CollectionInfo CollectionInfo { get; set; }

        public virtual DeliveryInfo DeliveryInfo { get; set; }

        private List<OrderItem> _orderItems;

        public Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public static Order Create(long customerId, Request request, CollectionInfo collectionInfo, DeliveryInfo deliveryInfo)
        {
            return new Order()
            {
                CustomerId = customerId,

                Request = request,

                CollectionInfo = collectionInfo,

                DeliveryInfo = deliveryInfo,

                State = new RequestedState(),
            };
        }

        public void Update(long customerId, Request request, CollectionInfo collectionInfo, DeliveryInfo deliveryInfo)
        {
            this.CustomerId = customerId;

            this.Request = request;

            if (State.CollectionInfoCanModify())
                this.CollectionInfo = collectionInfo;

            if (State.DeliveryInfoCanModify())
                this.DeliveryInfo = deliveryInfo;
        }

        public void UpdateItems(List<OrderItem> itmes)
        {
            this._orderItems.UpdateFrom(itmes);
        }

        public void Collect()
        {
            if (this.CollectionInfo.IsComplete)
                this.State = State.Collect();
        }

        public void Calculate()
        {
            this.State = this.State.Calculate();
        }

        public void Process()
        {
            this.State = this.State.Process();
        }

        public void Deliver()
        {
            if (this.DeliveryInfo.IsComplete)
                this.State = this.State.Deliver();
        }

        public void Balance()
        {
            this.State = this.State.Balance();
        }
    }
}