using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Atm.Repositories;

public interface IUserRepository
{
    Task<List<AccountEntity>> GetUserAccountsAsync(UserEntity user);
    Task<UserEntity> GetUserByAccountIdAsync(Guid accountId);
}
public class UserRepository : IUserRepository
{
    private readonly BankSystemDbContext _context;

    public UserRepository(BankSystemDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity> GetUserByAccountIdAsync(Guid accountId)
    {
        return await _context.Users
            .Include(a => a.Accounts)
            .FirstAsync(a => a.Accounts.Any(d => d.Id == accountId));
    }

    public async Task<List<AccountEntity>> GetUserAccountsAsync(UserEntity user)
    {
        return await _context.Accounts
            .Include(a => a.UserEntity)
            .Where(a => a.UserEntity == user)
            .ToListAsync();
    }

}
