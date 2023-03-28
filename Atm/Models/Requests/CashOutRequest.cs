using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Atm.Services.Models.Requests
{
    public class CashOutRequest
    {
        public decimal Amount { get; set; }
        public CurrencyType CurrencyTo { get; set; }

        public void Validate()
        {
            if (Amount <= 0)
            {
                throw new ArgumentException("Incorrect Amount Provided");
            }

        }

    }
}
