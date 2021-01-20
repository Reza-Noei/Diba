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

        //private List<Service> _services { get; set; }
        //public IReadOnlyCollection<Service> Services => _services.AsReadOnly();
        public OrderState State { get; private set; }
        public Order()
        {
            this._items = new List<OrderItem>();
            this.State = new CollectedState();
        }

        public void UpdateItems(List<OrderItem> itmes)
        {
            this._items.Update(itmes);
        }

        //public void AddServices(List<Service> service)
        //{
        //    if (!State.CanModify())
        //        throw new Exception();

        //    this._services.AddRange(service);
        //}
        //public void AcceptServiceVisitor(IServiceVisitor visitor)
        //{
        //    foreach (var service in Services)
        //    {
        //        service.AcceptVisitor(visitor);
        //    }
        //}
    }


}