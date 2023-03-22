namespace BankSystem.InternetBank.Models.Requests;

public class TranferRequest
{
    public string SendFromIban { get; set; }
    public string Iban { get; set; }
    public decimal Amount { get; set; }
}