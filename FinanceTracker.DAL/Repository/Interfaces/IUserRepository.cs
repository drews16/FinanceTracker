using FinanceTracker.Domain.Entity;

namespace FinanceTracker.DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User entity, CancellationToken cancellationToken);
        Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken);
    }
}