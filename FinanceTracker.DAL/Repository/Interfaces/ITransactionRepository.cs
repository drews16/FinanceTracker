using FinanceTracker.Domain.Entity;

namespace FinanceTracker.DAL.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IReadOnlyCollection<Transaction>> GetAllAsync(int userId, CancellationToken cancellationToken);
        Task<Transaction> CreateAsync(Transaction entity, CancellationToken cancellationToken);
    }
}