using DDD_Dropshipping.Ordering.Domain.SeedWork;
using System.Collections.Generic;

namespace DDD_Dropshipping.Ordering.Domain.OrderAggregate
{
    public abstract class Currency : Enumeration<Currency, int>
    {
        protected Currency(int value, string displayName) 
            : base(value, displayName) {}


        private class Euro : Currency
        {
            protected Euro() : base(0, "Euro")
            {
            }
        }


        private class USD : Currency
        {
            protected USD() : base(1, "USD")
            {
            }
        }


        public class GBP : Currency
        {
            protected GBP() : base(2, "GBP")
            {
            }
        }
    }
}
