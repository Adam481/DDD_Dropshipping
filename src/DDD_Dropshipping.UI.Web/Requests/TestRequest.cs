using DDD_Dropshipping.UI.Web.Routing;

namespace DDD_Dropshipping.UI.Web.Requests
{
    public class GetAllOrders { }
    public class OrdersViewModel
    {
        public string Message { get; set; }
    }

    public class TestOrderingRequest : IRequest<GetAllOrders, OrdersViewModel>
    {

        public GetAllOrders Request { get; set; }
        public OrdersViewModel Repsonse { get; set; }
    }


    public class GetAllShipping { }
    public class ShippingsViewModel
    {
        public string Message { get; set; }
    }

    public class TestShippingRequest : IRequest<GetAllShipping, ShippingsViewModel>
    {
        public GetAllShipping Request { get; set; }
        public ShippingsViewModel Repsonse { get; set; }
    }



    public class GetAllStockpillingItems { }
    public class StockpillingViewModel
    {
        public string Message { get; set; }
    }

    public class TestStockpillingRequest : IRequest<GetAllStockpillingItems, StockpillingViewModel>
    {
        public GetAllStockpillingItems Request { get; set; }
        public StockpillingViewModel Repsonse { get; set; }
    }
}
