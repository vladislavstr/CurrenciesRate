using CurrenciesRateDal.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrenciesRateDal
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CurrencyContext _context;

        public CurrencyRepository(CurrencyContext context)
        {
            _context = context;
        }

        public async Task<List<CurrencyEntity>> GetAllCurrenciesAsync()
        {
            var result = new List<CurrencyEntity>();

            result = await _context.Currency
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<CurrencyEntity> GetCurrencyByNameAsync(string currencyCode)
        {
            try
            {
                return await _context.Currency
                .SingleAsync(c => c.CharCode == currencyCode);
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException($"Currency with code {currencyCode} not found");
            }
        }

        public async Task<CurrencyEntity> UpdateCurrencyAsync(CurrencyEntity currency)
        {
            try
            {
                var updatedCurrency = await _context.Currency.SingleAsync(c => c.CbrID == currency.CbrID);
                updatedCurrency.Value = currency.Value;
                updatedCurrency.Previous = currency.Previous;

                await _context.SaveChangesAsync();

                return await _context.Currency
                .SingleAsync(c => c.Name == currency.Name);
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException($"Currency with id {currency.CbrID} not found");
            }
        }

        public async Task<CurrencyEntity> AddCurrencyAsync(CurrencyEntity currency)
        {
            try
            {
                await _context.Currency.AddAsync(currency);
                await _context.SaveChangesAsync();

                return await _context.Currency
                    .SingleAsync(c => c.CbrID == currency.CbrID);
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException($"Added Currency with id {currency.CbrID} was failed");
            }
        }

        public async Task<bool> CheckCurrencyByNameAsync(string currencyName)
        {
            return await _context.Currency.AnyAsync(c => c.Name == currencyName);
        }
    }
}