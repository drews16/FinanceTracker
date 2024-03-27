namespace FinanceTracker.Domain.Entity
{
    public sealed class User
    {
        public int Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Login { get; init; }
        public required string Password { get; init; }
        public IEnumerable<Transaction> Transactions { get; init; } = Enumerable.Empty<Transaction>();
    }
}