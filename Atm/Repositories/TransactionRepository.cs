using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Atm.Repositories;

public interface ITransactionRepository
{
    Task<List<TransactionEntity>> GetAccountDailyTransactionsAsync(Guid accountId);
    Task AddTransactionAsync(TransactionEntity transaction);
    Task SaveChangesAsync();
}
public class TransactionRepository : ITransactionRepository
{
    private readonly BankSystemDbContext _context;

    public TransactionRepository(BankSystemDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<TransactionEntity>> GetAccountDailyTransactionsAsync(Guid accountId)
    {
        return await _context.Transactions
            .Where(t =>
                t.AccountFromId == accountId &&
                t.CreatedAt.Date == DateTime.Now.Date &&
                t.TransactionType == TransactionType.ATM)
            .ToListAsync();
    }

    public async Task AddTransactionAsync(TransactionEntity transaction)
    {
        await _context.Transactions.AddAsync(transaction);
    }


}

