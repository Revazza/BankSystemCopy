namespace BankSystem.InternetBank.Models.Requests;

public class RegisterCardRequest
{
    public string Iban { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
  
}