namespace BankSystem.Atm.Services.Models.Requests
{
    public class LoginRequest
    {
        public string? CardNumber { get; set; }
        public string Pin { get; set; }

    }
}
