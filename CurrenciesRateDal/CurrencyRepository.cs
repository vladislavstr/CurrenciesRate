using CurrenciesRateDal.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrenciesRateDal
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private static CurrencyContext _context;

        public CurrencyRepository(CurrencyContext context)
        {
            _context = context;
        }
        public async Task<List<CurrencyEntity>> GetAllCurrencies()
        {
            var result = new List<CurrencyEntity>();

            result = _context.Currency
                .AsNoTracking()
                .ToList();

            return result;
        }

        public async Task<CurrencyEntity> GetCurrencyByName(string currencyName)
        {
            try
            {
                return _context.Currency
                .Single(c => c.Name == currencyName);
            }
            catch (Exception exception)
            {
                throw new FileNotFoundException($"Currency with name {currencyName} not found");
            }
        }

        public async Task<CurrencyEntity> UpdateCurrency(CurrencyEntity currency)
        {
            try
            {
                var updatedCurrency = _context.Currency.Single(c => c.Id == currency.Id);
                updatedCurrency.Value = currency.Value;
                _context.SaveChanges();

                return _context.Currency
                .Single(c => c.Name == currency.Name);
            }
            catch (Exception exception)
            {
                throw new FileNotFoundException($"Currency with id {currency.Id} not found");
            }
        }

        public async Task<CurrencyEntity> AddCurrency(CurrencyEntity currency)
        {
            _context.Currency.Add(currency);
            _context.SaveChanges();

            return _context.Currency
                .Single(c => c.Name == currency.Name);
        }

        public async Task<bool> CheckCurrencyByName(string currencyName)
        {
            return _context.Currency.Include(c => c.Id).Any(c => c.Name == currencyName);
        }
    }
}