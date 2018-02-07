using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace DDD_Dropshipping.Ordering.Application.Services
{
    internal class TestService
        : IRequestHandler<PingQuery, string>
    {
        public Task<string> Handle(PingQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }


    



}
