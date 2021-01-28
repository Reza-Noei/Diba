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
        public Order()
        {
            this._items = new List<OrderItem>();
            this.State = new CollectedState();
        }

        public void UpdateItems(List<OrderItem> itmes)
        {
            if (!State.CanModify())
                throw new Exception();

            this._items.Update(itmes);
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
            this.State = this.State.Deliver();
        }

        public void Balance()
        {
            this.State = this.State.Balance();
        }
    }
}