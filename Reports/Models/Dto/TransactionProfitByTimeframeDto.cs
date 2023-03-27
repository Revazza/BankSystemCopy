namespace BankSystem.Reports.Models.Dto
{
    public class TransactionProfitByTimeframeDto
    {
        public string? Timeframe { get; set; }
        public DateTime Date { get; set; }
        public List<TransactionProfitByCurrency> Profits { get; set; }

        public TransactionProfitByTimeframeDto()
        {
            Profits = new List<TransactionProfitByCurrency>();
        }

    }
}
