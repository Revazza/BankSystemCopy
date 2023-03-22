namespace BankSystem.InternetBank.Exceptions;
    
public class InvalidPersonalNumberException : Exception
{
    public InvalidPersonalNumberException(string message)  : base(message)
    {
        
    }
}