using DDD_Dropshipping.Ordering.Domain.SeedWork;

namespace DDD_Dropshipping.Ordering.Domain.OrderAggregate
{
    public class Money : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } // TODO: refactor to enumeration object


        public Money(decimal amount, string currency)
        {
            // Validation?
            Amount = amount;
            Currency = currency;
        }
    }
}
