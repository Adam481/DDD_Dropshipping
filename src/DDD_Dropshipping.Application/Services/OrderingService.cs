using DDD_Dropshipping.UI.Web.Requests;
using DDD_Dropshipping.UI.Web.Routing;
using System.Threading.Tasks;

namespace DDD_Dropshipping.Application
{
    class OrderingService :
        IHandler<GetAllOrders, OrdersViewModel>
    {
        public Task<OrdersViewModel> Handle(GetAllOrders query)
        {
            return Task.FromResult(new OrdersViewModel() { Message = "hello from OrderingService" });
        }
    }
}
