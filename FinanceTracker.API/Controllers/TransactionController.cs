using FiananceTracker.BLL.Services.Interfaces;
using FinanceTracker.Common.Extensions;
using FinanceTracker.DTOs.DTOs.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionController(
        ITransactionService transactionService) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IReadOnlyCollection<TransactionDto>>> GetUserTransactions(CancellationToken cancellationToken)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!); 

            var response = await transactionService
                .GetUserTransactionsAsync(userId, cancellationToken);

            return response.ToActionResult();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TransactionDto>> CreateTransaction(
            [FromBody] CreateTransactionDto request,
            CancellationToken cancellationToken)
        {
            request.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var response = await transactionService
                .AddTransactionAsync(request, cancellationToken);

            return response.ToActionResult();
        }

        [Authorize]
        [HttpGet("Totals")]
        public async Task<ActionResult<TransactionsTotalDto>> GetTransactionTotals(
            [FromQuery] int month,
            CancellationToken cancellationToken)
        {
            if(month == 0)
            {
                month = DateTime.UtcNow.Month;
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var response = await transactionService
                .GetTransactionTotalAsync(userId, month, cancellationToken);

            return response.ToActionResult();
        }
    }
}