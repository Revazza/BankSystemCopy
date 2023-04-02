using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.InternetBank.Models.Dto;

public class TransactionDto
{
    public decimal RequestedAmount { get; set; }
    public string SendFromIban { get; set; }
    public string SendToIban { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal fee { get; set; }
    public DateTime CreatedAt { get; set; }
}