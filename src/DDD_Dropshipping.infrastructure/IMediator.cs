using System;
using System.Threading.Tasks;

namespace DDD_Dropshipping.infrastructure
{
    public delegate object HandlersFactory(Type interfaceType);

    public interface IMediator
    {
        void Register(HandlersFactory factory);
        Task<TCommand> Send<TCommand>(TCommand command);
        Task<TQuery> Request<TQuery>(TQuery query);
    }
}
