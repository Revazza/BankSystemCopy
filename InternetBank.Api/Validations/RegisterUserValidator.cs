using BankSystem.InternetBank.Exceptions;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;

namespace BankSystem.InternetBank.Api.Validations;


public class RegisterUserValidator 
{
    private readonly IUserRepository _userRepositry;
    public RegisterUserValidator(IUserRepository userRepository)
    {
        _userRepositry = userRepository;
    }
    public void Validate(RegisterUserRequest? request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrEmpty(request.FirstName))
        {
            throw new ArgumentNullException(nameof(request.FirstName));
        }
        if (string.IsNullOrEmpty(request.LastName))
        {
            throw new ArgumentNullException(nameof(request.LastName));
        }
        if (string.IsNullOrEmpty(request.PersonalNumber))
        {
            throw new ArgumentNullException(nameof(request.PersonalNumber));
        }
        if (string.IsNullOrEmpty(request.Email))
        {
            throw new ArgumentNullException(nameof(request.Email));
        }
        if (string.IsNullOrEmpty(request.Password))
        {
            throw new ArgumentNullException(nameof(request.Password));
        }
        if (request.BirthDate==null|| request.BirthDate==DateTime.MinValue)
        {
            throw new ArgumentNullException(nameof(request.BirthDate));
        }

        if (request.PersonalNumber.Length !=11)
        {
            throw new InvalidPersonalNumberException("Personal Number must contain 11 digits");
        }

        if (_userRepositry.UserAlreadyExists(request.PersonalNumber))
        {
            throw new UserAlreadyExistsException("User With this PersonalId Already Exists ");
        }
        if (_userRepositry.EmailAlreadyExists(request.Email))
        {
            throw new UserAlreadyExistsException("User With this Email Already Exists ");
        }

    }
}