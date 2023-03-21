namespace ATM.Exceptions
{
    public class CardIsDeprecatedException : Exception
    {
        public CardIsDeprecatedException():base("Card is deprecated")
        {

        }
    }
}
