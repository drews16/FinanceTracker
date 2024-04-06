using FinanceTracker.Common.Result;
using FinanceTracker.DTOs.DTOs.User;

namespace FiananceTracker.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseResult<UserDto>> RegisterAsync(CreateUserDto dto, CancellationToken cancellationToken);
        Task<BaseResult<UserDto>> LoginAsync(LoginUserDto dto, CancellationToken cancellationToken);
    }
}