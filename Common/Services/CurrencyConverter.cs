using BankSystem.Common.Db.Dto;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;

namespace BankSystem.Common.Services
{
    public static class CurrencyConverter
    {
        private static Dictionary<(string, string), ExchangeRateDto> ExchangeRates = new();

        public static decimal Convert(
            CurrencyType from,
            CurrencyType to,
            decimal amount)
        {
            if (from == to)
            {
                return amount;
            }

            ExchangeRates!.TryGetValue(("GEL", to.ToString()), out ExchangeRateDto toExchangeRate);

            if (from == CurrencyType.GEL)
            {
                return amount / toExchangeRate.ExchangeRate * toExchangeRate.Quantity;
            }

            ExchangeRates.TryGetValue(("GEL", from.ToString()), out ExchangeRateDto fromExchangeRate);

            var amountInGEL = amount * fromExchangeRate.ExchangeRate / fromExchangeRate.Quantity;

            if (to == CurrencyType.GEL)
            {
                return amountInGEL;
            }

            return amountInGEL / toExchangeRate.ExchangeRate * toExchangeRate.Quantity;

        }

        public static bool IsEmpty()
        {
            return ExchangeRates == null || ExchangeRates.Count == 0;
        }

        public static void UpdateExchangeRates(List<CurrencyEntity> currencies)
        {
            var availableCurrencies = GetAvailableCurrencies();

            var newExchangeRates = new Dictionary<(string, string), ExchangeRateDto>();

            foreach (var currency in currencies)
            {
                if (availableCurrencies.Contains(currency.Code!))
                {
                    var exchangeRateDto = new ExchangeRateDto()
                    {
                        ExchangeRate = currency.Rate,
                        Quantity = currency.Quantity,
                    };
                    newExchangeRates.TryAdd(("GEL", currency.Code)!, exchangeRateDto);
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
