namespace BankSystem.InternetBank.Models.Requests;

public class RegisterCardRequest
{
    public string Iban { get; set; }
    public string CardNumber { get; set; }
    public string FullName { get; set; }
    public string ExpirationDate { get; set; }
    public short Cvv { get; set; }
    public short Pin { get; set; }
}