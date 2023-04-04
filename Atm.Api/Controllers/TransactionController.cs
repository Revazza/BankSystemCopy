using BankSystem.Atm.Services;
using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.Common.Models;
using BankSystem.Common.Repositores;
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
            request.Validate();
            request.CurrencyTo = (CurrencyType)request.Currency;
            var cardId = User.Claims.First(u => u.Type == "cardId").Value;

            await _cashOutService.CheckCurrenciesAsync();

            var cashOutDetails = await _cashOutService.PerformCashoutAsync(request, Guid.Parse(cardId));

            var transaction = _cashOutService.CreateTransaction(cashOutDetails);

            await _cashOutService.AddTransactionAsync(transaction);

            var message = new EmailMessage
            {
                Subject = "Cash Out",
                Body = cashOutDetails.ToString(),
                Email = cashOutDetails.UserEmail
            };

            await _emailSender.AddEmailRequestAsync(message);

            await _cashOutService.SaveChangesAsync();

            var result = new HttpResult();
            result.Message = $"Operation sent to email {message.Email}";
            result.Payload.Add("details", cashOutDetails);

            return Ok(result);

        }

    }
}
