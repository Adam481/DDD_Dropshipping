using System;
using System.Threading.Tasks;

namespace DDD_Dropshipping.UI.Web.Routing
{
    public delegate object HandlersFactory(Type interfaceType);

    public interface IMediator
    {
        void Register(HandlersFactory factory);
        Task<TResponse> Handle<TRequet, TResponse>(IRequest<TRequet, TResponse> request);
    }
}
