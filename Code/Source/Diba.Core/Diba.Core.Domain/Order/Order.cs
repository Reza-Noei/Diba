using System;
using System.Collections.Generic;
using Diba.Core.Common;

namespace Diba.Core.Domain
{
    public class Order
    {
        public long Id { get; private set; }


        private List<OrderItem> _items;

        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        public OrderState State { get; private set; }

        public Request Request { get; private set; }

        public int ClientId { get; private set; }

        public int? CollectorId { get; private set; }

        public DateTime CollectionDate { get; private set; }

        public string CollectionLocation { get; private set; }

        public int? DelivelerId { get; private set; }

        public DateTime DeliveryDate { get; private set; }

        public string DeliveryLocation { get; private set; }

        public Order(int clientId, Request request)
        {
            this._items = new List<OrderItem>();

            this.ClientId = clientId;

            this.Request = request;

            this.State = new RequestedState();
        }

        public void Update(Request request, int clientId, int? collectorId, DateTime collectionDate, string collectionLocation, int? delivelerId, DateTime deliveryDate, string deliveryLocation)
        {
            this.Request = request;
            this.ClientId = clientId;
            this.CollectorId = collectorId;
            this.CollectionDate = collectionDate;
            this.CollectionLocation = collectionLocation;
            this.DeliveryDate = deliveryDate;
            this.DeliveryLocation = deliveryLocation;

            if (State.CollectorCanModify())
                this.CollectorId = collectorId;

            if (State.DelivelerCanModify())
                this.DelivelerId = delivelerId;
        }

        public void UpdateItems(List<OrderItem> itmes)
        {
            if (!State.ItemsCanModify())
                throw new Exception();

            this._items.Update(itmes);
        }

        public void Collect()
        {
            if (this.CollectorId.IsNullOrValue(0))
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
            if (this.DelivelerId.IsNullOrValue(0))
                this.State = this.State.Deliver();
        }

        public void Balance()
        {
            this.State = this.State.Balance();
        }
    }
}