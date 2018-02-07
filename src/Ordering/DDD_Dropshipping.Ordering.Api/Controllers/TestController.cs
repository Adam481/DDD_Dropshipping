using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DDD_Dropshipping.Ordering.Api.Controllers
{
    //TODO: api versioning
    [Route("api/test")]
    [Produces("application/json")]
    public class TestController : Controller
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new PingQuery());
            return new JsonResult(response);

        }
    }
}
