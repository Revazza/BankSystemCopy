using BankSystem.Atm.Repositories;
using BankSystem.Atm.Exceptions;
using BankSystem.Atm.Services.Models;
using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Repositores;
using BankSystem.Common.Services;
using Azure.Core;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BankSystem.Atm.Services
{
    public interface ICashOutService
    {
        Task<CashOutOperation> PerformCashoutAsync(CashOutRequest request, Guid cardId);
        TransactionEntity CreateTransaction(CashOutOperation cashOutOperation);
        Task AddTransactionAsync(TransactionEntity transaction);
        Task CheckCurrenciesAsync();
        Task SaveChangesAsync();
    }

    public class CashoutService : ICashOutService
    {
        private const decimal CASH_OUT_LIMIT_PER_DAY = 10_000;
        private const decimal CASH_OUT_FEE_PERCENTAGE = 0.02m;

        private readonly ITransactionRepository _transactionRepository;
        private readonly ICardRepository _cardRepository;
        private readonly ICurrencyRepository _currencyRepository;

        public CashoutService(
            ITransactionRepository transactionRepository,
            ICardRepository cardRepository,
            ICurrencyRepository currencyRepository)
        {
            _transactionRepository = transactionRepository;
            _cardRepository = cardRepository;
            _currencyRepository = currencyRepository;
        }

        private async Task<decimal> CalculateDailyCashedOutAmountAsync(
            Guid accountId)
        {
            var dailyTransactions = await _transactionRepository.GetAccountDailyTransactionsAsync(accountId);
            var dailyCashedOutAmount = dailyTransactions.Sum(t => t.Amount + t.Fee);

            return dailyCashedOutAmount;
        }

        private decimal CalculateRequestedCashOutAmount(
            CashOutRequest request,
            AccountEntity account)
        {
            //USD -> EUR
            var convertedRequestAmount = CurrencyConverter
                .Convert(request.CurrencyTo, account.Currency, request.Amount);

            var fee = convertedRequestAmount * CASH_OUT_FEE_PERCENTAGE;

            return convertedRequestAmount + fee;
        }

        private async Task<bool> IsCashOutPossibleAsync(
            CashOutRequest request,
            AccountEntity account)
        {
            var dailyCashedOutAmount = await CalculateDailyCashedOutAmountAsync(account.Id);

            var requestedCashOutAmount = CalculateRequestedCashOutAmount(request, account);

            var totalAmount = dailyCashedOutAmount + requestedCashOutAmount;

            var totalAmountInGEL = CurrencyConverter
                .Convert(account.Currency, CurrencyType.GEL, totalAmount);

            return totalAmountInGEL <= CASH_OUT_LIMIT_PER_DAY;

        }

        public async Task<CashOutOperation> PerformCashoutAsync(CashOutRequest request, Guid cardId)
        {
            var card = await _cardRepository.GetCardByIdAsync(cardId)
                ?? throw new ArgumentException("Can't identify card");

            var isCashOutPossible = await IsCashOutPossibleAsync(
                request,
                card.Account);

            if (!isCashOutPossible)
            {
                throw new CashOutLimitExceededException(CASH_OUT_LIMIT_PER_DAY);
            }

            var cashOutOperation = CashOut(request, card.Account!);

            return cashOutOperation;

        }

        public TransactionEntity CreateTransaction(CashOutOperation operation)
        {
            return new TransactionEntity
            {
                AccountFromId = operation.AccountFromId,
                Amount = operation.RequestedAmount,
                CurrencyFrom = operation.CurrencyFrom,
                CurrencyTo = operation.CurrencyTo,
                Fee = operation.Fee,
                TransactionType = TransactionType.ATM,
            };

        }

        private CashOutOperation CashOut(CashOutRequest request, AccountEntity account)
        {
            var totalCashOut = CurrencyConverter.Convert(
                request.CurrencyTo,
                account.Currency,
                request.Amount);

            var fee = totalCashOut * CASH_OUT_FEE_PERCENTAGE;

            account.Amount -= request.Amount + fee;

            return new CashOutOperation
            {
                AccountFromId = account.Id,
                AccountFromIban = account.Iban,
                CashOutAmount = totalCashOut,
                Fee = fee,
                CurrencyFrom = account.Currency,
                CurrencyTo = request.CurrencyTo,
                TotalPayment = totalCashOut + fee,
                RequestedAmount = request.Amount,
                UserEmail = account.UserEntity.Email
            };

        }

        public async Task SaveChangesAsync()
        {
            await _transactionRepository.SaveChangesAsync();
        }

        public async Task AddTransactionAsync(TransactionEntity transaction)
        {
            await _transactionRepository.AddTransactionAsync(transaction);
        }

        public async Task CheckCurrenciesAsync()
        {
            await _currencyRepository.CheckCurrenciesAsync();
        }

    }
}
