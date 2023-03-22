using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Reports.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<TransactionEntity>> GetAllTransactionsAsync();
        Task<List<TransactionEntity>> GetMonthlyTransactionsAsync(int months);
    }
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankSystemDbContext _context;

        public TransactionRepository(BankSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransactionEntity>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<TransactionEntity>> GetMonthlyTransactionsAsync(int months)
        {
            var passedMonth = CalculatePassedMonthFirstDate(months);

            var transactions = await _context.Transactions
                .Where(t => t.CreatedAt > passedMonth &&
                          t.CreatedAt < passedMonth.AddMonths(months))
                .ToListAsync();

            return transactions;
        }

        private DateTime CalculatePassedMonthFirstDate(int months)
        {
            var current = DateTime.Now.AddMonths(-months);
            var month = new DateTime(current.Year, current.Month, 1);

            return month;
        }

    }
}
