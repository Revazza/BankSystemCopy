using System.Text.RegularExpressions;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;

namespace BankSystem.InternetBank.Validations;

public class RegisterAccountValidator
{
    private readonly IUserRepository _userRepository;

    public RegisterAccountValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Validate(RegisterAccountRequest? request)
    {
        Regex numberRegex = new Regex(@"^[0-9]+$");
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (request.Amount < 0)
        {
            throw new ArgumentException("Amount must at least 0");
        }

        if (request.PersonalId.Length != 11)
        {
            throw new ArgumentException("Personal number must contain 11 digits");
        }
        if (!numberRegex.IsMatch(request.PersonalId))
        {
            throw new ArgumentException("Irrelevant personal id");
        }

        if (!_userRepository.UserExists(request.PersonalId))
        {
            throw new ArgumentException("Incorrect personal Id");
        }
    }
}