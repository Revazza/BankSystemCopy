using BankSystem.Atm.Repositories;
using BankSystem.Atm.Exceptions;
using BankSystem.Atm.Services.Models;
using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Repositores;
using BankSystem.Common.Services;
using BankSystem.Atm.Models;

namespace BankSystem.Atm.Services
{
    public interface ICashOutService
    {
        Task<CashOutDetails> PerformCashoutAsync(CashOutRequest request, Guid cardId);
        TransactionEntity CreateTransaction(CashOutDetails cashOutOperation);
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
        private readonly IAccountRepository _accountRepository;

        public CashoutService(
            ITransactionRepository transactionRepository,
            ICardRepository cardRepository,
            ICurrencyRepository currencyRepository,
            IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _cardRepository = cardRepository;
            _currencyRepository = currencyRepository;
            _accountRepository = accountRepository;
        }

        private async Task<decimal> CalculateDailyCashedOutAmountAsync(
            Guid accountId)
        {
            var dailyTransactions = await _transactionRepository.GetAccountDailyTransactionsAsync(accountId);
            var dailyCashedOutAmount = dailyTransactions.Sum(t => t.ReceivedAmount + t.Fee);

            return dailyCashedOutAmount;
        }

        private void CalculateTotalPayment(CashOutDetails details)
        {
            var convertedRequestAmount = CurrencyConverter
                .Convert(
                    details.RequestedCurrency,
                    details.AccountCurrency,
                    details.RequestedAmount);

            details.Fee = convertedRequestAmount * CASH_OUT_FEE_PERCENTAGE;
            details.TotalPayment = convertedRequestAmount + details.Fee;

        }

        private async Task IsCashOutPossibleAsync(CashOutDetails details)
        {
            var dailyCashedOutAmount = await CalculateDailyCashedOutAmountAsync(details.AccountId);

            CalculateTotalPayment(details);

            var totalAmount = dailyCashedOutAmount + details.TotalPayment;

            var totalAmountInGEL = CurrencyConverter
                .Convert(details.AccountCurrency, CurrencyType.GEL, totalAmount);

            if (totalAmountInGEL >= CASH_OUT_LIMIT_PER_DAY)
            {
                throw new CashOutLimitExceededException(CASH_OUT_LIMIT_PER_DAY);
            }

        }

        private async Task CashOutAsync(CashOutDetails details)
        {
            var account = await _accountRepository
                .GetAccountByIdAsync(details.AccountId);

            account.Amount -= details.TotalPayment;
            _accountRepository.UpdateAccount(account);
        }

        public async Task<CashOutDetails> PerformCashoutAsync(CashOutRequest request, Guid cardId)
        {
            var cardDto = await _cardRepository.GetCardDtoByIdAsync(cardId)
                ?? throw new ArgumentException("Couldn't identify card");

            var details = new CashOutDetails(request, cardDto);

            await IsCashOutPossibleAsync(details);

            await CashOutAsync(details);

            return details;

        }

        public TransactionEntity CreateTransaction(CashOutDetails details)
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
