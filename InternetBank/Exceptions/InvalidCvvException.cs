namespace BankSystem.InternetBank.Exceptions;

public class InvalidCvvException : Exception
{
    public InvalidCvvException(string message) : base(message)
    {
        
    }
}