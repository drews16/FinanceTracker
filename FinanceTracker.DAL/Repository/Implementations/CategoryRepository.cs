using FinanceTracker.DAL.Database;
using FinanceTracker.DAL.Repository.Interfaces;
using FinanceTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Repository.Implementations
{
    public class CategoryRepository(
        ApplicationDbContext context) : ICategoryRepository
    {
        public async Task<IReadOnlyCollection<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Categories
                .ToListAsync(cancellationToken);
        }
    }
}
