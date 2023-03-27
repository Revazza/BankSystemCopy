﻿using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Reports.Models;
using BankSystem.Reports.Models.Dto;
using BankSystem.Reports.Repositories;
using System.Globalization;

namespace BankSystem.Reports.Services
{

    public interface ITransactionStatisticsService
    {
        Task<TransactionsByTimeframeDto> CountTransactionsAsync(int months);
        Task<TransactionProfitByTimeframeDto> CalculateProfitAsync(int months);
        Task<decimal> CalculateAverageProfitPerTransactionAsync(CurrencyType currencyType);
        Task<List<TransactionsPerDayDto>> CalculateLastMonthTransactionsPerDayAsync();
        Task<decimal> CalculateTotalCashOutAsync(CurrencyType currencyType);
    }

    public class TransactionStatisticsService : ITransactionStatisticsService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionStatisticsService(
            ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }


        public async Task<TransactionProfitByTimeframeDto> CalculateProfitAsync(int months)
        {
            var transactions = await _transactionRepository.GetLastMonthTransactionsAsync();
            var transactionsProfit = CalculateProfitPerCurrency(transactions);

            return new TransactionProfitByTimeframeDto()
            {
                Date = DateTime.Now.AddMonths(-months),
                Timeframe = $"{months} months",
                Profits = transactionsProfit
            };

        }

        private List<TransactionProfitByCurrency> CalculateProfitPerCurrency(
            List<TransactionEntity> transactions)
        {
            var currencyTypes = CurrencyList.GetAllAvailableCurrencyTypes();
            var transactionsProfit = new List<TransactionProfitByCurrency>();

            //calculating profit for each currency type we have
            foreach (var currencyType in currencyTypes)
            {
                var profit = new TransactionProfitByCurrency()
                {
                    Profit = transactions.Sum(t => t.CurrencyFrom == currencyType ? t.Fee : 0),
                    Currency = currencyType,
                };
                transactionsProfit.Add(profit);
            }

            return transactionsProfit;

        }

        public async Task<TransactionsByTimeframeDto> CountTransactionsAsync(int months)
        {
            var transactions = await _transactionRepository.GetAllTransactionsAsync();

            var fromDate = DateTime.Now.AddMonths(-months);
            var count = 0;

            foreach (var transaction in transactions)
            {
                if (transaction.CreatedAt >= fromDate)
                {
                    count++;
                }
            }

            return new TransactionsByTimeframeDto
            {
                Timeframe = $"{months} months",
                Date = fromDate,
                Count = count
            };

        }

        public async Task<decimal> CalculateAverageProfitPerTransactionAsync(CurrencyType currencyType)
        {
            var transactions = await _transactionRepository.GetAllTransactionsAsync();
            var profit = transactions.Sum(t => t.CurrencyFrom == currencyType ? t.Fee : 0);
            return profit;
        }

        public async Task<List<TransactionsPerDayDto>> CalculateLastMonthTransactionsPerDayAsync()
        {
            var transactions = await _transactionRepository.GetLastMonthTransactionsAsync();

            var date = DateTime.Now.AddMonths(-1);
            var transactionsPerDay = CalculateTransactionsPerDay(date, transactions);

            return transactionsPerDay;
        }

        private List<TransactionsPerDayDto> CalculateTransactionsPerDay(
            DateTime date,
            List<TransactionEntity> transactions)
        {
            var transactionsPerDays = new List<TransactionsPerDayDto>();

            while (date <= DateTime.Now)
            {
                var timeframe = GetMonthNameAndDay(date);
                var count = transactions
                    .Where(t => t.CreatedAt.Date == date.Date)
                    .Count();

                var transactionsPerDay = new TransactionsPerDayDto
                {
                    Timeframe = timeframe,
                    Count = count
                };

                transactionsPerDays.Add(transactionsPerDay);

                date = date.AddDays(1);
            }
            return transactionsPerDays;
        }

        private string GetMonthNameAndDay(DateTime date)
        {
            var culture = new CultureInfo("en-US");
            return $"{date.ToString("MMMM", culture)} {date.Day}";
        }

        public async Task<decimal> CalculateTotalCashOutAsync(CurrencyType currencyType)
        {
            var transactions = await _transactionRepository.GetAllTransactionsAsync();
            return transactions.Sum(t =>
                t.TransactionType == TransactionType.ATM &&
                t.CurrencyFrom == currencyType
                ? t.Amount : 0);
        }
    }
}
