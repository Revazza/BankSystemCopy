using BankSystem.Common.Db.Entities;

namespace BankSystem.InternetBank.Models;

public class TransferDetails
{
    public AccountEntity Transferor { get; set; }
    public AccountEntity Transferee { get; set; }
    public decimal Amount { get; set; }
}
