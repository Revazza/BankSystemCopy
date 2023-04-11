using BankSystem.Atm.Repositories;
using BankSystem.Atm.Exceptions;
using BankSystem.Atm.Services.Models;
using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Repositores;
using BankSystem.Common.Services;
using BankSystem.Atm.Models.Dto;

namespace BankSystem.Atm.Services
{
    public interface ICashOutService
    {
        Task<CashOutDetailsDto> PerformCashOutAsync(CashOutRequest request, Guid cardId);
        TransactionEntity CreateTransaction(CashOutDetailsDto cashOutOperation);
        Task AddTransactionAsync(TransactionEntity transaction);
        Task CheckCurrenciesAsync();
        Task SaveChangesAsync();

    }

    public class CashoutService : ICashOutService
    {
        private const decimal CASH_OUT_LIMIT_PER_DAY = 10_000;
        private const decimal CASH_OUT_FEE_PERCENTAGE = 0.02m;

        private readonly ITransactionRepository _transactionRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IAccountRepository _accountRepository;

        public CashoutService(
            ITransactionRepository transactionRepository,
            ICurrencyRepository currencyRepository,
            IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _currencyRepository = currencyRepository;
            _accountRepository = accountRepository;
        }


        private async Task<decimal> CalculateDailyCashedOutAmountAsync(
            Guid accountId)
        {
            var dailyTransactions = await _transactionRepository
                .GetAccountDailyTransactionsAsync(accountId);
            var dailyCashedOutAmount = dailyTransactions.Sum(t => t.ReceivedAmount + t.Fee);

            return dailyCashedOutAmount;
        }

        private void CashOut(AccountEntity account, decimal totalPayment)
        {
            account.Amount -= totalPayment;

            _accountRepository.UpdateAccount(account);

        }

        private async Task ValidateCashOutAsync(
            AccountEntity account,
            decimal totalPayment)
        {
            if (account.Amount < totalPayment)
            {
                throw new NotEnoughMoneyOnAccountException();
            }

            var dailyCashedOutAmount = await CalculateDailyCashedOutAmountAsync(account.Id);

            var totalAmount = dailyCashedOutAmount + totalPayment;

            var totalAmountInGEL = CurrencyConverter
                .Convert(account.Currency, CurrencyType.GEL, totalAmount);

            if (totalAmountInGEL >= CASH_OUT_LIMIT_PER_DAY)
            {
                throw new CashOutLimitExceededException(CASH_OUT_LIMIT_PER_DAY);
            }

        }

        public async Task<CashOutDetailsDto> PerformCashOutAsync(CashOutRequest request, Guid cardId)
        {
            var account = await _accountRepository
                .GetAccountByCardIdAsync(cardId)
                ?? throw new ArgumentException("Can't find related account for the card");

            var convertedRequestAmount = CurrencyConverter.Convert(
                request.RequestedCurrency,
                account.Currency,
                request.Amount);

            var fee = convertedRequestAmount * CASH_OUT_FEE_PERCENTAGE;
            var totalPayment = convertedRequestAmount + fee;

            await ValidateCashOutAsync(account, totalPayment);

            CashOut(account, totalPayment);

            return new CashOutDetailsDto(account, request)
            {
                Fee = fee,
                TotalPayment = totalPayment,
            };

        }

        public TransactionEntity CreateTransaction(CashOutDetailsDto details)
        {
            return new TransactionEntity
            {
                AccountFromId = details.AccountId,
                AccountFromIban = details.AccountIban,
                ReceivedAmount = details.RequestedAmount,
                WithDrawnAmount = details.TotalPayment,
                CurrencyFrom = details.AccountCurrency,
                CurrencyTo = details.RequestedCurrency,
                Fee = details.Fee,
                TransactionType = TransactionType.ATM,
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
