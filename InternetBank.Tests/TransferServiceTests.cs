using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Repositores;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;
using BankSystem.InternetBank.Services;

namespace InternetBank.Tests;

public class TransferServiceTests
{
    private readonly ITransferService _transferService;
    private readonly ICurrencyRepository _currencyRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly FakeBankSystemDbContext _db;

    public TransferServiceTests()
    {
        _db = new FakeBankSystemDbContext();
        _currencyRepository = new CurrencyRepository(_db);
        _transactionRepository = new TransactionRepository(_db);
        _transferService = new TransferService(_currencyRepository, _transactionRepository);
    }


    [Test]
    public async Task InnerTransferMoneyTestAsync()
    {
        var transferor = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = 1000,
            Iban = "GE51DX6331467770865217"
        };
        var transferee = new AccountEntity
        {
            UserId = transferor.UserId,
            Currency = CurrencyType.GEL,
            Amount = 500, Iban = "GE05VT3774861580071408"
        };
        await _db.Accounts.AddRangeAsync(transferor, transferee);
        await _db.SaveChangesAsync();
        var request = new TranferRequest
        {
            SendFromIban = transferor.Iban,
            Iban = transferee.Iban,
            Amount = 500
        };
        await _transferService.TransferMoneyAsync(request, transferor.UserId);
        
        var updatedTransferor = await _db.Accounts.FindAsync(transferor.Id);
        var updatedTransferee = await _db.Accounts.FindAsync(transferee.Id);
        Assert.That(updatedTransferee.Amount, Is.EqualTo(1000));
        Assert.That(updatedTransferor.Amount, Is.EqualTo(500));
    }
    [Test]
    public async Task OuterTransferMoneyTestAsync()
    {
        var transferor = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = 1000,
            Iban = "GE38AH7580341631433803"
        };
        var transferee = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = 500, Iban = "GE09WB5605287442587704"
        };
        await _db.Accounts.AddRangeAsync(transferor, transferee);
        await _db.SaveChangesAsync();
        var request = new TranferRequest
        {
            SendFromIban = transferor.Iban,
            Iban = transferee.Iban,
            Amount = 500
        };
        await _transferService.TransferMoneyAsync(request, transferor.UserId);
        
        var updatedTransferor = await _db.Accounts.FindAsync(transferor.Id);
        var updatedTransferee = await _db.Accounts.FindAsync(transferee.Id);
        Assert.That(updatedTransferee.Amount, Is.EqualTo(1000));
        Assert.That(updatedTransferor.Amount, Is.EqualTo(494.5));
    }
    [Test]
    public async Task OuterTransferMoneyWithDifferentCurrencyTestAsync()
    {
        var transferor = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = 1000,
            Iban = "GE38AH75803416314338039"
        };
        var transferee = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.EUR,
            Amount = 10, Iban = "GE09WB5605287442587701"
        };
        await _db.Accounts.AddRangeAsync(transferor, transferee);
        await _db.SaveChangesAsync();
        var request = new TranferRequest
        {
            SendFromIban = transferor.Iban,
            Iban = transferee.Iban,
            Amount = 18
        };
        var transferorMoney = transferor.Amount - request.Amount -
                              await _transferService.CalculateFeeForOuterTransferAsync(transferor, transferee, request.Amount);
        var transfereeMoney = transferee.Amount +
                              await _transferService.ConvertMoneyAsync(transferor, transferee, request.Amount);
        await _transferService.TransferMoneyAsync(request, transferor.UserId);
        
        var updatedTransferor = await _db.Accounts.FindAsync(transferor.Id);
        var updatedTransferee = await _db.Accounts.FindAsync(transferee.Id);
      
        Assert.That(updatedTransferor.Amount, Is.EqualTo(transferorMoney).Within(0.01));
        Assert.That(updatedTransferee.Amount, Is.EqualTo(transfereeMoney).Within(0.1));
    }
}