using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.InternetBank.Models.Requests;
namespace BankSystem.InternetBank.Models;

public class TransferDetails
{
 
    public decimal WithDrawnAmount { get; set; }
    public decimal RequestedAmount { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Fee { get; set; }
    public AccountEntity Transferor { get; set; }
    public AccountEntity Transferee { get; set; }
    public TransferDetails(TranferRequest request, AccountEntity transferor,
    AccountEntity transferee)
    {
        RequestedAmount = request.Amount;
       
        Transferor = transferor;
        Transferee = transferee;
    }
}
