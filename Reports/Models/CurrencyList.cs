using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Reports.Models
{
    public class CurrencyList
    {

        public static List<CurrencyType> GetAllAvailableCurrencyTypes()
        {
            return new List<CurrencyType>() 
            {
                CurrencyType.GEL,
                CurrencyType.USD,
                CurrencyType.EUR
            };
        }

    }
}
