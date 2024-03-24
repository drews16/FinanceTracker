using FinanceTracker.Domain.Entity;

namespace FinanceTracker.Application.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User entity, CancellationToken cancellationToken);
        Task<User> GetByLogin(string login, CancellationToken cancellationToken);
    }
}