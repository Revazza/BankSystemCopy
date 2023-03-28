namespace BankSystem.Atm.Services.Models.Requests
{
    public class ChangePinRequest
    {
        public string OldPin { get; set; }
        public string NewPin { get; set; }

        public void Validate()
        {
            if(NewPin.Length != 4)
            {
                throw new ArgumentException("Pin must be 4 characters long");
            }

        }

    }
}
