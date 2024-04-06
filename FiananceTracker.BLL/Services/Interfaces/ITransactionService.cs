using FinanceTracker.Common.Result;
using FinanceTracker.DTOs.DTOs.Transaction;

namespace FiananceTracker.BLL.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<BaseResult<IReadOnlyCollection<TransactionDto>>> GetUserTransactionsAsync(int userId, CancellationToken cancellationToken);
        Task<BaseResult> AddTransactionAsync(CreateTransactionDto dto, CancellationToken cancellationToken);
        Task<BaseResult<TransactionsTotalDto>> GetTransactionTotalAsync(int userId, int month, CancellationToken cancellationToken);
    }
}