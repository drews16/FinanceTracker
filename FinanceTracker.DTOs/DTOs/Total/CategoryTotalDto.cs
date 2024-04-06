namespace FinanceTracker.Domain.Entity
{
    public sealed record CategoryTotalDto(
        string CategoryName,
        decimal Amount
    );
}