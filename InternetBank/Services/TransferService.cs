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
  
    Task<decimal> CalculateFeeForOuterTransferAsync();

    Task<decimal> ConvertMoneyAsync(
       
        );
}
public class TransferService : ITransferService
{
    private readonly ICurrencyRepository _currencyService;
    private const decimal FEE_FOR_INNER_TRANSFER = 0;
    private readonly ITransactionRepository _transactionRepository;
    
    private AccountEntity transferor;
    private AccountEntity transferee;
    private decimal requestedAmount;
    public TransferService(
        ICurrencyRepository currencyService, 
        ITransactionRepository transactionRepository)
    {
        _currencyService = currencyService;
        _transactionRepository = transactionRepository;
    }

    public async Task TransferMoneyAsync(TranferRequest request, Guid userId)
    {
        transferor = await _transactionRepository.FindAccountByIbanAsync(request.SendFromIban);
        if (transferor.UserId != userId)
        {
            throw new Exception("Incorrect Iban");
        }
         transferee = await _transactionRepository.FindAccountByIbanAsync(request.Iban);
         requestedAmount = request.Amount;
        if (transferor.UserId == transferee.UserId)
        {
            await PerformInnerTransferAsync();
        }
        else
        {
            await PerformOuterTransferAsync();
        }

    } 
    private async Task PerformInnerTransferAsync()
    {
        if (transferor.Amount < requestedAmount)
        {
            throw new InvalidOperationException("Not enough money on your bank account");
        }
        transferor.Amount -= requestedAmount;
        decimal amount = 0;
        if (transferor.Currency != transferee.Currency)
        {
            amount = await ConvertMoneyAsync();
        }
        transferee.Amount += amount;

       await CreateTransactionAsync( FEE_FOR_INNER_TRANSFER, TransactionType.Inner);
        await _transactionRepository.SaveChangesAsync();
    }

    private async Task PerformOuterTransferAsync()
    {
        decimal fee = await CalculateFeeForOuterTransferAsync();
        if (transferor.Amount < requestedAmount + fee)
        {
            throw new InvalidOperationException("Not enough money on your bank account");
        }
        transferor.Amount = transferor.Amount - fee - requestedAmount;
        var amount = requestedAmount;
        if (transferor.Currency != transferee.Currency)
        {
            amount = await ConvertMoneyAsync();
        }
        transferee.Amount += amount;
        await CreateTransactionAsync( fee, TransactionType.Outer);
        await _transactionRepository.SaveChangesAsync();
      
    }

    public async Task<decimal> CalculateFeeForOuterTransferAsync()
    {
        decimal fee = requestedAmount / 100 + 0.5m;
        return fee;
    }

    private async Task<TransactionEntity> CreateTransactionAsync(
        
        decimal fee,
        TransactionType transactionType,
        decimal? withdrawnAmount=null)
    {
        var transaction = new TransactionEntity();
        transaction.TransactionType = transactionType;
        transaction.Amount = requestedAmount;
        transaction.CurrencyFrom = transferor.Currency;
        transaction.CurrencyTo = transferee.Currency;
        transaction.CreatedAt = DateTime.UtcNow;
        transaction.Fee = fee;
        transaction.AccountFromIban = transferor.Iban;
        transaction.AccountToIban = transferee.Iban;
        await _transactionRepository.InsertTransactionAsync(transaction);
        return transaction;
    }

    public async Task<decimal> ConvertMoneyAsync()
    {
        await _currencyService.CheckCurrenciesAsync();

        var convertedMoney = CurrencyConverter.Convert(
            transferor.Currency,
            transferee.Currency,
            requestedAmount);

        return convertedMoney;
    }
}