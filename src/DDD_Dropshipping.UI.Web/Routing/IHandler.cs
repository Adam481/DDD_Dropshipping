using System.Threading.Tasks;

namespace DDD_Dropshipping.UI.Web.Routing
{
    public interface IHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest query);
    }
}
