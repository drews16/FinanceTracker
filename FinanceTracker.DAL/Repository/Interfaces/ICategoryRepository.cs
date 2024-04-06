using FinanceTracker.Domain.Entity;

namespace FinanceTracker.DAL.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyCollection<Category>> GetAllAsync(CancellationToken cancellationToken);
    }
}