using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Repositores;
using BankSystem.Common.Services;
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
        var sender = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = 1000,
            Iban = "GE51DX6331467770865217"
        };
        var receiver = new AccountEntity
        {
            UserId = sender.UserId,
            Currency = CurrencyType.GEL,
            Amount = 500, Iban = "GE05VT3774861580071408"
        };
        await _db.Accounts.AddRangeAsync(sender, receiver);
        await _db.SaveChangesAsync();
        var request = new TranferRequest
        {
            SendFromIban = sender.Iban,
            Iban = receiver.Iban,
            Amount = 500
        };
        await _transferService.TransferMoneyAsync(request, sender.UserId);
        
        var updatedSender = await _db.Accounts.FindAsync(sender.Id);
        var updatedReceiver = await _db.Accounts.FindAsync(receiver.Id);
        Assert.That(updatedSender.Amount, Is.EqualTo(500));
        Assert.That(updatedReceiver.Amount, Is.EqualTo(1000));
    }
    [Test]
    public async Task OuterTransferMoneyTestAsync()
    {
        var sender = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = 1000,
            Iban = "GE38AH7580341631433803"
        };
        var receiver = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = 500, Iban = "GE09WB5605287442587704"
        };
        await _db.Accounts.AddRangeAsync(sender, receiver);
        await _db.SaveChangesAsync();
        var request = new TranferRequest
        {
            SendFromIban = sender.Iban,
            Iban = receiver.Iban,
            Amount = 500
        };
        await _transferService.TransferMoneyAsync(request, sender.UserId);
        
        var updatedSender = await _db.Accounts.FindAsync(sender.Id);
        var updatedReceiver = await _db.Accounts.FindAsync(receiver.Id);
        Assert.That(updatedReceiver.Amount, Is.EqualTo(1000));
        Assert.That(updatedSender.Amount, Is.EqualTo(494.5));
    }
    [Test]
    public async Task OuterTransferMoneyWithDifferentCurrencyTestAsync()
    {
        var sender = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = 1000,
            Iban = "GE38AH75803416314338039"
        };
        var receiver = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.EUR,
            Amount = 10, Iban = "GE09WB5605287442587701"
        };
        await _db.Accounts.AddRangeAsync(sender, receiver);
        await _db.SaveChangesAsync();
        var request = new TranferRequest
        {
            SendFromIban = sender.Iban,
            Iban = receiver.Iban,
            Amount = 18
        };
        var senderMoney = sender.Amount - request.Amount -
                              await _transferService.CalculateFeeForOuterTransferAsync(request.Amount);
        await _currencyRepository.CheckCurrenciesAsync();
        var convertedMoney = CurrencyConverter.Convert(
            sender.Currency,
            receiver.Currency,
            request.Amount);
        var receiverMoney = receiver.Amount + convertedMoney;
                              
        
        await _transferService.TransferMoneyAsync(request, sender.UserId);
        
        var updatedSender = await _db.Accounts.FindAsync(sender.Id);
        var updatedReceiver = await _db.Accounts.FindAsync(receiver.Id);
      
        Assert.That(updatedSender.Amount, Is.EqualTo(senderMoney).Within(0.01));
        Assert.That(updatedReceiver.Amount, Is.EqualTo(receiverMoney).Within(0.1));
     

    }
}