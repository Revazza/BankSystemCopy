namespace BankSystem.InternetBank.Exceptions;
    
public class InvalidPinException : Exception
{
    public InvalidPinException(string message) : base(message)
    {
        
    }
}