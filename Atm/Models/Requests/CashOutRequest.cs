using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Atm.Services.Models.Requests
{
    public class CashOutRequest
    {
        public decimal Amount { get; set; }
        public CurrencyType RequestedCurrency { get; set; }
        public int Currency { get; set; }

        public void Validate()
        {
            if (Amount <= 0 || Amount % 5 != 0)
            {
                throw new ArgumentException(
                    "Invalid cash out amount. " +
                    "Please enter amount that is a " +
                    "multiple of 5, except zero " +
                    "such as 5, 10, 15, etc. ");
            }

        }

    }
}
