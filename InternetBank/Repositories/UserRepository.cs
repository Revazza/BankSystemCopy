using System.Security.Claims;
using CommonServices.Auth;
using CommonServices.Db;
using CommonServices.Db.Entities;
using InternetBank.Models.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CommonServices.Repositores;
public interface IUserRepository
{
    bool UserAlreadyExists(string personalNumber);
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
    public bool UserAlreadyExists(string personalNumber)
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