using BankSystem.Atm.Repositories;
using BankSystem.Atm.Services;
using BankSystem.Atm.Services.Models.Requests;
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

            return Ok(token);

        }

        [HttpGet("see-balance")]
        public async Task<IActionResult> SeeBalance()
        {
            var cardId = User.Claims.First(u => u.Type == "cardId").Value;

            var card = await _cardRepository.GetCardByIdAsync(Guid.Parse(cardId));

            if (card == null)
            {
                return BadRequest("Can't identify card");
            }

            return Ok(card.Account!.Amount);

        }

        [HttpPost("change-pin")]
        public async Task<IActionResult> ChangePin(ChangePinRequest request)
        {
            request.Validate();
            var cardId = User.Claims.FirstOrDefault(c => c.Type == "cardId")!.Value;

            await _changePinService.ChangePinAsync(request, Guid.Parse(cardId));
            await _changePinService.SaveChangesAsync();

            return Ok("Pin changed");
        }

    }
}
