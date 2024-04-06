using FiananceTracker.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class ExcelController(
        IExcelService excelService) : ControllerBase
    {
        [HttpGet("Reports/TotalByCategories")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<byte>>> ExportTotalByCategories(
            [FromQuery] int month,
            CancellationToken cancellationToken)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            
            var response = await excelService
                .ExportTotalByCategoriesAsync(userId, month, cancellationToken);

            var content = response.Result?.ToArray();

            return File(content!, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Отчет по категориям");
        }

        [HttpGet("Reports/Transactions")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<byte>>> ExportTransactions(CancellationToken cancellationToken)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var response = await excelService
                .ExportTransactionsAsync(userId, cancellationToken);

            var content = response.Result?.ToArray();

            return File(content!, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Отчет по транзакциям");
        }
    }
}