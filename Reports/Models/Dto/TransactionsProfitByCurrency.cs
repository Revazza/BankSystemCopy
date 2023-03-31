using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Reports.Models.Dto
{
    public class TransactionProfitByCurrency
    {
        public string Currency { get; set; }
        public decimal Profit { get; set; }
        public CurrencyType CurrencyType { get; set; }
    }
}
