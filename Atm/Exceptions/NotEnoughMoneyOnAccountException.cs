namespace BankSystem.Atm.Exceptions
{
    public class NotEnoughMoneyOnAccountException : Exception
    {
        public NotEnoughMoneyOnAccountException() : base ("Not enough money on account")
        {

        }
    }
}
