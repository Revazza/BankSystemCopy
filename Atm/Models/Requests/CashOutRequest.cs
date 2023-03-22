using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Atm.Services.Models.Requests
{
    public class CashOutRequest
    {
        public decimal Amount { get; set; }
        public CurrencyType CurrencyTo { get; set; }
    }
}
