using FinanceTracker.Application.Repository;
using FinanceTracker.DAL.Database;
using FinanceTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Repository
{
    internal sealed class UserRepository(
        ApplicationDbContext context) : IUserRepository
    {
        public async Task<User> CreateAsync(User entity, CancellationToken cancellationToken)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> GetByLogin(string login, CancellationToken cancellationToken)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(x => x.Login == login, cancellationToken);

            return user;
        }
    }
}