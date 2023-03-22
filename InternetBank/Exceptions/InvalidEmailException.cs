namespace BankSystem.InternetBank.Exceptions;

public class InvalidEmailException : Exception
{
    public InvalidEmailException(string message) : base(message)
    {
        
    }
}