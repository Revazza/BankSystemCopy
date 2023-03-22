using BankSystem.Common.Db.FinancialEnums;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Common.Db.Entities;

public class AccountEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public string? Iban { get; set; }
    [Precision(18,3)]
    public decimal Amount { get; set; }
    public CurrencyType Currency { get; set; } = CurrencyType.GEL;
    public UserEntity? UserEntity { get; set; }
    public List<CardEntity> Cards { get; set; }

    public AccountEntity()
    {
        Cards = new List<CardEntity>();
    }
}