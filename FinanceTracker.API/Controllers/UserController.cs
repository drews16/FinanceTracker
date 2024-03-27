using FinanceTracker.Application.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController(
        IMediator mediator) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand request)
        {
            var response = await mediator
                .Send(request);

            if(!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages);
            }

            return Ok(response.Result);
        }
    }
}