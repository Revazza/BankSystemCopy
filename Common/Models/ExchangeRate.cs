using BankSystem.Common.Db.Entities;

namespace BankSystem.Common.Models
{
    public class ExchangeRate
    {
        public DateTime Date { get; set; }
#nullable enable
        public List<CurrencyEntity>? Currencies { get; set; }

    }
}
