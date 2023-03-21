using CommonServices.Db.Entities;
using CommonServices.Repositores;
using InternetBank.Exceptions;
using InternetBank.Models.Requests;
using Microsoft.AspNetCore.Identity;

namespace InternetBank.Services;

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