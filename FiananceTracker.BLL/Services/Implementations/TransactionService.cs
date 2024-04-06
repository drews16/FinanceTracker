using FiananceTracker.BLL.Services.Interfaces;
using FinanceTracker.Common.Result;
using FinanceTracker.DAL.Repository.Interfaces;
using FinanceTracker.Domain.Entity;
using FinanceTracker.Domain.Enum;
using FinanceTracker.DTOs.DTOs.Total;
using FinanceTracker.DTOs.DTOs.Transaction;

namespace FiananceTracker.BLL.Services.Implementations
{
    public sealed class TransactionService(
        ITransactionRepository transactionRepository) : ITransactionService
    {
        public async Task<BaseResult> AddTransactionAsync(CreateTransactionDto dto, CancellationToken cancellationToken)
        {
            if(dto.Amount < 0)
            {
                return new BaseResult<TransactionDto>
                {
                    ErrorMessages = new List<string> { "Сумма транзакции должна быть больше 0" }
                };
            }

            if(dto.CreatedDate > DateTime.Today)
            {
                return new BaseResult<TransactionDto>
                {
                    ErrorMessages = new List<string> { "Дата транзакции не может быть больше текущей" }
                };
            }

            await transactionRepository.CreateAsync(new Transaction {
                    CategoryId = dto.CategoryId,
                    Amount = dto.Amount,
                    UserId = dto.UserId,
                    CreatedDate = dto.CreatedDate
                }, cancellationToken);

            return new BaseResult<TransactionDto>();
        }

        public async Task<BaseResult<TransactionsTotalDto>> GetTransactionTotalAsync(int userId, int month, CancellationToken cancellationToken)
        {
            var transactions = await transactionRepository
                .GetAllAsync(userId, cancellationToken);

            decimal total = transactions
                .Where(x => x.CreatedDate.Month == month && x.CreatedDate.Year == DateTime.UtcNow.Year)
                .Sum(x => x.Amount);

            var totalByMonths = transactions
                .Where(x => x.CreatedDate.Year == DateTime.UtcNow.Year)
                .GroupBy(x => x.CreatedDate.Month)
                .Select(x => new { 
                    monthName = MonthsData.Months[x.Key], 
                    amount = x.Sum(y => y.Amount)}
                )
                .ToList();

            var totalByCategories = transactions
                .Where(x => x.CreatedDate.Month == month && x.CreatedDate.Year == DateTime.UtcNow.Year)
                .GroupBy(x => x.Category?.Name)
                .Select(x => new { 
                    categoryName = x.Key,
                    amount = x.Sum(y => y.Amount) } 
                )
                .ToList();

            return new BaseResult<TransactionsTotalDto>
            {
                Result = new TransactionsTotalDto(
                    Total: total,
                    TotalByMonths: totalByMonths
                        .Select(x => new MonthTotalDto(MonthName: x.monthName, Amount: x.amount)),
                    TotalByCategories: totalByCategories
                        .Select(x => new CategoryTotalDto(CategoryName: x.categoryName!, Amount: x.amount)),
                    MonthName: MonthsData.Months[month]
                )
            };
        }

        public async Task<BaseResult<IReadOnlyCollection<TransactionDto>>> GetUserTransactionsAsync(int userId, CancellationToken cancellationToken)
        {
            var transactions = await transactionRepository
                .GetAllAsync(userId, cancellationToken);

            return new BaseResult<IReadOnlyCollection<TransactionDto>>
            {
                Result = transactions
                    .Select(x => new TransactionDto(
                        Id: x.Id,
                        CategoryName: x.Category!.Name,
                        Amount: x.Amount,
                        CreatedDate: x.CreatedDate)
                    )
                    .ToList()
            };
        }
    }
}