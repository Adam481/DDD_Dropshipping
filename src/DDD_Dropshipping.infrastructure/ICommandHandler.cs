using System.Threading.Tasks;

namespace DDD_Dropshipping.infrastructure
{
    public interface ICommandHandler<TCommand>
    {
        Task<TCommand> Handle(TCommand command);
    }
}
