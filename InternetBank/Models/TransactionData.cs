using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using BankSystem.InternetBank.Models.Requests;

namespace BankSystem.InternetBank.Models;

public class TransactionData
{
    public AccountEntity Sender { get; set; }
    public AccountEntity Receiver { get; set; }
    public TranferRequest Request { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal WithdrawnMoney { get; set; }
    public decimal Fee { get; set; }

    public TransactionData(AccountEntity sender, AccountEntity receiver, TranferRequest request,
        TransactionType transactionType, decimal withdrawnMoney, decimal fee)
    {
        Sender = sender;
        Receiver = receiver;
        Request = request;
        TransactionType = transactionType;
        WithdrawnMoney = withdrawnMoney;
        Fee = fee;
    }
}