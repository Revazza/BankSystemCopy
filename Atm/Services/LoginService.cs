using BankSystem.Atm.Repositories;
using BankSystem.Atm.Exceptions;
using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Auth;
using System.Security.Claims;

namespace BankSystem.Atm.Services
{
    public interface ILoginService
    {
        Task<string> LoginAsync(LoginRequest request);
    }
    public class LoginService : ILoginService
    {
        private readonly ICardRepository _cardRepository;
        private readonly TokenGenerator _tokenGenerator;

        public LoginService(
            ICardRepository cardRepository,
            TokenGenerator tokenGenerator)
        {
            _cardRepository = cardRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<string> LoginAsync(LoginRequest request)
        {
            var card = await _cardRepository
                .AuthorizeCardAsync(request)
                ?? throw new ArgumentException("Can't identify card");

            if (DateTime.Now > card.ExpiresAt)
            {
                throw new CardIsDeprecatedException();
            }

            var claims = new List<Claim>()
            {
                new Claim("cardNumber",card.CardNumber!),
                new Claim("cardId",card.Id.ToString())
            };

            var token = _tokenGenerator.Generate(claims);

            return token;
        }
    }
}
