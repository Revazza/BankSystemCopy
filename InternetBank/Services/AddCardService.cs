using System.Globalization;
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
        card.FullName = request.FullName;
        card.CardNumber = request.CardNumber;
        card.Cvv = request.Cvv;
        card.Pin = request.Pin;
        card.AccountId = account.Id;
        card.ExpiresAt = request.ExpirationDate;
        card.CreatedAt = DateTime.UtcNow;
        await _cardRepository.RegisterCardAsync(card);
        await _cardRepository.SaveChangesAsync();
        return card;
    }
    
}