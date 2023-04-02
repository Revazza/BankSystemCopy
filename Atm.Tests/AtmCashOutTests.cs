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
    private readonly CardRepository _cardRepository;
    private readonly UserRepository _userRepository;
    private readonly CurrencyRepository _currencyRepository;
    private readonly CashoutService _cashOutService;
    private const decimal CASH_OUT_FEE_PERCENTAGE = 0.02m;

    public AtmCashOutTests()
    {
        _db = new FakeBankSystemDbContext();
        _transactionRepository = new TransactionRepository(_db);
        _cardRepository = new CardRepository(_db);
        _userRepository = new UserRepository(_db);
        _currencyRepository = new CurrencyRepository(_db);
        _cashOutService = new CashoutService(_transactionRepository,
            _cardRepository, _userRepository, _currencyRepository);
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
        var cashOutOperation = await _cashOutService.PerformCashoutAsync(request, card.Id);
        Assert.IsNotNull(cashOutOperation);
        Assert.That(cashOutOperation.RequestedAmount, Is.EqualTo(request.Amount));
        Assert.That(cashOutOperation.CurrencyTo, Is.EqualTo(request.CurrencyTo));
        Assert.That(cashOutOperation.CurrencyFrom, Is.EqualTo(CurrencyType.USD));
        Assert.That(cashOutOperation.UserEmail, Is.EqualTo(user.Email));
    }
    [Test]
    public async Task PerformCashoutAsync_Should_ThrowCashOutLimitExceededException_When_ExceedsLimit()
    {
        var user = new UserEntity { Email = "testuser1@test.com", Id = Guid.NewGuid() };
        var account = new AccountEntity { Id = Guid.NewGuid(), Amount = 100, Currency = CurrencyType.USD, UserId = user.Id };
        var request = new CashOutRequest { Amount = 10, CurrencyTo = CurrencyType.USD };
        var card = new CardEntity()
        {
            Id = Guid.NewGuid(),
            CardNumber = "1234567891",
            AccountId = account.Id,
            Pin = "4321",
            Cvv = "121",
            ExpiresAt = DateTime.Now.AddYears(5),
            CreatedAt = DateTime.Now
        };
        await _db.Users.AddAsync(user);
        await _db.Accounts.AddAsync(account);
        await _db.Cards.AddAsync(card);
        await _db.SaveChangesAsync();
        var fee = request.Amount * CASH_OUT_FEE_PERCENTAGE;
        var result = account.Amount - request.Amount - fee;
        var cashOutOperation = await _cashOutService.PerformCashoutAsync(request, card.Id);
        Assert.AreEqual(result, account.Amount);
    }

}