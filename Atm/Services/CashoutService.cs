using BankSystem.Atm.Repositories;
using BankSystem.Atm.Exceptions;
using BankSystem.Atm.Services.Models;
using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Repositores;
using BankSystem.Common.Services;

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
        private readonly IUserRepository _userRepository;
        private readonly ICurrencyRepository _currencyRepository;

        public CashoutService(
            ITransactionRepository transactionRepository,
            ICardRepository cardRepository,
            IUserRepository userRepository,
            ICurrencyRepository currencyRepository)
        {
            _transactionRepository = transactionRepository;
            _cardRepository = cardRepository;
            _userRepository = userRepository;
            _currencyRepository = currencyRepository;
        }

        private decimal CalculateCashedOutAmountInGEL(
            List<TransactionEntity> transactions)
        {
            var total = 0m;

            foreach (var transaction in transactions)
            {
                if (transaction.CurrencyFrom != CurrencyType.GEL)
                {
                    total += CurrencyConverter.Convert(
                        transaction.CurrencyFrom,
                        CurrencyType.GEL,
                        transaction.Amount);
                    continue;
                }
                total += transaction.Amount;
            }

            return total;
        }

        private async Task<bool> IsCashOutPossibleAsync(
            Guid accountId,
            decimal requestedAmount,
            CurrencyType fromCurrency)
        {
            var user = await _userRepository.GetUserByAccountIdAsync(accountId);
            var userAccounts = await _userRepository.GetUserAccountsAsync(user);
            var transactions = await _transactionRepository.GetAccountsTransactionsAsync(userAccounts);

            var cashOutInGEL = CalculateCashedOutAmountInGEL(transactions);
            var requestedAmountInGEL = CurrencyConverter.Convert(fromCurrency, CurrencyType.GEL, requestedAmount);

            var fee = requestedAmount * CASH_OUT_FEE_PERCENTAGE;
            var feeInGEL = CurrencyConverter.Convert(fromCurrency, CurrencyType.GEL, fee);

            return cashOutInGEL + requestedAmountInGEL + feeInGEL <= CASH_OUT_LIMIT_PER_DAY;
        }

        public async Task<CashOutOperation> PerformCashoutAsync(CashOutRequest request, Guid cardId)
        {
            var card = await _cardRepository.GetCardByIdAsync(cardId)
                ?? throw new ArgumentException("Can't identify card");

            var isCashOutPossible = await IsCashOutPossibleAsync(
                card.AccountId,
                request.Amount,
                card.Account!.Currency);

            if (!isCashOutPossible)
            {
                throw new CashOutLimitExceededException(CASH_OUT_LIMIT_PER_DAY);
            }

            var cashOutOperation = await CashOutAsync(request, card.Account!);

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

        private async Task<CashOutOperation> CashOutAsync(CashOutRequest request, AccountEntity account)
        {
            var fee = request.Amount * CASH_OUT_FEE_PERCENTAGE;

            var totalCashOut = CurrencyConverter.Convert(
                account.Currency,
                request.CurrencyTo,
                request.Amount);

            account.Amount -= request.Amount + fee;
            var user = await _userRepository.GetUserByAccountIdAsync(account.Id);

            return new CashOutOperation
            {
                AccountFromId = account.Id,
                AccountFromIban = account.Iban,
                CashOutAmount = totalCashOut,
                Fee = fee,
                CurrencyFrom = account.Currency,
                CurrencyTo = request.CurrencyTo,
                TotalPayment = request.Amount + fee,
                RequestedAmount = request.Amount,
                UserEmail = user.Email
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
