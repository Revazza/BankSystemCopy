using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;

using Microsoft.EntityFrameworkCore;

namespace BankSystem.InternetBank.Repositories;

public interface ITransactionRepository
{
    Task<AccountEntity> FindAccountByIbanAsync(string iban);
 
    Task SaveChangesAsync();
    Task InsertTransactionAsync(TransactionEntity transactionEntity);
    bool IbanExists(string iban);
    Task<List<TransactionEntity>> GetTransactionsAsync(string iban);
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

    public async Task InsertTransactionAsync(TransactionEntity transactionEntity)
    {
        await _context.Transactions.AddAsync(transactionEntity);
    }

    public async Task<AccountEntity> FindAccountByIbanAsync(string iban)
    {
        var transferor = await _context.Accounts
            .FirstOrDefaultAsync(a=>a.Iban==iban);
        return transferor;
    }

    public bool IbanExists(string iban)
    {
        return  _context.Accounts.Any(a => a.Iban == iban);
    }

    public async Task<List<TransactionEntity>> GetTransactionsAsync(string iban)
    {
        var account = await  _context.Accounts
            .Where(a => a.Iban == iban)
            .FirstOrDefaultAsync();
        var transactions = await _context.Transactions
            .Where(t => t.AccountFromId == account.Id
                        || t.AccountToId == account.Id)
            .ToListAsync();
        return transactions;
    }

}