using System.Text.RegularExpressions;
using BankSystem.InternetBank.Exceptions;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;

namespace BankSystem.InternetBank.Validations;


public class RegisterUserValidator
{
    private readonly IUserRepository _userRepositry;
    public RegisterUserValidator(IUserRepository userRepository)
    {
        _userRepositry = userRepository;
    }
    public void Validate(RegisterUserRequest? request)
    {
        Regex numberRegex = new Regex(@"^[0-9]+$");
        Regex letterRegex = new Regex(@"^[a-zA-Z]+$");
        Regex emailRegex = new Regex(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$");

        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        if (string.IsNullOrEmpty(request.FirstName))
        {
            throw new ArgumentNullException(nameof(request.FirstName));
        }
        if (!letterRegex.IsMatch(request.FirstName))
        {
            throw new ArgumentException("first name must contain only letters");
        }
        if (string.IsNullOrEmpty(request.LastName))
        {
            throw new ArgumentNullException(nameof(request.LastName));
        }
        if (!letterRegex.IsMatch(request.LastName))
        {
            throw new ArgumentException("Last name must contain only letters");
        }
        if (string.IsNullOrEmpty(request.PersonalNumber))
        {
            throw new ArgumentNullException(nameof(request.PersonalNumber));
        }
        if (request.PersonalNumber.Length != 11)
        {
            throw new ArgumentException("Personal Number must contain 11 digits");
        }
        if (!numberRegex.IsMatch(request.PersonalNumber))
        {
            throw new ArgumentException("Personal Number must contain only numbers");
        }
        if (_userRepositry.UserExists(request.PersonalNumber))
        {
            throw new UserAlreadyExistsException("User With this PersonalId Already Exists ");
        }
        if (request.BirthDate == DateTime.MinValue)
        {
            throw new ArgumentNullException(nameof(request.BirthDate));
        }
        if (CalculateAge(request)<18)
        {
            throw new ArgumentException("User must be at least 18 years old");
        }
        if (string.IsNullOrEmpty(request.Email))
        {
            throw new ArgumentNullException(nameof(request.Email));
        }
        if (_userRepositry.EmailAlreadyExists(request.Email))
        {
            throw new UserAlreadyExistsException("User With this Email Already Exists ");
        }
        if (!emailRegex.IsMatch(request.Email))
        {
            throw new ArgumentException("Incorrect email format");
        }
        if (string.IsNullOrEmpty(request.Password))
        {
            throw new ArgumentNullException(nameof(request.Password));
        }
        
        
    }

    public int CalculateAge(RegisterUserRequest request)
    {
        int age = (int)((DateTime.Now - request.BirthDate).TotalDays / 365.242199);
        return age;
    }
}