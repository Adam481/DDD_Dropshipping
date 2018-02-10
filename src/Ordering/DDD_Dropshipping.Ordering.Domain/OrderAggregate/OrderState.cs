using DDD_Dropshipping.Ordering.Domain.SeedWork;

namespace DDD_Dropshipping.Ordering.Domain.OrderAggregate
{
    public abstract class OrderState : Enumeration<OrderState, int>
    {
        protected OrderState(int value, string displayName) 
            : base(value, displayName) { }


        private class Registered : OrderState
        {
            protected Registered() : base(0, "Registered") { }
        }


        private class Packed : OrderState
        {
            protected Packed() : base(1, "Packed") { }
        }


        private class Dispatched : OrderState
        {
            protected Dispatched() : base(2, "Dispatched") { }
        }


        private class Delivered : OrderState
        {
            protected Delivered() : base(3, "Delivered") { }
        }
    }
}
