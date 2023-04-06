using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Repositores;
using BankSystem.Common.Services;
using BankSystem.InternetBank.Models;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;

namespace BankSystem.InternetBank.Services;

public interface ITransferService
{
    Task TransferMoneyAsync(TranferRequest request, Guid userId);

    Task<decimal> CalculateFeeForOuterTransferAsync(decimal amount);

  
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

    public async Task TransferMoneyAsync(TranferRequest request, Guid userId)
    {
        var sender = await _transactionRepository.FindAccountByIbanAsync(request.SendFromIban);
        if (sender.UserId != userId)
        {
            throw new Exception("Incorrect Iban");
        }
        var receiver = await _transactionRepository.FindAccountByIbanAsync(request.Iban);
        
        
        if (sender.UserId == receiver.UserId)
        {
            await InnerTransferAsync(sender, receiver, request);
        }
        else
        {
            await OuterTransferAsync(sender, receiver, request);
        }

    } 
    private async Task InnerTransferAsync(AccountEntity sender, AccountEntity receiver, TranferRequest request)
    {
        if (sender.Amount < request.Amount)
        {
            throw new InvalidOperationException("Not enough money on your bank account");
        }
        sender.Amount -= request.Amount;
        var withdrawnMoney = request.Amount;
        if (sender.Currency != receiver.Currency)
        {
           withdrawnMoney= await ConvertMoneyAsync(sender, 
           receiver, request.Amount);
        }

        receiver.Amount += withdrawnMoney;
        var transactionData = new TransactionData(sender, receiver, request,
            TransactionType.Inner, withdrawnMoney, FEE_FOR_INNER_TRANSFER);
        await CreateTransactionAsync(transactionData);
        await _transactionRepository.SaveChangesAsync();
    }

    private async Task OuterTransferAsync(AccountEntity sender, AccountEntity receiver, TranferRequest request)
    {
        decimal fee = await CalculateFeeForOuterTransferAsync(request.Amount);
        
        if (sender.Amount < request.Amount + fee)
        {
            throw new InvalidOperationException(
                $"Your account balance is {sender.Amount}, which is not enough to complete this transaction.");
        }
        
        sender.Amount = sender.Amount - fee - request.Amount;

        var withdrawnMoney = request.Amount;
        
        if (sender.Currency != receiver.Currency)
        {
            withdrawnMoney = await ConvertMoneyAsync(sender, receiver, request.Amount);
        }

        receiver.Amount += withdrawnMoney;
        var transactionData = new TransactionData(sender, receiver, request,
            TransactionType.Outer, withdrawnMoney, fee);
        await CreateTransactionAsync(transactionData);
        await _transactionRepository.SaveChangesAsync();
      
    }

    public async Task<decimal> CalculateFeeForOuterTransferAsync(decimal amount)
    {
        decimal fee = amount / 100 + 0.5m;
        return fee;
    }

    private async Task<TransactionEntity> CreateTransactionAsync(TransactionData transactionData
        )
    {
        var transaction = new TransactionEntity
        {
            TransactionType = transactionData.TransactionType,
            WithDrawnAmount = transactionData.Request.Amount,
            CurrencyFrom = transactionData.Sender.Currency,
            CurrencyTo = transactionData.Receiver.Currency,
            CreatedAt = DateTime.UtcNow,
            Fee = transactionData.Fee,
            AccountFromIban = transactionData.Sender.Iban,
            AccountToIban = transactionData.Receiver.Iban,
            ReceivedAmount = transactionData.WithdrawnMoney
        };
        await _transactionRepository.InsertTransactionAsync(transaction);
        return transaction;
    }

    private async Task<decimal> ConvertMoneyAsync(
        AccountEntity sender,
        AccountEntity receiver,
        decimal amount)
    {
        await _currencyService.CheckCurrenciesAsync();

        var convertedMoney = CurrencyConverter.Convert(
            sender.Currency,
            receiver.Currency,
            amount);

        return convertedMoney;
    }
}