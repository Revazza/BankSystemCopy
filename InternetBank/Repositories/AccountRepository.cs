using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.InternetBank.Repositories;

public interface IAccountRepository
{
    Task SaveChangesAsync();
    Task RegisterAccountAsync(AccountEntity account);
    Task<decimal> GetAmountByIbanAsync(string iban);
    bool AccountExists(string iban);

}
public class AccountRepository : IAccountRepository
{
    private readonly BankSystemDbContext _context;

    public AccountRepository(BankSystemDbContext context)
    {
        _context = context;
    }
    public async Task RegisterAccountAsync(AccountEntity account)
    {
        await _context.Accounts.AddAsync(account);
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task<decimal> GetAmountByIbanAsync(string iban)
    {
        var accountAmount = await _context.Accounts
            .Where(a => a.Iban == iban)
            .Select(a => a.Amount)
            .FirstOrDefaultAsync();

        return accountAmount;
    }
    public bool AccountExists(string iban)
    {
        return _context
            .Accounts
            .Any(a => a.Iban == iban);
    }



    
}