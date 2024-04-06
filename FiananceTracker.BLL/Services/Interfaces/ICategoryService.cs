using FinanceTracker.Common.Result;
using FinanceTracker.DTOs.DTOs.Category;

namespace FiananceTracker.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<BaseResult<IReadOnlyCollection<CategoryDto>>> GetCategoriesAsync(CancellationToken cancellationToken);
    }
}