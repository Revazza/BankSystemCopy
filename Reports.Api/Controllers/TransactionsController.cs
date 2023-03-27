using Microsoft.AspNetCore.Mvc;
using BankSystem.Reports.Services;
using BankSystem.Common.Db.FinancialEnums;
using Microsoft.AspNetCore.Authorization;

namespace BankSystem.Reports.Controllers
{
    [Authorize("ApiAdmin", AuthenticationSchemes = "Bearer")]
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
            var countedTransactions = await _transactionStatisticsService.CountTransactionsAsync(months);
            return Ok(countedTransactions);

        }

        [HttpGet("calculate-profit-from-transactions")]
        public async Task<IActionResult> CalculateProfitFromTransactions(int months)
        {
            var profit = await _transactionStatisticsService.CalculateProfitAsync(months);
            return Ok(profit);

        }

        [HttpGet("calculate-average-profit-per-transaction")]
        public async Task<IActionResult> CalculateAverageProfitPerTransaction(CurrencyType currencyType)
        {
            var profit = await _transactionStatisticsService
                .CalculateAverageProfitPerTransactionAsync(currencyType);
            return Ok(profit);

        }

        [HttpGet("get-last-month-transactions-per-day")]
        public async Task<IActionResult> GetTransactionsPerDay()
        {
            var transactionsPerDay = await _transactionStatisticsService
                .CalculateLastMonthTransactionsPerDayAsync();
            return Ok(transactionsPerDay);

        }

        [HttpGet("calculate-total-cash-out")]
        public async Task<IActionResult> CalculateTotalCashOut(CurrencyType currencyType)
        {
            var totalCashedOut = await _transactionStatisticsService
                .CalculateTotalCashOutAsync(currencyType);
            return Ok(totalCashedOut);

        }

    }
}
