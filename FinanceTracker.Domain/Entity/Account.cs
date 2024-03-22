namespace FinanceTracker.Domain.Entity
{
    public sealed class Account
    {
        public int Id { get; init; }
        public required int UserId { get; init; }
        public User? User { get; init; }
        public required decimal Balance { get; init; }
        public IReadOnlyCollection<Transaction> Transactions { get; init; } = Array.Empty<Transaction>();
    }
}