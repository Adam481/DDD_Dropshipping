using DDD_Dropshipping.UI.Web.Requests;
using DDD_Dropshipping.UI.Web.Routing;
using System.Threading.Tasks;

namespace DDD_Dropshipping.Application
{
    class ShippingService :
        IHandler<GetAllShipping, ShippingsViewModel>
    {
        public Task<ShippingsViewModel> Handle(GetAllShipping query)
        {
            return Task.FromResult(new ShippingsViewModel() { Message = "hello from ShippingService" });
        }
    }
}
