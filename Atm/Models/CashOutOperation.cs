using CommonServices.Db.FinancialEnums;

namespace ATM.Services.Models
{
    public class CashOutOperation
    {
        public Guid AccountFromId { get; set; }
        public string? AccountFromIban { get; set; }
        public decimal CashOutAmount { get; set; }
        public decimal Fee { get; set; }
        public CurrencyType CurrencyFrom { get; set; }
        public CurrencyType CurrencyTo { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal TotalPayment { get; set; }
        public string? UserEmail { get; set; }

        public override string? ToString()
        {
            return
                @$"Card IBAN:{AccountFromIban}/"+
                $"Amount requested:{Math.Round(RequestedAmount, 2)} {CurrencyFrom}/" +
                $"Total cashed out amount:{Math.Round(CashOutAmount, 2)} {CurrencyTo}/" +
                $"Fee:{Math.Round(Fee, 2)} {CurrencyFrom}/" +
                $"Total payment:{Math.Round(TotalPayment, 2)} {CurrencyFrom}/" +
                $"From currency:{CurrencyFrom}/" +
                $"To currency:{CurrencyTo}/";

        }
    }
}
