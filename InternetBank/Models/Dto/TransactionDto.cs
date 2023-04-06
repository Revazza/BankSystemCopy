using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.InternetBank.Models.Dto;

public class TransactionDto
{
  
    public string SendFromIban { get; set; }
    public string SendToIban { get; set; }
    public string TransactionType { get; set; }
    public decimal Fee { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Amount { get; set; }
    public string TransactionStatus { get; set; }
}