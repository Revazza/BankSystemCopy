namespace InternetBank.Exceptions;

public class CardAlreadyExistsException : Exception
{
    public CardAlreadyExistsException(string message) : base(message)
    {
        
    }
}