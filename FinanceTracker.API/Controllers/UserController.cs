using FiananceTracker.BLL.Services.Interfaces;
using FinanceTracker.Common.Extensions;
using FinanceTracker.DTOs.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class UserController(
        IUserService userService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(
            [FromBody] CreateUserDto request,
            CancellationToken cancellationToken)
        {
            var response = await userService
                .RegisterAsync(request, cancellationToken);

            return response.ToActionResult();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(
            [FromBody] LoginUserDto request,
            CancellationToken cancellationToken)
        {
            var response = await userService
                .LoginAsync(request, cancellationToken);

            return response.ToActionResult();
        }
    }
}