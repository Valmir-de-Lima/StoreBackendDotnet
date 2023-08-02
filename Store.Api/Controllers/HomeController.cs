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

        [HttpPost("")]
        public async Task<IActionResult> Create(
            [FromServices] IConfiguration config,
            [FromServices] UserHandler handler
)
        {
            try
            {
                return Ok((CommandResult)await handler.HandleAsync(BuilderExtensions.CreateManager(config)));
            }
            catch
            {
                return StatusCode(500, new CommandResult(false,
                    "Erro ao acessar o banco de dados"
                ));
            }
        }
    }
}