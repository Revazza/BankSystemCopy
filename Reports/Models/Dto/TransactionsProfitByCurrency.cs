using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Reports.Models.Dto
{
    public class TransactionProfitByCurrency
    {
        public CurrencyType Currency { get; set; }
        public decimal Profit { get; set; }
    }
}
