using DDD_Dropshipping.Application.Utils;
using DDD_Dropshipping.UI.Web.Routing;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace DDD_Dropshipping.Application
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



        public async Task<TResponse> Handle<TRequest, TResponse>(IRequest<TRequest, TResponse> requestObj)
            => await GetHandler<TRequest, TResponse>().Handle(requestObj.Request);


        private IHandler<TRequest, TResponse> GetHandler<TRequest, TResponse>()
        {
            var handlerType = typeof(IHandler<TRequest, TResponse>);

            if (_handlers.TryGetValue(handlerType, out object handler))
            {
                return (IHandler<TRequest, TResponse>)handler;
            }
            else
            {
                var newHandler = _factory(handlerType);
                _handlers.TryAdd(handlerType, newHandler);
                return (IHandler<TRequest, TResponse>)newHandler;
            }
        }
    }
}