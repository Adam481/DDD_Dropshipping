using DDD_Dropshipping.Ordering.Domain.SeedWork;
using System;
using System.Collections;

namespace DDD_Dropshipping.Ordering.Domain.OrderAggregate
{
    public class Order : Entity
    {
        public string Customer { get; private set; } // TODO: model customer entity for Order Aggregate if required
        public DateTime Date { get; private set; }
        public Address BillingAddress { get; private set; }
        public Address ShippingAddress { get; private set; }
        public Money TotalValue { get; private set; }
        public OrderState State { get; private set; }
        public ICollection Items { get; private set; }
    }
}
