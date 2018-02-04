using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DDD_Dropshipping.Shipping.Api.Controllers
{
    [Route("api/test")]
    [Produces("application/json")]
    public class TestController : Controller
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return new JsonResult("TEST Shipping");
        }
    }
}
