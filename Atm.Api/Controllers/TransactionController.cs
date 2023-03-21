using ATM.Api.Repositories;
using ATM.Exceptions;
using ATM.Services;
using ATM.Services.Models;
using ATM.Services.Models.Requests;
using CommonServices.Models;
using CommonServices.Repositores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ICashOutService _cashOutService;
        private readonly IEmailRequestRepository _emailSender;

        public TransactionController(
            ICashOutService cashOutService,
            IEmailRequestRepository emailSender)
        {
            _cashOutService = cashOutService;
            _emailSender = emailSender;
        }


        [HttpPost("cash-out")]
        public async Task<IActionResult> CashOut(CashOutRequest request)
        {
            var cardId = User.Claims.First(u => u.Type == "cardId").Value;

            await _cashOutService.CheckCurrenciesAsync();

            var cashOutOperation = new CashOutOperation();

            cashOutOperation = await _cashOutService.PerformCashoutAsync(request, Guid.Parse(cardId));

            var transaction = _cashOutService.CreateTransaction(cashOutOperation);

            await _cashOutService.AddTransactionAsync(transaction);

            var message = new EmailMessage
            {
                Subject = "Cash Out",
                Body = cashOutOperation.ToString(),
                Email = cashOutOperation.UserEmail
            };

            await _emailSender.AddEmailRequestAsync(message);

            await _cashOutService.SaveChangesAsync();

            return Ok(cashOutOperation);

        }

    }
}
