namespace FinanceTracker.DTOs.DTOs.Transaction
{
    public sealed record TransactionDto(
        int Id,
        string CategoryName,
        decimal Amount,
        DateTime CreatedDate
    );
}