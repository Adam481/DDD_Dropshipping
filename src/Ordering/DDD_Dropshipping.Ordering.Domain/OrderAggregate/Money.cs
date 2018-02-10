using System.Collections.Generic;
using DDD_Dropshipping.Ordering.Domain.SeedWork;

namespace DDD_Dropshipping.Ordering.Domain.OrderAggregate
{
    public class Money : ValueObject<Money>
    {
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; } // TODO: refactor to enumeration object


        public Money(decimal amount, Currency currency)
        {
            // Validation?
            Amount = amount;
            Currency = currency;
        }


        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
