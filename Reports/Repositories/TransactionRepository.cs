using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Reports.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<TransactionEntity>> GetAllTransactionsAsync();
        Task<List<TransactionEntity>> GetLastMonthTransactionsAsync();
        Task<List<TransactionEntity>> GetTransactionsByDateAsync(DateTime date);
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

        public async Task<List<TransactionEntity>> GetLastMonthTransactionsAsync()
        {
            return await _context.Transactions
                .Where(t => t.CreatedAt >= DateTime.Now.AddMonths(-1))
                .ToListAsync();
        }

        public async Task<List<TransactionEntity>> GetTransactionsByDateAsync(DateTime date)
        {
            return await _context.Transactions
                .Where(t => t.CreatedAt >= date)
                .ToListAsync();
        }
    }
}
