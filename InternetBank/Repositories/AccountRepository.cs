using CommonServices.Db;
using CommonServices.Db.Entities;
using IbanNet;
using Microsoft.EntityFrameworkCore;

namespace CommonServices.Repositores;

public interface IAccountRepository
{
    Task SaveChangesAsync();
    Task RegisterAccountAsync(AccountEntity account);
    Task<decimal> GetAmountByIbanAsync(string iban);
  
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


    
}