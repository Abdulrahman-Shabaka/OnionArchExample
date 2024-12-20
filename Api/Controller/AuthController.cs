using Application.Commands;
using Application.Services;

using Microsoft.AspNetCore.Mvc;

using ILogger = Domain.Interfaces.ILogger;

namespace Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthenticateService authenticateService, ILogger logger)
        : ControllerBase
    {

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody] Authenticate authenticate, CancellationToken cancellationToken)
        {
            logger.Log("Processing authentication request");

            var result = await authenticateService.AuthenticateAsync(authenticate, cancellationToken);

            return Ok(result);
        }
    }
}
