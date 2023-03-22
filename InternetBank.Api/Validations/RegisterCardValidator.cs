using BankSystem.InternetBank.Exceptions;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;

namespace BankSystem.InternetBank.Api.Validations;


public class RegisterCardValidator 
{
    private readonly ICardRepository _cardRepository;
    public RegisterCardValidator(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public void Validate(RegisterCardRequest? request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrEmpty(request.CardNumber))
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrEmpty(request.Iban))
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrEmpty(request.FullName))
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (!(request.Cvv >= 100 && request.Cvv <= 999))
        {
            throw new InvalidCvvException("Cvv must contain 3 digits");
        }

        if (!(request.Pin >= 1000 && request.Pin <= 9999))
        {
            throw new InvalidPinException("Pin must contain 4 digits");
        }

        if (_cardRepository.CardAlreadyExists(request.CardNumber))
        {
            throw new CardAlreadyExistsException($"Card with number {request.CardNumber} already exists");
        }
    }
}