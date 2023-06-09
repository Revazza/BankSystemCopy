using BankSystem.Common.Db.Entities;
using BankSystem.Common.Models;
using BankSystem.InternetBank.Models.Dto;
using BankSystem.InternetBank.Repositories;

namespace BankSystem.InternetBank.Services;

public interface IUserService
{
    Task<List<TransactionDto>> GetUserTransactionsDtoAsync(string iban);
    Task<List<CardDto>> GetUserCardsAsync(Guid userId);
    Task<List<AccountDto>> GetUserAccountsAsync(UserEntity user);
    Task<List<CardDto>> GetAccountCards(string iban);
    Task<decimal> GetTotalWithdrawalAmountByIbanAsync(string iban);
    Task<decimal> GetTotalReceivedAmountByIbanAsync(string iban);

}
public class UserService : IUserService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICardRepository _cardRepository;
    private readonly IUserRepository _userRepository;

    public UserService(ITransactionRepository transactionRepository,
        ICardRepository cardRepository,
        IUserRepository userRepository)
    {
        _transactionRepository = transactionRepository;
        _cardRepository = cardRepository;
        _userRepository = userRepository;
    }
    public async Task<List<TransactionDto>> GetUserTransactionsDtoAsync(string iban)
    {
        var transactions = await _transactionRepository.GetTransactionsAsync(iban);
        var transactionList = transactions
            .Select(t => new TransactionDto()
            {
                CreatedAt = t.CreatedAt,
                Fee = t.Fee,
                SendFromIban = t.AccountFromIban,
                SendToIban = t.AccountToIban,
                Amount = t.AccountFromIban == iban ? t.WithDrawnAmount + t.Fee : t.ReceivedAmount,
                TransactionStatus = t.AccountFromIban == iban ? "Withdrawal" : "Received",
                TransactionType = t.TransactionType.ToString(),
            }).ToList();
        return transactionList;
    }

    public async Task<List<CardDto>> GetUserCardsAsync(Guid userId)
    {
        var cards = await _cardRepository.GetCardsByUserIdAsync(userId);
        var result = new HttpResult();
        var cardsList = cards
            .Select(c => new CardDto()
            {
                CardNumber = c.CardNumber,
                CreatedAt = c.CreatedAt,
                ExpiresAt = c.ExpiresAt,
                FullName = c.FullName,
                Cvv = c.Cvv,
            }).ToList();

        return cardsList;
    }

    public async Task<List<AccountDto>> GetUserAccountsAsync(UserEntity user)
    {
        var accounts = await _userRepository.GetUserAccountsAsync(user);

        var accountList = accounts
            .Select(a =>
                new AccountDto()
                {
                    Amount = a.Amount,
                    Currency = a.Currency,
                    Iban = a.Iban,
                    CurrencyValue = a.Currency.ToString()
                })
            .ToList();
        return accountList;
    }

    public async Task<List<CardDto>> GetAccountCards(string iban)
    {
        var cards = await _cardRepository.GetAccountCards(iban);
        var cardList = cards.Select(c => new CardDto()
        {
            CardNumber = c.CardNumber,
            CreatedAt = c.CreatedAt,
            ExpiresAt = c.ExpiresAt,
            FullName = c.FullName,
            Cvv = c.Cvv
        }).ToList();
        return cardList;
    }

    public async Task<decimal> GetTotalWithdrawalAmountByIbanAsync(string iban)
    {
        var transactions = await _transactionRepository
            .GetWithdrawalTransactionByIbanAsync(iban);
        var totalWithdrawal = transactions.Sum(t => t.WithDrawnAmount);
        return totalWithdrawal;
    }
    public async Task<decimal> GetTotalReceivedAmountByIbanAsync(string iban)
    {
        var transactions = await _transactionRepository.GetReceivedTransactionByIbanAsync(iban);
        var totalReceived = transactions.Sum(t => t.ReceivedAmount);
        return totalReceived;
    }

}