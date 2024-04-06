namespace FinanceTracker.DTOs.DTOs.Transaction
{
    public sealed class CreateTransactionDto
    {
        public int UserId { get; set; }
        public required int CategoryId { get; init; }
        public required decimal Amount { get; init; }
        public required DateTime CreatedDate { get; init; }
    }
}