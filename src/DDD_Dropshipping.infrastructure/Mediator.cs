using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD_Dropshipping.infrastructure
{
    class Mediator : IMediator
    {
        private HandlersFactory _factory;
        private ConcurrentDictionary<Type, object> _handlers = new ConcurrentDictionary<Type, object>();

        public Mediator(HandlersFactory factory) : this()
        {
            Guard.ThrowIfNull(factory, $"{nameof(factory)} cannot be null");
            _factory = factory;
        }

        public Mediator() { }


        public void Register(HandlersFactory factory)
        {
            Guard.ThrowIfNull(factory, $"{nameof(factory)} cannot be null");
            _factory = factory;
        }


        public async Task<TCommand> Send<TCommand>(TCommand command)
            => await GetCommandHandler(command).Handle(command);


        public async Task<TQuery> Request<TQuery>(TQuery query)
            => await GetQueryHandler(query).Handle(query);


        private ICommandHandler<TCommand> GetCommandHandler<TCommand>(TCommand command)
        {
            var handler = _factory(typeof(ICommandHandler<TCommand>));
            return (ICommandHandler<TCommand>)_handlers.GetOrAdd(typeof(ICommandHandler<TCommand>), handler);
        }


        private IQueryHandler<TQuery> GetQueryHandler<TQuery>(TQuery query)
        {
            var handler = _factory(typeof(IQueryHandler<TQuery>));
            return (IQueryHandler<TQuery>)_handlers.GetOrAdd(typeof(IQueryHandler<TQuery>), handler);
        }
    }
}
