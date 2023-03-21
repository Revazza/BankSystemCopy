using System.Globalization;
using CommonServices.Db.Entities;
using CommonServices.Repositores;
using InternetBank.Models.Requests;

namespace InternetBank.API.Requests;

public interface IAddCardService
{
    Task AddCardAsync(RegisterCardRequest request);
}
public class AddCardService : IAddCardService
{
    private readonly ICardRepository _cardRepository;

    public AddCardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }
    public async Task AddCardAsync(RegisterCardRequest request)
    {
        string input = request.ExpirationDate;
        string format = "MM/yy";
        DateTime.TryParseExact(input, format, null, DateTimeStyles.None, out DateTime dateTimeResult);
        var account = await _cardRepository.GetAccountByIbanAsync(request.Iban);
        var card = new CardEntity();
        card.FullName = request.FullName;
        card.CardNumber = request.CardNumber;
        card.Cvv = request.Cvv;
        card.Pin = request.Pin;
        card.AccountId = account.Id;
        card.ExpiresAt = dateTimeResult;
        card.CreatedAt = DateTime.UtcNow;
        await _cardRepository.RegisterCardAsync(card);
        await _cardRepository.SaveChangesAsync();
    }
    
}