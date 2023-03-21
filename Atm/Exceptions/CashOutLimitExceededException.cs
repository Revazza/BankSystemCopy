namespace ATM.Exceptions
{
    public class CashOutLimitExceededException : Exception
    {

        public CashOutLimitExceededException(decimal limitPerDay)
        : base($"Cashout limit is {limitPerDay} per day")
        {

        }
    }
}
