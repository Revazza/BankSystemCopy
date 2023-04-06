using BankSystem.Common.Db.Entities;

namespace BankSystem.InternetBank.Models.Dto;

public class CardDto
{
    public string CardNumber { get; set; } = new Random()
        .NextInt64(10000000000000000, 999999999999999999).ToString();
    public string FullName { get; set; }
    public DateTime ExpiresAt { get; set; } = DateTime.Now.AddYears(5);
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Cvv { get; set; }

   public string Cvv { get; set; }
}