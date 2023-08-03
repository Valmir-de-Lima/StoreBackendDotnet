using Microsoft.AspNetCore.Mvc;
using Store.Domain.Handlers.UserHandlers;
using Store.Shared.Commands;
using Store.Api.Extensions;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get(
            [FromServices] IConfiguration config)
        {
            var version = config.GetValue<string>("Version");
            return Ok(new
            {
                version
            });
        }
    }
}