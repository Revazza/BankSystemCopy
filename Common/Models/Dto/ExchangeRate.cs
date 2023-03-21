using CommonServices.Db.Entities;

namespace CommonServices.Models.Dto
{
    public class ExchangeRate
    {
        public DateTime Date { get; set; }
        public List<CurrencyEntity>? Currencies { get; set; }

    }
}
