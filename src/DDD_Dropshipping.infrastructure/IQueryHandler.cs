using System.Threading.Tasks;

namespace DDD_Dropshipping.infrastructure
{
    public interface IQueryHandler<TQuery>
    {
        Task<TQuery> Handle(TQuery query);
    }
}
