namespace BankSystem.InternetBank.Models.Requests;

public class RegisterCardRequest
{
    public string Iban { get; set; }
    public string CardNumber { get; set; }
    public string FullName { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Cvv { get; set; }
    public string Pin { get; set; }
}