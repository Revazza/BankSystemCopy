using System.Text.Json;
using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BankSystem.InternetBank.Repositories;

public interface IUserRepository
{
    bool UserExists(string personalNumber);
    Task SaveChangesAsync();
    Task<UserEntity?> FindUserByPersonalIdAsync(string personalId);
    bool EmailAlreadyExists(string email);
    Task<Dictionary<string, decimal>> GetUserAccountsAsync(UserEntity user);

}
public class UserRepository : IUserRepository
{
    private readonly BankSystemDbContext _context;
    public UserRepository(BankSystemDbContext context
        )
    { 
        _context = context;
    }
    public bool UserExists(string personalNumber)
    {
        return _context.Users.Any(u => u.PersonalNumber == personalNumber);
    }
    public bool EmailAlreadyExists(string email)
    {
        return _context.Users.Any(u => u.Email == email);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<UserEntity?> FindUserByPersonalIdAsync(string personalId)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.PersonalNumber == personalId);
    }
    public async Task<Dictionary<string, decimal>> GetUserAccountsAsync(UserEntity user)
    {
        var accounts =  await _context.Accounts
            .Include(a => a.UserEntity)
            .Where(a => a.UserEntity == user)
            .ToListAsync();
      
        Dictionary<string, decimal> dict = new Dictionary<string, decimal> { };

        foreach (var account in accounts)
        {
            dict.Add(account.Iban, account.Amount);
        }

        return dict;
    }
   


   
}