using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Repositores;
using BankSystem.Common.Services;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;

namespace BankSystem.InternetBank.Services;

public interface ITransferService
{
    Task TransferMoneyAsync(TranferRequest request, Guid id);
    Task InnerTransferAsync(AccountEntity transferor, AccountEntity transferee, decimal amount);

    Task<decimal> ConvertMoneyAsync(
        AccountEntity transferor, AccountEntity transferee, decimal amount
    );

    Task<decimal> CalculateFeeForOuterTransferAsync(AccountEntity transferor,
        AccountEntity transferee, decimal amount);
}
public class TransferService : ITransferService
{
    private readonly ICurrencyRepository _currencyService;
    private const decimal FEE_FOR_INNER_TRANSFER = 0;
    private readonly ITransactionRepository _transactionRepository;

    public TransferService(
        ICurrencyRepository currencyService, 
        ITransactionRepository transactionRepository)
    {
        _currencyService = currencyService;
        _transactionRepository = transactionRepository;
    }

    public async Task TransferMoneyAsync(TranferRequest request, Guid id)
    {
        var transferor = await _transactionRepository.FindAccountByIbanAsync(request.SendFromIban);
        if (transferor.UserId != id)
        {
            throw new Exception("Incorrect Iban");
        }
        var transferee = await _transactionRepository.FindAccountByIbanAsync(request.Iban);

        if (transferor.UserId == transferee.UserId)
        {
            await InnerTransferAsync(transferor, transferee, request.Amount);
        }
        else
        {
            await OuterTransferAsync(transferor, transferee, request.Amount);
        }

    } 
    public async Task InnerTransferAsync(AccountEntity transferor, AccountEntity transferee, decimal amount)
    {
        if (transferor.Amount < amount)
        {
            throw new InvalidOperationException("Not enough money on your bank account");
        }
        transferor.Amount -= amount;
        if (transferor.Currency != transferee.Currency)
        {
            amount = await ConvertMoneyAsync(transferor, transferee, amount);
        }
        transferee.Amount += amount;

        await CreateTransactionAsync(transferor, transferee, amount, FEE_FOR_INNER_TRANSFER, TransactionType.Inner);
        await _transactionRepository.SaveChangesAsync();
    }

    public async Task OuterTransferAsync(AccountEntity transferor, AccountEntity transferee,
        decimal amount)
    {
        decimal fee = await CalculateFeeForOuterTransferAsync(transferor, transferee, amount);
        if (transferor.Amount < amount + fee)
        {
            throw new InvalidOperationException("Not enough money on your bank account");
        }
        transferor.Amount = transferor.Amount - fee - amount;
        if (transferor.Currency != transferee.Currency)
        {
            amount = await ConvertMoneyAsync(transferor, transferee, amount);
        }
        transferee.Amount += amount;

        await CreateTransactionAsync(transferor, transferee, amount, fee, TransactionType.Outer);
        await _transactionRepository.SaveChangesAsync();
    }

    public async Task<decimal> CalculateFeeForOuterTransferAsync(AccountEntity transferor, 
        AccountEntity transferee, decimal amount)
    {
        decimal fee = amount / 100 + 0.5m;
        return fee;
    }

    public async Task<TransactionEntity> CreateTransactionAsync(
        AccountEntity transferor, 
        AccountEntity transferee,
        decimal amount,
        decimal fee,
        TransactionType transactionType)
    {
        var transaction = new TransactionEntity();
        transaction.TransactionType = transactionType;
        transaction.Amount = amount;
        transaction.CurrencyFrom = transferor.Currency;
        transaction.CurrencyTo = transferee.Currency;
        transaction.CreatedAt = DateTime.UtcNow;
        transaction.Fee = fee;
        transaction.AccountFromId = transferor.Id;
        transaction.AccountToId = transferee.Id;
        await _transactionRepository.InsertTransactionAsync(transaction);
        return transaction;
    }

    public async Task<decimal> ConvertMoneyAsync(
        AccountEntity transferor,
        AccountEntity transferee,
        decimal amount)
    {
        await _currencyService.CheckCurrenciesAsync();

        var convertedMoney = CurrencyConverter.Convert(
            transferor.Currency,
            transferee.Currency,
            amount);

        return convertedMoney;
    }
}