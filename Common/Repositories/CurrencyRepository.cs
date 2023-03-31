using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db;
using BankSystem.Common.Services;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using BankSystem.Common.Models;

namespace BankSystem.Common.Repositores
{
    public interface ICurrencyRepository
    {
        Task CheckCurrenciesAsync();
        Task SaveChangesAsync();
    }

    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly BankSystemDbContext _context;

        public CurrencyRepository(BankSystemDbContext context)
        {
            _context = context;
        }

        public async Task CheckCurrenciesAsync()
        {
            var currencies = await _context.Currencies.ToListAsync();

            var updatedCurrencies = await UpdateCurrenciesAsync(currencies);

            if (updatedCurrencies != null)
            {
                CurrencyConverter.UpdateExchangeRates(updatedCurrencies!);
            }
            else if(CurrencyConverter.IsEmpty())
            {
                CurrencyConverter.UpdateExchangeRates(currencies);
            }

        }

        private async Task<List<CurrencyEntity?>> UpdateCurrenciesAsync(List<CurrencyEntity> currencies)
        {
            // NOTE: currencies are updating per day

            if (currencies.Count == 0 ||
                DateTime.Now.Date > currencies.First().LastUpdatedAt.AddDays(1).Date)
            {
                await ClearCurrencies(currencies);
                currencies = await FetchCurrenciesAsync();

                await _context.AddRangeAsync(currencies);
                await _context.SaveChangesAsync();

                return currencies!;
            }

            return null!;

        }

        private async Task ClearCurrencies(List<CurrencyEntity> currencies)
        {
            foreach (var currency in currencies)
            {
                _context.Currencies.Remove(currency);
            }

            await _context.SaveChangesAsync();
        }

        private async Task<List<CurrencyEntity>> FetchCurrenciesAsync()
        {
            using var client = new HttpClient();

            var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            var response = await client
                .GetAsync($"https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies/ka/json/?date={currentDate}");

            var json = await response.Content.ReadAsStringAsync();
            var exchangeRate = JsonConvert.DeserializeObject<IList<ExchangeRate>>(json);
            var currencies = exchangeRate!.Last().Currencies;

            return currencies!;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

