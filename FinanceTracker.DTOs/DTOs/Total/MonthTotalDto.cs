namespace FinanceTracker.DTOs.DTOs.Total
{
    public sealed record MonthTotalDto(
        string MonthName,
        decimal Amount,
        int MonthNumber
    );
}
