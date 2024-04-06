using FiananceTracker.BLL.Services.Interfaces;
using FinanceTracker.Common.Result;
using FinanceTracker.DAL.Repository.Interfaces;
using FinanceTracker.Domain.Entity;
using FinanceTracker.DTOs.DTOs.User;
using System.Security.Claims;

namespace FiananceTracker.BLL.Services.Implementations
{
    public sealed class UserService(
        IUserRepository userRepository,
        ITokenService tokenService) : IUserService
    {
        public async Task<BaseResult<UserDto>> LoginAsync(LoginUserDto dto, CancellationToken cancellationToken)
        {
            var user = await userRepository
                .GetByLoginAsync(dto.Login, cancellationToken);

            if(user == null)
            {
                return new BaseResult<UserDto>
                {
                    ErrorMessages = new List<string> { "Неверный логин или пароль" }
                };
            }

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var accessToken = tokenService.CreateJwtToken(userClaims);

            return new BaseResult<UserDto>
            {
                Result = new UserDto(
                    UserId: user.Id,
                    FirstName: user.FirstName,
                    AccessToken: accessToken)
            };
        }

        public async Task<BaseResult<UserDto>> RegisterAsync(CreateUserDto dto, CancellationToken cancellationToken)
        {
            if(dto.Password != dto.ConfirmedPassword)
            {
                return new BaseResult<UserDto>
                {
                    ErrorMessages = new List<string> { "Пароли не совпадают" }
                };
            }

            var user = await userRepository
                .GetByLoginAsync(dto.Login, cancellationToken);

            if(user != null)
            {
                return new BaseResult<UserDto>
                {
                    ErrorMessages = new List<string> { "Пользователь уже зарегистрирован" }
                };
            }

            // todo: Add validate user properties.

            user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Login = dto.Login,
                Password = dto.Password
            };

            await userRepository.CreateAsync(user, cancellationToken);

            var userClaims = new List<Claim> 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var accessToken = tokenService.CreateJwtToken(userClaims);

            return new BaseResult<UserDto>
            {
                Result = new UserDto(
                    UserId: user.Id,
                    FirstName: user.FirstName,
                    AccessToken: accessToken)
            };
        }
    }
}