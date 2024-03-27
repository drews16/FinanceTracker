using FinanceTracker.Common.Result;
using FinanceTracker.DTOs.DTOs;
using MediatR;

namespace FinanceTracker.Application.Commands.User
{
    public sealed class CreateUserCommand : IRequest<BaseResult<UserDto>>
    {
        public required string FisrtName { get; init; }
        public required string LastName { get; init; }
        public required string Login { get; init; }
        public required string Password { get; init; }
    }
}