namespace BankSystem.Common.Db.Entities
{
    public enum EmailRequestStatus
    {
        NotSent,
        Failed
    }
    public class EmailRequestEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Subject { get; set; }
        public string Body { get; set; }
        // user email address
        public string ToAddress { get; set; }
        public EmailRequestStatus Status { get; set; } = EmailRequestStatus.NotSent;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
