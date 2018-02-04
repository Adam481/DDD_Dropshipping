namespace DDD_Dropshipping.UI.Web.Routing
{
    public interface IRequest<TRequest, TRepsonse>
    {
        TRequest Request { get; }
        TRepsonse Repsonse { get; }
    }
}
