namespace FinanceTracker.Domain.Entity
{
    public sealed class Category
    {
        public int Id { get; init; }
        public required string Name { get; init; }
    }
}
