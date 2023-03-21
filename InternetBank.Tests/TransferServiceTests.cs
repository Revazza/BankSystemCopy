using CommonServices.Db.Entities;
using CommonServices.Db.FinancialEnums;
using CommonServices.Repositores;
using InternetBank.Models.Requests;
using InternetBank.Services;
using Moq;

namespace InternetBank.Tests;

public class TransferServiceTests
{
    private readonly ICurrencyRepository _currencyRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransferService _transferService;

    public TransferServiceTests()
    {
        _currencyRepository = Mock.Of<ICurrencyRepository>();
        _transactionRepository = Mock.Of<ITransactionRepository>();
        _transferService = Mock.Of<ITransferService>();
    }

    [Test]
    public async Task InnerTransferMoneyTestAsync()
    {
        var transferService = new TransferService(_currencyRepository, _transactionRepository);
        var fakeDb = new FakeBankSystemDbContext();
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
        await fakeDb.Accounts.AddRangeAsync(transferor, transferee);
        await fakeDb.SaveChangesAsync();
        var request = new TranferRequest
        {
            SendFromIban = transferor.Iban,
            Iban = transferee.Iban,
            Amount = 500
        };
        await _transferService.TransferMoneyAsync(request, transferor.UserId);
        
        var updatedTransferor = await fakeDb.Accounts.FindAsync(transferor.Id);
        var updatedTransferee = await fakeDb.Accounts.FindAsync(transferee.Id);
        Assert.That(transferee.Amount, Is.EqualTo(500));
    }
}