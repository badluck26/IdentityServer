using Microsoft.AspNetCore.Mvc;
using TechDaniels.IdentityServer.Domain.Requests;
using TechDaniels.IdentityServer.Core.Services;

namespace TechDaniels.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService,ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost()]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _authService.Login(loginRequest);

            return StatusCode(result.HttpStatusCode, result.IsSuccess() ? result.Data : result.Message);
        }
    }
}
