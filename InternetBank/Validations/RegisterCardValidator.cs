using System.Text.RegularExpressions;
using BankSystem.InternetBank.Exceptions;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;

namespace BankSystem.InternetBank.Api.Validations;


public class RegisterCardValidator 
{
   private readonly ICardRepository _cardRepository;
    private readonly IAccountRepository _accountRepository;

    public RegisterCardValidator(ICardRepository cardRepository,
        IAccountRepository accountRepository)
    {
        _cardRepository = cardRepository;
        _accountRepository = accountRepository;
    }

    public void Validate(RegisterCardRequest? request)
    {
        Regex numberRegex = new Regex(@"^[0-9]+$");
        Regex letterRegex = new Regex(@"^[a-zA-Z\s]+$");
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrEmpty(request.Iban))
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (!_accountRepository.AccountExists(request.Iban))
        {
            throw new ArgumentException("Incorrect Iban");
        }
    }
}