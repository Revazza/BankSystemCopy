using System.Globalization;
using System.Text;
using BankSystem.Common.Db.Entities;
using BankSystem.InternetBank.Api.Validations;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;

namespace BankSystem.InternetBank.Services;

public interface IAddCardService
{
    Task<CardEntity> AddCardAsync(RegisterCardRequest request);
}
public class AddCardService : IAddCardService
{
    private readonly ICardRepository _cardRepository;
    private readonly RegisterCardValidator _registerCardValidator;

    public AddCardService(ICardRepository cardRepository,
        RegisterCardValidator registerCardValidator)
    {
        _cardRepository = cardRepository;
        _registerCardValidator = registerCardValidator;
    }
    public async Task<CardEntity> AddCardAsync(RegisterCardRequest request)
    {
        _registerCardValidator.Validate(request);
        var account = await _cardRepository.GetAccountByIbanAsync(request.Iban);
        var card = new CardEntity();
        card.FullName = account.UserEntity.FirstName + account.UserEntity.LastName;
        card.CardNumber = request.CardNumber;
        card.Cvv = GenerateCvv();
        card.Pin = GeneratePin();
        card.AccountId = account.Id;
        card.ExpiresAt = request.ExpirationDate;
        card.CreatedAt = DateTime.UtcNow;
        await _cardRepository.RegisterCardAsync(card);
        await _cardRepository.SaveChangesAsync();
        return card;
    }

    private string GenerateCvv()
    {
        Random rand = new Random();
        return rand.Next(100, 1000).ToString();
    }

    private string GeneratePin()
    {
        Random rand = new Random();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 4; i++)
        {
            sb.Append(rand.Next(0, 10));
        }
        return sb.ToString();
    }
    
}