using CurrenciesRateDal.Models;

namespace CurrenciesRateDal
{
    public interface ICurrencyRepository
    {
        Task<List<CurrencyEntity>> GetAllCurrenciesAsync();
        Task<CurrencyEntity> GetCurrencyByNameAsync(string currencyName);
        Task<CurrencyEntity> UpdateCurrencyAsync(CurrencyEntity currency);
        Task<CurrencyEntity> AddCurrencyAsync(CurrencyEntity currency);
        Task<bool> CheckCurrencyByNameAsync(string currencyName);
    }
}
