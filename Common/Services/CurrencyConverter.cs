using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Common.Services
{
    public static class CurrencyConverter
    {
        private static Dictionary<(string, string), decimal>? ExchangeRates = new();

        public static decimal Convert(
            CurrencyType from,
            CurrencyType to,
            decimal amount)
        {
            if (from == to)
            {
                return amount;
            }

            ExchangeRates!.TryGetValue(("GEL", to.ToString()), out decimal currencyToExchangeRate);

            if (from == CurrencyType.GEL)
            {
                return amount / currencyToExchangeRate;
            }

            ExchangeRates.TryGetValue(("GEL", from.ToString()), out decimal currencyFromExchangeRate);

            var amountInGEL = amount * currencyFromExchangeRate;

            if (to == CurrencyType.GEL)
            {
                return amountInGEL;
            }

            return amountInGEL / currencyToExchangeRate;

        }

        public static bool IsEmpty()
        {
            return ExchangeRates == null || ExchangeRates.Count == 0;
        }

        public static void UpdateExchangeRates(List<CurrencyEntity> currencies)
        {
            var availableCurrencies = GetAvailableCurrencies();

            var newExchangeRates = new Dictionary<(string, string), decimal>();

            foreach (var currency in currencies)
            {
                if (availableCurrencies.Contains(currency.Code!))
                {
                    newExchangeRates.TryAdd(("GEL", currency.Code)!, currency.Rate);
                }
            }

            ExchangeRates = newExchangeRates;

        }


        private static List<string> GetAvailableCurrencies()
        {
            return new List<string>()
            {
                "GEL",
                "EUR",
                "USD",
            };
        }

    }
}
