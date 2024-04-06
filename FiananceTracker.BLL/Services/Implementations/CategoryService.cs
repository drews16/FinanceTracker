using FiananceTracker.BLL.Services.Interfaces;
using FinanceTracker.Common.Result;
using FinanceTracker.DAL.Repository.Interfaces;
using FinanceTracker.DTOs.DTOs.Category;

namespace FiananceTracker.BLL.Services.Implementations
{
    public sealed class CategoryService(
        ICategoryRepository categoryRepository) : ICategoryService
    {
        public async Task<BaseResult<IReadOnlyCollection<CategoryDto>>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            var categories = await categoryRepository
                .GetAllAsync(cancellationToken);

            return new BaseResult<IReadOnlyCollection<CategoryDto>>
            { 
                Result = categories
                    .Select(x => new CategoryDto(
                        Id: x.Id,
                        Name: x.Name)
                    )
                    .ToList()
            };
        }
    }
}