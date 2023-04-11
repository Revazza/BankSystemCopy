using BankSystem.Atm.Exceptions;
using BankSystem.Atm.Repositories;
using BankSystem.Atm.Services;
using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Repositores;
using NUnit.Framework;

namespace Atm.Tests;

public class AtmCashOutTests
{
    private readonly FakeBankSystemDbContext _db;
    private readonly TransactionRepository _transactionRepository;
    
    private readonly CurrencyRepository _currencyRepository;
    private readonly CashoutService _cashOutService;
    private readonly AccountRepository _accountRepository;
    private const decimal CASH_OUT_FEE_PERCENTAGE = 0.02m;

    public AtmCashOutTests()
    {
        _db = new FakeBankSystemDbContext();
        _transactionRepository = new TransactionRepository(_db);
    
        _currencyRepository = new CurrencyRepository(_db);
        _accountRepository = new AccountRepository(_db);
        _cashOutService = new CashoutService(_transactionRepository,
             _currencyRepository, _accountRepository);
    }

    [Test]
    public async Task TestCashOutOperation()
    {
        var user = new UserEntity { Email = "testuser@test.com", Id = Guid.NewGuid() };
        var account = new AccountEntity { Amount = 10000, Currency = CurrencyType.USD, UserId = user.Id };
        var request = new CashOutRequest { Amount = 1000, CurrencyTo = CurrencyType.GEL };

        var card = new CardEntity()
        {
            Id = Guid.NewGuid(),
            CardNumber = "123456789",
            AccountId = account.Id,
            Pin = "1234",
            Cvv = "123",
            ExpiresAt = DateTime.Now.AddYears(5),
            CreatedAt = DateTime.Now
        };
        await _db.Users.AddAsync(user);
        await _db.Accounts.AddAsync(account);
        await _db.Cards.AddAsync(card);
        await _db.SaveChangesAsync();
        var fee = request.Amount * CASH_OUT_FEE_PERCENTAGE;
        var result = account.Amount - request.Amount - fee;
       await _cashOutService.PerformCashOutAsync(request, card.Id);
       Assert.AreEqual(result, account.Amount);
       Console.WriteLine(result);
       Console.WriteLine(account.Amount);
    }
 
}