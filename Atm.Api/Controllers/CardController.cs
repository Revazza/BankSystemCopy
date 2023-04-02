using BankSystem.Atm.Repositories;
using BankSystem.Atm.Services;
using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IChangePinService _changePinService;
        private readonly ICardRepository _cardRepository;


        public CardController(
            ILoginService loginService,
            IChangePinService changePinService,
            ICardRepository cardRepository
            )
        {
            _loginService = loginService;
            _changePinService = changePinService;
            _cardRepository = cardRepository;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await _loginService.LoginAsync(request);
            var result = new HttpResult();
            result.Payload.Add("token", token);
            return Ok(result);

        }

        [HttpGet("see-balance")]
        public async Task<IActionResult> SeeBalance()
        {
            var cardId = User.Claims.First(u => u.Type == "cardId").Value;

            var card = await _cardRepository.GetCardWithAccountById(Guid.Parse(cardId));

            var result = new HttpResult();
            if (card == null)
            {
                throw new ArgumentException("Can't identify card");
            }

            result.Status = HttpResultStatus.Ok;
            result.Payload.Add("balance", card.Account.Amount);
            result.Payload.Add("currency", card.Account.Currency.ToString());
            result.Payload.Add("currencyType", card.Account.Currency);
            return Ok(result);

        }

        [HttpPost("change-pin")]
        public async Task<IActionResult> ChangePin(ChangePinRequest request)
        {
            request.Validate();
            var cardId = User.Claims.FirstOrDefault(c => c.Type == "cardId")!.Value;

            var newPin = await _changePinService.ChangePinAsync(request, Guid.Parse(cardId));
            await _changePinService.SaveChangesAsync();

            var result = new HttpResult();
            result.Payload.Add("newPin", newPin);

            return Ok(result);
        }

    }
}
