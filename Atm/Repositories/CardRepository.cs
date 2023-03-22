﻿using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Atm.Repositories;

public interface ICardRepository
{
    Task<CardEntity?> AuthorizeCardAsync(LoginRequest request);
    void UpdateCard(CardEntity card);
    Task<CardEntity?> GetCardByIdAsync(Guid cardId);
    Task SaveChangesAsync();
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
            .Include(c => c.Account)
            .FirstOrDefaultAsync(c => c.Id == cardId);
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

}
