using System;
using System.Collections.Generic;
using System.Text;

namespace DDD_Dropshipping.Ordering.Domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
