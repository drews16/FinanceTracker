namespace FinanceTracker.Domain.Entity
{
    public sealed class Transaction
    {
        public int Id { get; init; }
        public required decimal Amount { get; init; }
        public required int CategoryId { get; init; }
        public Category? Category { get; init; }
        public required int UserId { get; init; }
        public User? User { get; init; }
         public required DateTime CreatedDate { get; init; }
    }
}