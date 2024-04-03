using FiananceTracker.BLL.Services.Interfaces;
using FinanceTracker.Common.Result;
using FinanceTracker.DAL.Repository.Interfaces;
using FinanceTracker.Domain.Entity;
using FinanceTracker.DTOs.DTOs.User;

namespace FiananceTracker.BLL.Services.Implementations
{
    public sealed class UserService(
        IUserRepository userRepository) : IUserService
    {
        public async Task<BaseResult<UserDto>> RegisterAsync(CreateUserDto dto, CancellationToken cancellationToken)
        {
            if(dto.Password != dto.Password)
            {
                return new BaseResult<UserDto>
                {
                    ErrorMessages = new List<string> { "Пароли не совпадают" }
                };
            }

            // todo: Add validate user properties.

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Login = dto.Login,
                Password = dto.Password
            };

            await userRepository.CreateAsync(user, cancellationToken);

            // todo: Add access token generator.

            return new BaseResult<UserDto>
            {
                Result = new UserDto(
                    UserId: user.Id,
                    FirstName: user.FirstName,
                    AccessToken: "")
            };
        }
    }
}