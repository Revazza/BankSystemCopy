using BankSystem.Common.Db.Entities;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.InternetBank.Services;

public interface IAddUserService
{
    Task AddUserAsync(RegisterUserRequest request);
}
public class AddUserService : IAddUserService
{
    private readonly UserManager<UserEntity> _userManager;
    private IUserRepository _userRepository;

    public AddUserService(
        IUserRepository userRepository,
        UserManager<UserEntity> userManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
    }
    public async Task AddUserAsync(RegisterUserRequest request)
    {
        var user = new UserEntity();
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.BirthDate = request.BirthDate;
        user.PersonalNumber = request.PersonalNumber;
        user.Email = request.Email;
        user.UserName = request.FirstName;
        
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var error = result.Errors.First();
            throw new Exception(error.Description);
        }
        await _userRepository.SaveChangesAsync();
    }
}