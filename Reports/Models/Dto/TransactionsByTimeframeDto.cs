namespace BankSystem.Reports.Models.Dto
{
    public class TransactionsByTimeframeDto
    {
        public DateTime Date { get; set; }
        public string? Timeframe { get; set; }
        public int Count { get; set; }

    }

}
