using Microsoft.AspNetCore.Mvc;
using TechDaniels.IdentityServer.Core.Services;
using TechDaniels.IdentityServer.Domain.DTOs;
using TechDaniels.IdentityServer.Domain.Models.Requests;

namespace TechDaniels.IdentityServer.AdminAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost()]
        public async Task<IActionResult> Save(SaveUserRequest request)
        {
            var result = await _userService.Save(request);

            return StatusCode(result.HttpStatusCode, result.Message);
        }
    }
}
