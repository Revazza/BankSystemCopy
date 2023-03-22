using BankSystem.Common.Db.Entities;

namespace BankSystem.Common.Models.Dto
{
    public class ExchangeRate
    {
        public DateTime Date { get; set; }
        public List<CurrencyEntity>? Currencies { get; set; }

    }
}
