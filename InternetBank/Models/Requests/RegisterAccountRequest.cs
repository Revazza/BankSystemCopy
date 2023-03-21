using CommonServices.Db.Entities;
using CommonServices.Db.FinancialEnums;

namespace InternetBank.Models.Requests;

public class RegisterAccountRequest
{
    public decimal Amount { get; set; }
    public CurrencyType Currency { get; set; }
    public string PersonalId { get; set; }
}