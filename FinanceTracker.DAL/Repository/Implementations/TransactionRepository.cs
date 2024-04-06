using FinanceTracker.DAL.Database;
using FinanceTracker.DAL.Repository.Interfaces;
using FinanceTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Repository.Implementations
{
    public sealed class TransactionRepository(
        ApplicationDbContext context) : ITransactionRepository
    {
        public async Task<Transaction> CreateAsync(Transaction entity, CancellationToken cancellationToken)
        {
            await context.Transactions.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<IReadOnlyCollection<Transaction>> GetAllAsync(int userId, CancellationToken cancellationToken)
        {
            return await context.Transactions
                .Include(x => x.Category)
                .Where(x => x.UserId == userId)
                .ToListAsync(cancellationToken);
        }
    }
}