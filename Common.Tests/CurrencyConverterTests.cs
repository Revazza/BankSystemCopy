using CommonServices.Db.Entities;
using CommonServices.Db.FinancialEnums;
using CommonServices.Services;
using NUnit.Framework;

namespace CommonServies.Tests
{
    public class CurrencyConverterTests
    {
        private List<CurrencyEntity> Currencies;

        [SetUp]
        public void SetUp()
        {
            Currencies = new List<CurrencyEntity>()
            {
                new CurrencyEntity()
                {
                    Code = "USD",
                    Rate = 2.6064m,
                },
                new CurrencyEntity()
                {
                    Code = "EUR",
                    Rate = 2.768m,
                },
            };
        }


        [TestCase(200, 200)]
        public void ConvertGELToGEL_must_return_expected_value(
            decimal expectedValue,
            decimal amount)
        {

            CurrencyConverter.UpdateExchangeRates(Currencies);

            var result = CurrencyConverter.Convert(CurrencyType.GEL, CurrencyType.GEL, amount);

            Assert.That(result, Is.EqualTo(expectedValue).Within(0.01));

        }

        [TestCase(274.38, 715)]
        [TestCase(482.43, 1257.14)]
        public void ConvertGELToUSD_must_return_expected_value(
            decimal expectedValue,
            decimal amount)
        {

            CurrencyConverter.UpdateExchangeRates(Currencies);

            var result = CurrencyConverter.Convert(CurrencyType.GEL, CurrencyType.USD, amount);

            Assert.That(result, Is.EqualTo(expectedValue).Within(0.01));

        }

        [TestCase(54.08, 150)]
        public void ConvertGELToEUR_must_return_expected_value(
            decimal expectedValue,
            decimal amount)
        {
            CurrencyConverter.UpdateExchangeRates(Currencies);

            var result = CurrencyConverter.Convert(CurrencyType.GEL, CurrencyType.EUR, amount);

            Assert.That(result, Is.EqualTo(expectedValue).Within(0.01));

        }

        [TestCase(3022.64, 3217)]
        public void ConvertUSDToEUR_must_return_expected_value(
            decimal expectedValue,
            decimal amount)
        {
            CurrencyConverter.UpdateExchangeRates(Currencies);

            var result = CurrencyConverter.Convert(CurrencyType.USD, CurrencyType.EUR, amount);

            Assert.That(result, Is.EqualTo(expectedValue).Within(0.01));

        }

        [TestCase(21255.67, 8157.00)]
        public void ConvertUSDToGEL_must_return_expected_value(
            decimal expectedValue,
            decimal amount)
        {
            CurrencyConverter.UpdateExchangeRates(Currencies);

            var result = CurrencyConverter.Convert(CurrencyType.USD, CurrencyType.GEL, amount);

            Assert.That(result, Is.EqualTo(expectedValue).Within(0.01));

        }

        [TestCase(9740.11, 3512)]
        public void ConvertEURToGEL_must_return_expected_value(
            decimal expectedValue,
            decimal amount)
        {
            CurrencyConverter.UpdateExchangeRates(Currencies);

            var result = CurrencyConverter.Convert(CurrencyType.EUR, CurrencyType.GEL, amount);

            Assert.That(result, Is.EqualTo(expectedValue).Within(0.01));

        }



    }
}
