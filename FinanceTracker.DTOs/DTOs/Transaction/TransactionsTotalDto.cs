using FinanceTracker.Domain.Entity;
using FinanceTracker.DTOs.DTOs.Total;

namespace FinanceTracker.DTOs.DTOs.Transaction
{
    public sealed record TransactionsTotalDto(
        decimal Total,
        IEnumerable<MonthTotalDto> TotalByMonths,
        IEnumerable<CategoryTotalDto> TotalByCategories,
        string MonthName
    );
}
