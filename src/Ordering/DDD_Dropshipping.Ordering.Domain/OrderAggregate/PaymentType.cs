using System.Collections.Generic;
using DDD_Dropshipping.Ordering.Domain.SeedWork;

namespace DDD_Dropshipping.Ordering.Domain.OrderAggregate
{
    public abstract class PaymentType : Enumeration<PaymentType, int>
    {
        protected PaymentType(int value, string displayName)
            : base(value, displayName) { }

        
        private class Cache : PaymentType
        {
            protected Cache() : base(0, "Cache")
            { }
            
        }


        private class CreditCard : PaymentType
        {
            protected CreditCard() : base(1, "CreditCard")
            { }
        }


        private class BankTransfer : PaymentType
        {
            protected BankTransfer() : base(2, "BankTransfer")
            { }
        }

        
        private class Paypal : PaymentType
        {
            protected Paypal() : base(3, "Paypal")
            { }
        }
    }
}
