using FiananceTracker.BLL.Services.Interfaces;
using FinanceTracker.Common.Result;
using FinanceTracker.DAL.Repository.Interfaces;

namespace FiananceTracker.BLL.Services.Implementations
{
    public sealed class ExcelService(
        IExcelRepository excelRepository) : IExcelService
    {
        public async Task<BaseResult<IEnumerable<byte>>> ExportTotalByCategoriesAsync(int userId, int month, CancellationToken cancellationToken)
        {
            var content = await excelRepository
                .ExportTotalByCategoriesAsync(userId, month, cancellationToken);

            return new BaseResult<IEnumerable<byte>>
            {
                Result = content
            };
        }

        public async Task<BaseResult<IEnumerable<byte>>> ExportTransactionsAsync(int userId, CancellationToken cancellationToken)
        {
            var content = await excelRepository
                .ExportTransactionsAsync(userId, cancellationToken);

            return new BaseResult<IEnumerable<byte>>
            {
                Result = content
            };
        }
    }
}