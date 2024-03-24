using FinanceTracker.Application.Commands.User;
using FinanceTracker.Application.Repository;
using FinanceTracker.Common.Result;
using FinanceTracker.Domain.Entity;
using MediatR;

namespace FinanceTracker.DAL.Commands
{
    public sealed class CreateUserHandler(
        IUserRepository userRepository) : IRequestHandler<CreateUserCommand, BaseResult<int>>
    {
        public async Task<BaseResult<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository
                .GetByLogin(request.Login, cancellationToken);

            if(user != null)
            {
                return new BaseResult<int>
                {
                    ErrorMessages = new List<string> { "Пользователь уже зарегистрирован" }
                };
            }

            user = await userRepository.CreateAsync(new User
            { 
                FirstName = request.FisrtName,
                LastName = request.LastName,
                Login = request.Login,
                Password = request.Password
            }, cancellationToken);
            
            return new BaseResult<int>
            {
                Result = user.Id
            };
        }
    }
}