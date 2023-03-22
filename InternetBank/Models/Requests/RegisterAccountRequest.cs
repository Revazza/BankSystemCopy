using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.InternetBank.Models.Requests;

public class RegisterAccountRequest
{
    public decimal Amount { get; set; }
    public CurrencyType Currency { get; set; }
    public string PersonalId { get; set; }
}