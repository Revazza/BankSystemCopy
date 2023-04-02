using BankSystem.Atm.Models.Dto;
using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Atm.Models
{
    public class CashOutDetails
    {
        public Guid AccountId { get; set; }
        public decimal RequestedAmount { get; set; }
        public CurrencyType RequestedCurrency { get; set; }
        public decimal Fee { get; set; }
        public CurrencyType AccountCurrency { get; set; }
        public decimal TotalPayment { get; set; }
        public string UserEmail { get; set; }
        public string AccountIban { get; set; }

        public CashOutDetails(CashOutRequest request, CardEntityDto cardDto)
        {
            RequestedAmount = request.Amount;
            RequestedCurrency = request.CurrencyTo;
            AccountId = cardDto.AccountId;
            UserEmail = cardDto.AccountOwnerEmail;
            AccountCurrency = cardDto.AccountCurrency;
            AccountIban = cardDto.AccountIban;
        }

        public CashOutDetails()
        {

        }

        public override string ToString()
        {
            return
                @$"Account IBAN:{AccountIban}/" +
                $"Total cashed out amount:{Math.Round(RequestedAmount, 2)} {RequestedCurrency}/" +
                $"Fee:{Math.Round(Fee, 2)} {AccountCurrency}/" +
                $"Total payment:{Math.Round(TotalPayment, 2)} {AccountCurrency}/" +
                $"From currency:{RequestedCurrency}/" +
                $"To currency:{AccountCurrency}/";

        }

    }
}
