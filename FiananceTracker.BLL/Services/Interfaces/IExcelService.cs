using FinanceTracker.Common.Result;

namespace FiananceTracker.BLL.Services.Interfaces
{
    public interface IExcelService
    {
        Task<BaseResult<IEnumerable<byte>>> ExportTotalByCategoriesAsync(int userId, int month, CancellationToken cancellationToken);
        Task<BaseResult<IEnumerable<byte>>> ExportTransactionsAsync(int userId, CancellationToken cancellationToken);
    }
}