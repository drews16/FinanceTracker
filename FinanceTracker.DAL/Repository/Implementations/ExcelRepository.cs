using ClosedXML.Excel;
using FinanceTracker.DAL.Database;
using FinanceTracker.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Repository.Implementations
{
    public sealed class ExcelRepository(
        ApplicationDbContext context) : IExcelRepository
    {
        public async Task<IEnumerable<byte>> ExportTotalByCategoriesAsync(int userId, int month, CancellationToken cancellationToken)
        {
            var transactions = await context.Transactions
                .Where(x => 
                    x.UserId == userId && 
                    x.CreatedDate.Month == month &&
                    x.CreatedDate.Year == DateTime.UtcNow.Year)
                .GroupBy(x => x.Category!.Name)
                .Select(x => new { categoryName = x.Key, amount = x.Sum(y => y.Amount) })
                .ToListAsync(cancellationToken);

            var workbook = new XLWorkbook();

            IXLWorksheet worksheet = workbook.Worksheets.Add();

            int i = 1;

            foreach (var item in transactions)
            {
                worksheet.Cell(i, 1).Value = item.categoryName;
                worksheet.Cell(i, 2).Value = item.amount;

                i++;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);

                var content = stream.ToArray();

                return content;
            }
        }

        public async Task<IEnumerable<byte>> ExportTransactionsAsync(int userId, CancellationToken cancellationToken)
        {
            var transactions = await context.Transactions
                .Include(x => x.Category)
                .Where(x =>
                    x.UserId == userId &&
                    x.CreatedDate.Year == DateTime.UtcNow.Year)
                .ToListAsync(cancellationToken);

            var workbook = new XLWorkbook();

            IXLWorksheet worksheet = workbook.Worksheets.Add();

            int i = 2;

            worksheet.Cell(1, 1).Value = "Категория";
            worksheet.Cell(1, 2).Value = "Сумма";
            worksheet.Cell(1, 3).Value = "Дата";

            foreach (var item in transactions)
            {
                worksheet.Cell(i, 1).Value = item.Category?.Name;
                worksheet.Cell(i, 2).Value = item.Amount;
                worksheet.Cell(i, 3).Value = item.CreatedDate.ToString("d");

                i++;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);

                var content = stream.ToArray();

                return content;
            }
        }
    }
}