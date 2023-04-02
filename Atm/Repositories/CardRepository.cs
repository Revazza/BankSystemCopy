using BankSystem.Atm.Models.Dto;
using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Atm.Repositories;

public interface ICardRepository
{
    void UpdateCard(CardEntity card);
    Task SaveChangesAsync();
#nullable enable
    Task<CardEntity?> GetCardByIdAsync(Guid cardId);
    Task<CardEntityDto?> GetCardDtoByIdAsync(Guid cardId);
    Task<CardEntity?> AuthorizeCardAsync(LoginRequest request);
    Task<CardEntity?> GetCardWithAccountById(Guid cardId);
}

public class CardRepository : ICardRepository
{
    private readonly BankSystemDbContext _context;

    public CardRepository(BankSystemDbContext context)
    {
        _context = context;
    }

    public async Task<CardEntity?> GetCardByIdAsync(Guid cardId)
    {
        return await _context.Cards
            .FirstOrDefaultAsync(c => c.Id == cardId);
    }

    public async Task<CardEntityDto?> GetCardDtoByIdAsync(Guid cardId)
    {
        return await _context.Cards
            .Include(c => c.Account)
                .ThenInclude(a => a.UserEntity)
            .Where(c => c.Id == cardId)
            .Select(c => new CardEntityDto
            {
                AccountId = c.Account.Id,
                AccountOwnerEmail = c.Account.UserEntity.Email,
                AccountCurrency = c.Account.Currency,
                AccountIban = c.Account.Iban,
            })
            .FirstOrDefaultAsync();
    }

    public void UpdateCard(CardEntity card)
    {
        _context.Cards.Update(card);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<CardEntity?> AuthorizeCardAsync(LoginRequest request)
    {
        return await _context.Cards
            .Include(c => c.Account)
            .FirstOrDefaultAsync(c =>
                c.CardNumber == request.CardNumber && c.Pin == request.Pin);
    }

    public async Task<CardEntity?> GetCardWithAccountById(Guid cardId)
    {
        return await _context.Cards
            .Include(c => c.Account)
            .FirstOrDefaultAsync(c => c.Id == cardId);
    }
}
