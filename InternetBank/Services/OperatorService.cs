using BankSystem.Common.Db.Entities;
using BankSystem.InternetBank.Models.Dto;

namespace BankSystem.InternetBank.Services;

public interface IOperatorService
{
    CardDto GetCardDetails(CardEntity card);
    AccountDto GetAccountDetails(AccountEntity account);
    UserDto GetUserDetails(UserEntity user);
}
public class OperatorService : IOperatorService
{
    public CardDto GetCardDetails(CardEntity card)
    {
        var cardDto = new CardDto()
        {
            CardNumber = card.CardNumber,
           
            ExpiresAt = card.ExpiresAt,
            CreatedAt = card.CreatedAt,
            FullName = card.FullName
        };
        return cardDto;
    }

    public AccountDto GetAccountDetails(AccountEntity account)
    {
        var accountDto = new AccountDto()
        {
            Amount = account.Amount,
            Iban = account.Iban,
            Currency = account.Currency
        };
        return accountDto;
    }

    public UserDto GetUserDetails(UserEntity user)
    {
        var userDto = new UserDto()
        {
            BirthDate = user.BirthDate,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PersonalNumber = user.PersonalNumber
        };
        return userDto;
    }
}