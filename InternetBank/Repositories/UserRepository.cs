using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.InternetBank.Repositories;

public interface IUserRepository
{
    bool UserExists(string personalNumber);
    Task SaveChangesAsync();
    Task<UserEntity?> FindUserByPersonalIdAsync(string personalId);
    bool EmailAlreadyExists(string email);
    

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
   


   
}