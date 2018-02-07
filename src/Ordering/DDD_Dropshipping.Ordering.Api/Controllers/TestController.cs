using DDD_Dropshipping.Ordering.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DDD_Dropshipping.Ordering.Api.Controllers
{
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
