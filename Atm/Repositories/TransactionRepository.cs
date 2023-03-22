using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Atm.Repositories;

public interface ITransactionRepository
{
    Task<List<TransactionEntity>> GetAccountsTransactionsAsync(List<AccountEntity> accounts);
    Task<List<TransactionEntity>> GetLast24HourTransactions(Guid accountId);
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

    public async Task<List<TransactionEntity>> GetLast24HourTransactions(Guid accountId)
    {
        return await _context.Transactions
            .Where(t =>
                t.AccountFromId == accountId &&
                t.CreatedAt > DateTime.Now.AddDays(-1) &&
                t.TransactionType == TransactionType.ATM)
            .ToListAsync();
    }

    public async Task<List<TransactionEntity>> GetAccountsTransactionsAsync(
        List<AccountEntity> accounts)
    {
        var accountIds = accounts.Select(a => a.Id);

        var transactions = await _context.Transactions
            .Where(t => t.TransactionType == TransactionType.ATM && accountIds.Contains(t.AccountFromId))
            .ToListAsync();

        return transactions;
    }

    public async Task AddTransactionAsync(TransactionEntity transaction)
    {
        await _context.Transactions.AddAsync(transaction);
    }


}

