using DDD_Dropshipping.UI.Web.Requests;
using DDD_Dropshipping.UI.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DDD_Dropshipping.UI.Web.Controllers
{
    [Route("api/testcore")]
    [Produces("application/json")]
    public class TestController : Controller
    {
        private IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return new JsonResult("test gateway");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }
    }

    [Route("api/testordering")]
    [Produces("application/json")]
    public class TestOrderingController : Controller
    {
        private IMediator _mediator;

        public TestOrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _mediator.Handle(new TestOrderingRequest());
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }


    [Route("api/testshipping")]
    [Produces("application/json")]
    public class TestShippingController : Controller
    {
        private IMediator _mediator;

        public TestShippingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _mediator.Handle(new TestShippingRequest());
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }


    [Route("api/teststockpilling")]
    [Produces("application/json")]
    public class TestStockpilling : Controller
    {
        private IMediator _mediator;

        public TestStockpilling(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _mediator.Handle(new TestStockpillingRequest());
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
