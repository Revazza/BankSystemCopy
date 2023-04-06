using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.InternetBank.Repositories;


public interface ICardRepository
{
    Task RegisterCardAsync(CardEntity cardEntity);
    bool CardAlreadyExists(string cardNumber);
    Task<List<CardEntity>> GetCardsByUserIdAsync(Guid userId);
    Task SaveChangesAsync();
    Task<AccountEntity> GetAccountByIbanAsync(string iban);
    bool PinAlreadyExists(string pin);
    bool CvvAlreadyExists(string cvv);
    Task<List<CardEntity>> GetAccountCards(string iban);

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
            .Include(c=>c.UserEntity)
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
    public bool PinAlreadyExists(string pin)
    {
        return _context.Cards.Any(c => c.Pin == pin);
    }

    public bool CvvAlreadyExists(string cvv)
    {
        return _context.Cards.Any(c => c.Cvv == cvv);
    }

    public async Task<List<CardEntity>> GetAccountCards(string iban)
    {
        var cards = await _context.Accounts
            .Where(a => a.Iban == iban)
            .SelectMany(a => a.Cards)
            .ToListAsync();
        return cards;
    }
}