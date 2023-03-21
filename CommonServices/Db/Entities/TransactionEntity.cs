using CommonServices.Db.FinancialEnums;
using Microsoft.EntityFrameworkCore;

namespace CommonServices.Db.Entities;

public class TransactionEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? AccountToId { get; set; }
    public Guid AccountFromId { get; set; }
    [Precision(18, 3)]
    public decimal Amount { get; set; } 
    public CurrencyType CurrencyFrom { get; set; }
    public CurrencyType CurrencyTo { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public TransactionType TransactionType { get; set; }
    [Precision(18, 3)]
    public decimal Fee { get; set; }
   
}