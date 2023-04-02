using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.InternetBank.Models.Dto;

public class AccountDto
{
    public string Iban { get; set; }
    public decimal Amount { get; set; }
    public CurrencyType Currency { get; set; } = CurrencyType.GEL;
}