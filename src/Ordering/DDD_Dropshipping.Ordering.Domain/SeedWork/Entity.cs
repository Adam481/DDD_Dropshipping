using System;
using System.Collections.Generic;

namespace DDD_Dropshipping.Ordering.Domain.SeedWork
{
    public abstract class Entity
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            if (eventItem == null) throw new ArgumentNullException();
            _domainEvents.Add(eventItem);
        }


        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            if (eventItem == null) throw new ArgumentNullException();
            _domainEvents.Remove(eventItem);
        }


        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
   
}
