using DDD_Dropshipping.UI.Web.Requests;
using DDD_Dropshipping.UI.Web.Routing;
using System.Threading.Tasks;

namespace DDD_Dropshipping.Application
{
    class StockpilingService :
        IHandler<GetAllStockpillingItems, StockpillingViewModel>
    {
        public Task<StockpillingViewModel> Handle(GetAllStockpillingItems query)
        {
            return Task.FromResult(new StockpillingViewModel() { Message = "hello from StockpilingService" });
        }
    }
}
