namespace FinanceTracker.DAL.Repository.Interfaces
{
    public interface IExcelRepository
    {
        Task<IEnumerable<byte>> ExportTotalByCategoriesAsync(int userId, int month, CancellationToken cancellationToken);
        Task<IEnumerable<byte>> ExportTransactionsAsync(int userId, CancellationToken cancellationToken);
    }
}