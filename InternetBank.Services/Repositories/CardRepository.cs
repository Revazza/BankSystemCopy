using System.Globalization;
using CommonServices.Db;
using CommonServices.Db.Entities;

using Microsoft.EntityFrameworkCore;

namespace CommonServices.Repositores;

public interface ICardRepository
{
    Task RegisterCardAsync(CardEntity cardEntity);
    bool CardAlreadyExists(string cardNumber);
    Task<List<CardEntity>> GetCardsByUserIdAsync(Guid userId);
    Task SaveChangesAsync();
    Task<AccountEntity> GetAccountByIbanAsync(string iban);
}
public class CardRepository : ICardRepository

{
    private readonly BankSystemDbContext _context;

    public CardRepository(BankSystemDbContext context)
    {
        _context = context;
    }

    public async Task<AccountEntity> GetAccountByIbanAsync(string iban)
    {
        var account = await _context.Accounts
            .Where(a => a.Iban == iban)
            .FirstAsync();
        return account;
    }

    public bool CardAlreadyExists(string cardNumber)
    {
        return _context.Cards.Any(c => c.CardNumber == cardNumber);
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task<List<CardEntity>> GetCardsAsync(Guid userId)
    {
        var cards = await _context.Accounts
            .Where(a => a.UserId == userId)
            .SelectMany(a=>a.Cards)
            .ToListAsync();
        return cards;
    }

    public async Task RegisterCardAsync(CardEntity cardEntity)
    {
        await _context.Cards.AddAsync(cardEntity);
    }

    public async Task<List<CardEntity>> GetCardsByUserIdAsync(Guid userId)
    {
        var cards = await _context.Accounts
            .Where(u => u.UserId == userId)
            .SelectMany(a => a.Cards)
            .ToListAsync();
        return cards;
    }
}