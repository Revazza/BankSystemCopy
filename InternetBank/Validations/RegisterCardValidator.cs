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

        if (string.IsNullOrEmpty(request.CardNumber))
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (!numberRegex.IsMatch(request.CardNumber))
        {
            throw new ArgumentException("Card Number must contain only digits");
        }
        if (request.CardNumber.Length != 16)
        {
            throw new ArgumentException("Card Number must contain 16 digits");
        }

        if (string.IsNullOrEmpty(request.Iban))
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (!_accountRepository.AccountExists(request.Iban))
        {
            throw new ArgumentException("Incorrect Iban");
        }

       
        if (request.ExpirationDate < DateTime.Now.AddYears(5))
        {
            throw new ArgumentException("Incorrect Expiration date");
        }
        if (_cardRepository.CardAlreadyExists(request.CardNumber))
        {
            throw new CardAlreadyExistsException($"Card with number {request.CardNumber} already exists");
        }
    }
}