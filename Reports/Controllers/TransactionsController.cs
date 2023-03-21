using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reports.Services.Transaction;

namespace Reports.Controllers
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


        [HttpGet("get-monthly-transactions")]
        public async Task<IActionResult> GetMonthlyTransactions(int months = 1)
        {
            var monthlyTransactions = await _transactionStatisticsService
                .CountMonthlyTransactionsAsync(months);
            return Ok(monthlyTransactions); 
        }

        [HttpGet("get-monthly-profit")]
        public async Task<IActionResult> GetMonthlyProfit(int months = 1)
        {
            var monthlyProfit = await _transactionStatisticsService
                .GetMonthlyProfitAsync(months);
            return Ok(monthlyProfit);
        }

        [HttpGet("get-average-profit-per-transaction")]
        public async Task<IActionResult> GetAverageProfitPerTransaction()
        {
            var averageProfitPerTransaction = await _transactionStatisticsService
                .GetAverageProfitPerTransactionAsync();
            return Ok(averageProfitPerTransaction);
        }

        [HttpGet("get-last-month-transaction-per-day")]
        public async Task<IActionResult> GetLastMonthTransactionPerDay()
        {
            var lastMonthTransactionPerDay = await _transactionStatisticsService
                .GetLastMonthTransactionsPerDayAsync();
            return Ok(lastMonthTransactionPerDay);
        }

        [HttpGet("get-total-atm-cash-out")]
        public async Task<IActionResult> GetTotalATMCashOut()
        {
            var totalATMCashOut = await _transactionStatisticsService
                .GetTotalATMCashOutAsync();
            return Ok(totalATMCashOut);
        }

    }
}
