using System.Security.Claims;
using BankSystem.Common.Auth;
using BankSystem.Common.Db.Entities;
using BankSystem.InternetBank.Models.Requests;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.InternetBank.Services;
public interface IUserLoginService
{
    Task<string> LoginUserAsync(LoginRequest request);
}
public class UserLoginService : IUserLoginService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly TokenGenerator _tokenGenerator;

    public UserLoginService(UserManager<UserEntity> userManager, 
        TokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }
    public async Task<string> LoginUserAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new Exception("User Not Found");
        }

        var isCorrectPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!isCorrectPassword)
        {
            throw new Exception("Incorrect Email or Password");
        }

        var claims = new List<Claim>
        {
            new Claim(new ClaimsIdentityOptions().UserIdClaimType, user.Id.ToString()),
            new Claim(ClaimTypes.Role, "api-user")
        };
        string token = _tokenGenerator.Generate(claims);
        return token;
    }
}