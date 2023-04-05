using BankSystem.Atm.Services.Models.Requests;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Atm.Models.Dto
{
    public class CashOutDetailsDto
    {
        public Guid AccountId { get; set; }
        public decimal RequestedAmount { get; set; }
        public CurrencyType RequestedCurrency { get; set; }
        public decimal Fee { get; set; }
        public CurrencyType AccountCurrency { get; set; }
        public decimal TotalPayment { get; set; }
        public string UserEmail { get; set; }
        public string AccountIban { get; set; }


        public CashOutDetailsDto(AccountEntity account, CashOutRequest request)
        {
            RequestedAmount = request.Amount;
            RequestedCurrency = request.RequestedCurrency;
            AccountId = account.Id;
            UserEmail = account.UserEntity.Email;
            AccountCurrency = account.Currency;
            AccountIban = account.Iban;
        }

        public CashOutDetailsDto()
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
