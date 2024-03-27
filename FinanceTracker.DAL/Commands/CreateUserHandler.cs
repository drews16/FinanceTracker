using FinanceTracker.Application.Commands.User;
using FinanceTracker.Application.Repository;
using FinanceTracker.Common.Result;
using FinanceTracker.Domain.Entity;
using FinanceTracker.DTOs.DTOs;
using MediatR;

namespace FinanceTracker.DAL.Commands
{
    public sealed class CreateUserHandler(
        IUserRepository userRepository) : IRequestHandler<CreateUserCommand, BaseResult<UserDto>>
    {
        public async Task<BaseResult<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository
                .GetByLogin(request.Login, cancellationToken);

            if(user != null)
            {
                return new BaseResult<UserDto>
                {
                    ErrorMessages = new List<string> { "Пользователь уже зарегистрирован" }
                };
            }

            //todo: add user validation.
            
            user = await userRepository.CreateAsync(new User
            { 
                FirstName = request.FisrtName,
                LastName = request.LastName,
                Login = request.Login,
                Password = request.Password
            }, cancellationToken);
            
            return new BaseResult<UserDto>
            {
                Result = new UserDto(
                    Id: user.Id,
                    FirstName: user.FirstName)
            };
        }
    }
}