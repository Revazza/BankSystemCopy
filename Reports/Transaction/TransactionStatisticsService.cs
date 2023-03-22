using BankSystem.Common.Db.Entities;
using BankSystem.Reports.Repositories;
using System.Globalization;

namespace BankSystem.Reports.Services.Transaction
{

    public interface ITransactionStatisticsService
    {
        Task<int> CountMonthlyTransactionsAsync(int months);
        Task<decimal> GetMonthlyProfitAsync(int months);
        Task<decimal> GetAverageProfitPerTransactionAsync();
        Task<Dictionary<string, int>> GetLastMonthTransactionsPerDayAsync();
        Task<Dictionary<string, decimal>> GetTotalATMCashOutAsync();

    }

    public class TransactionStatisticsService : ITransactionStatisticsService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionStatisticsService(
            ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<decimal> GetMonthlyProfitAsync(int months)
        {
            var monthlyTransactions = await _transactionRepository.GetMonthlyTransactionsAsync(months);

            return monthlyTransactions.Sum(t => t.Fee);
        }

        public async Task<decimal> GetAverageProfitPerTransactionAsync()
        {
            var transactions = await _transactionRepository.GetAllTransactionsAsync();

            var monthlyProfit = transactions.Sum(t => t.Fee);

            return monthlyProfit / transactions.Count;
        }

        public async Task<Dictionary<string, int>> GetLastMonthTransactionsPerDayAsync()
        {
            var transactions = await _transactionRepository.GetMonthlyTransactionsAsync(1);
            var transactionsPerDay = CalculateTransactionsPerDay(transactions);

            return transactionsPerDay;
        }

        public async Task<Dictionary<string,decimal>> GetTotalATMCashOutAsync()
        {
            var transactions = await _transactionRepository.GetAllTransactionsAsync();

            var dictionary = new Dictionary<string, decimal>();

            foreach (var transaction in transactions)
            {
                var key = transaction.CurrencyFrom.ToString();
                if(dictionary.TryGetValue(key, out _))
                {
                    dictionary[key] += transaction.Amount;
                    continue;
                }
                dictionary.Add(key,transaction.Amount);

            }

            return dictionary;
        }

        public async Task<int> CountMonthlyTransactionsAsync(int month)
        {
            var transactions = await _transactionRepository.GetMonthlyTransactionsAsync(month);
            return transactions.Count;
        }

        private Dictionary<string, int> CalculateTransactionsPerDay(
            List<TransactionEntity> transactions)
        {
            var transactionsPerDay = new Dictionary<string, int>();

            foreach (var transaction in transactions)
            {
                var formattedDate = GetMonthNameAndDay(transaction.CreatedAt);
                if (transactionsPerDay.TryGetValue(formattedDate, out _))
                {
                    transactionsPerDay[formattedDate]++;
                }
                else
                {
                    transactionsPerDay.Add(formattedDate, 1);
                }
            }

            return transactionsPerDay;
        }

        private string GetMonthNameAndDay(DateTime date)
        {
            var culture = new CultureInfo("en-US");
            return $"{date.ToString("MMMM", culture)} {date.Day}";
        }
        
    }
}
