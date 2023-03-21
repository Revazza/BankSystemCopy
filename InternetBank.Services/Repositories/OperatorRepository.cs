using System.Security.Claims;
using CommonServices.Auth;
using CommonServices.Db;
using CommonServices.Db.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CommonServices.Repositores;
public interface IOperatorRepository
{
    Task<string> OperatorLoginAsync(string name);
}
public class OperatorRepository : IOperatorRepository
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly TokenGenerator _tokenGenerator;
    private readonly BankSystemDbContext _context;

    public OperatorRepository(
        UserManager<UserEntity> userManager, TokenGenerator tokenGenerator, BankSystemDbContext context)
    {
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
        _context = context;
    }

    public async Task<string> OperatorLoginAsync(string name)
    {
        var admin = await _context.Operators.Where(o => o.Name == name).FirstAsync();
        if (admin == null)
        {
            throw new Exception("admin Not Found");
        }
        var claims = new List<Claim>
        {
            new Claim(new ClaimsIdentityOptions().UserIdClaimType, admin.Id.ToString()),
            new Claim(ClaimTypes.Role, "api-admin")
        };
        string token = _tokenGenerator.Generate(claims);
        return token;
    }

 
}