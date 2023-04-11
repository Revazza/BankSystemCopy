using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Repositores;
using BankSystem.Common.Services;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;
using BankSystem.InternetBank.Services;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace InternetBank.Tests;

public class TransferServiceTests
{
    private readonly ITransferService _transferService;
    private readonly ICurrencyRepository _currencyRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly FakeBankSystemDbContext _db;
    private readonly IbanService _ibanService;

    public TransferServiceTests()
    {
        _db = new FakeBankSystemDbContext();
        _currencyRepository = new CurrencyRepository(_db);
        _transactionRepository = new TransactionRepository(_db);
        _transferService = new TransferService(_currencyRepository, _transactionRepository);
        _ibanService = new IbanService();

    }
    [TestCase(1000, 500, 500)]
    [TestCase(20, 10, 5)]
    [TestCase(55, 3, 1)]
    [TestCase(5000, 54, 777)]
    [TestCase(100, 56, 55)]
    //[TestCase(600, 43.3, 5)]
   // [TestCase(600.56,55.55, 6.45)]
   // [TestCase(500.456, 43, 67)]
    //[TestCase(54, 60, 1.2)]
    //[TestCase(678, 60.56, 6.7)]
    public async Task InnerTransferMoneyTestAsync(decimal senderAmount, 
        decimal receiverAmount, decimal requestedAmount)
    {
        var sender = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = senderAmount,
            Iban = _ibanService.GenerateIBan()
        };
        var receiver = new AccountEntity
        {
            UserId = sender.UserId,
            Currency = CurrencyType.GEL,
            Amount = receiverAmount, Iban = _ibanService.GenerateIBan()
        };
        await _db.Accounts.AddRangeAsync(sender, receiver);
        await _db.SaveChangesAsync();
        var request = new TranferRequest
        {
            SendFromIban = sender.Iban,
            Iban = receiver.Iban,
            Amount = requestedAmount
        };
        var AccountFromAmount =  sender.Amount - requestedAmount;
        var AccountToAmount = receiver.Amount + requestedAmount;
        await _transferService.TransferMoneyAsync(request, sender.UserId);
        
        var updatedSender = await _db.Accounts.FindAsync(sender.Id);
        var updatedReceiver = await _db.Accounts.FindAsync(receiver.Id);
        Assert.That(updatedSender.Amount, Is.EqualTo(AccountFromAmount));
        Assert.That(updatedReceiver.Amount, Is.EqualTo(AccountToAmount));
    }
    [TestCase(1000, 500, 500)]
    [TestCase(20, 10, 5)]
    [TestCase(55, 3, 1)]
    [TestCase(5000, 54, 777)]
    [TestCase(100, 56, 55)]
    //[TestCase(600, 43.3, 5)]
    //[TestCase(600.56,55.55, 6.45)]
    //[TestCase(500.456, 43, 67)]
    //[TestCase(54, 60, 1.2)]
    //[TestCase(678, 60.56, 6.7)]
    public async Task OuterTransferMoneyTestAsync(decimal senderAmount, 
        decimal receiverAmount, decimal requestedAmount)
    {
        var sender = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = senderAmount,
            Iban = _ibanService.GenerateIBan()
        };
        var receiver = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = receiverAmount, Iban = _ibanService.GenerateIBan()
        };
        await _db.Accounts.AddRangeAsync(sender, receiver);
        await _db.SaveChangesAsync();
        var request = new TranferRequest
        {
            SendFromIban = sender.Iban,
            Iban = receiver.Iban,
            Amount = requestedAmount
        };
        decimal fee = requestedAmount / 100 + 0.5m;
       
        var AccountFromAmount =  sender.Amount - requestedAmount- fee;
        var AccountToAmount = receiver.Amount + requestedAmount;
        await _transferService.TransferMoneyAsync(request, sender.UserId);
        
        var updatedSender = await _db.Accounts.FindAsync(sender.Id);
        var updatedReceiver = await _db.Accounts.FindAsync(receiver.Id);
        Assert.That(updatedReceiver.Amount, Is.EqualTo(AccountToAmount));
        Assert.That(updatedSender.Amount, Is.EqualTo(AccountFromAmount));
    }
    [TestCase(1000, 500, 500)]
    [TestCase(20, 10, 5)]
    [TestCase(55, 3, 1)]
    [TestCase(5000, 54, 777)]
    [TestCase(100, 56, 55)]
    //[TestCase(600, 43.3, 5)]
    //[TestCase(600.56,55.55, 6.45)]
    //[TestCase(500.456, 43, 67)]
    //[TestCase(54, 60, 1.2)]
    //[TestCase(678, 60.56, 6.7)]
    public async Task OuterTransferMoneyWithDifferentCurrencyTestAsync(decimal senderAmount, 
        decimal receiverAmount, decimal requestedAmount)
    {
        var sender = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.GEL,
            Amount = senderAmount,
            Iban = _ibanService.GenerateIBan()
        };
        var receiver = new AccountEntity
        {
            UserId = Guid.NewGuid(),
            Currency = CurrencyType.EUR,
            Amount = receiverAmount, Iban = _ibanService.GenerateIBan()
        };
        await _db.Accounts.AddRangeAsync(sender, receiver);
        await _db.SaveChangesAsync();
        var request = new TranferRequest
        {
            SendFromIban = sender.Iban,
            Iban = receiver.Iban,
            Amount = requestedAmount
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