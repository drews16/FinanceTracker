using FiananceTracker.BLL.Services.Interfaces;
using FinanceTracker.Common.Extensions;
using FinanceTracker.DTOs.DTOs.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController(
        ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IReadOnlyCollection<CategoryDto>>> GetCategories(CancellationToken cancellationToken)
        {
            var response = await categoryService
                .GetCategoriesAsync(cancellationToken);

            return response.ToActionResult();
        }
    }
}