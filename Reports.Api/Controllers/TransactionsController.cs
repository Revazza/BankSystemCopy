using Microsoft.AspNetCore.Mvc;
using BankSystem.Reports.Services;
using BankSystem.Common.Db.FinancialEnums;
using Microsoft.AspNetCore.Authorization;
using BankSystem.Common.Models;

namespace BankSystem.Reports.Controllers
{
    [Authorize("ApiOperator", AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionStatisticsService _transactionStatisticsService;

        public TransactionsController(
            ITransactionStatisticsService transactionStatisticsService)
        {
            _transactionStatisticsService = transactionStatisticsService;
        }

        [HttpGet("count-monthly-transactions")]
        public async Task<IActionResult> CountMonthlyTransactions(int months)
        {
            var countedTransactions = await _transactionStatisticsService.CountTransactionsByMonthAsync(months);
            var result = new HttpResult();
            result.Payload.Add("monthlyTransactions", countedTransactions);
            return Ok(result);

        }

        [HttpGet("calculate-profit-from-transactions")]
        public async Task<IActionResult> CalculateProfitFromTransactions(int months)
        {
            var profit = await _transactionStatisticsService.CalculateProfitByMonthAsync(months);
            var result = new HttpResult();
            result.Payload.Add("profitPerCurrency", profit);
            return Ok(result);

        }

        [HttpGet("calculate-average-profit-per-transaction")]
        public async Task<IActionResult> CalculateAverageProfitPerTransaction(CurrencyType currencyType)
        {
            var profit = await _transactionStatisticsService
                .CalculateAverageProfitPerTransactionAsync(currencyType);
            var result = new HttpResult();
            result.Payload.Add("averageProfitPerTransaction", profit);

            return Ok(result);

        }

        [HttpGet("get-last-month-transactions-per-day")]
        public async Task<IActionResult> GetTransactionsPerDay()
        {
            var transactionsPerDay = await _transactionStatisticsService
                .CalculateLastMonthTransactionsPerDayAsync();
            var result = new HttpResult();
            result.Payload.Add("transactionsPerDay", transactionsPerDay);
            return Ok(result);

        }

        [HttpGet("calculate-total-cash-out")]
        public async Task<IActionResult> CalculateTotalCashOut(CurrencyType currencyType)
        {
            var totalCashedOut = await _transactionStatisticsService
                .CalculateTotalCashOutAsync(currencyType);

            var result = new HttpResult();
            result.Payload.Add("totalCashOut", totalCashedOut);
            result.Payload.Add("currency", currencyType.ToString());
            return Ok(result);

        }

    }
}
