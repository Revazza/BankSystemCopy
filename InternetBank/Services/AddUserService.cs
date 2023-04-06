using BankSystem.Common.Db.Entities;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;
using BankSystem.InternetBank.Validations;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.InternetBank.Services;

public interface IAddUserService
{
    Task<UserEntity> AddUserAsync(RegisterUserRequest request);
}

public class AddUserService : IAddUserService
{
    private readonly UserManager<UserEntity> _userManager;
    private IUserRepository _userRepository;
    private readonly RegisterUserValidator _registerUserValidator;

    public AddUserService(
        IUserRepository userRepository,
        UserManager<UserEntity> userManager,
        RegisterUserValidator registerUserValidator)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _registerUserValidator = registerUserValidator;
    }

    public async Task<UserEntity> AddUserAsync(RegisterUserRequest request)
    {
        _registerUserValidator.Validate(request);

        var user = new UserEntity();
        user.FirstName = request.FirstName.ToLower();
        user.LastName = request.LastName.ToLower();
        user.BirthDate = request.BirthDate;
        user.PersonalNumber = request.PersonalNumber;
        user.Email = request.Email;
        user.UserName = request.Email;
        var result = await _userManager.CreateAsync(user, request.Password);
        await _userManager.AddToRoleAsync(user, "api-user");
        if (!result.Succeeded)
        {
            var error = result.Errors.First();
            throw new Exception(error.Description);
        }

        await _userRepository.SaveChangesAsync();
        return user;
    }
}