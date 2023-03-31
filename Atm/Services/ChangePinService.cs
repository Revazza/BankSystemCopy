using BankSystem.Atm.Repositories;
using BankSystem.Atm.Services.Models.Requests;

namespace BankSystem.Atm.Services
{
    public interface IChangePinService
    {
        Task<string> ChangePinAsync(ChangePinRequest request, Guid cardId);
        Task SaveChangesAsync();
    }

    public class ChangePinService : IChangePinService
    {
        private readonly ICardRepository _cardRepository;

        public ChangePinService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<string> ChangePinAsync(ChangePinRequest request, Guid cardId)
        {
            var card = await _cardRepository.GetCardByIdAsync(cardId)
                ?? throw new ArgumentException("Can't Identify Card");

            if (card.Pin != request.OldPin)
            {
                throw new ArgumentException("Incorrect pin");
            }
            card.Pin = request.NewPin;

            _cardRepository.UpdateCard(card);

            return request.OldPin;
        }


        public async Task SaveChangesAsync()
        {
            await _cardRepository.SaveChangesAsync();
        }

    }
}
