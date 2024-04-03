using FinanceTracker.DAL.Database;
using FinanceTracker.DAL.Repository.Interfaces;
using FinanceTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Repository.Implementations
{
    public sealed class UserRepository(
        ApplicationDbContext context) : IUserRepository
    {
        public async Task<User> CreateAsync(User entity, CancellationToken cancellationToken)
        {
            await context.Users.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken)
        {
            return await context.Users
                .FirstOrDefaultAsync(x => x.Login == login, cancellationToken);
        }
    }
}