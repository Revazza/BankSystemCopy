using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Atm.Models.Dto
{
    public class CardEntityDto
    {
        public Guid AccountId { get; set; }
        public string AccountOwnerEmail { get; set; }
        public CurrencyType AccountCurrency { get; set; }
        public string AccountIban { get; set; }

    }
}
