using CurrenciesRateDal.Models;

namespace CurrenciesRateDal
{
    public interface ICurrencyRepository
    {
        Task<List<CurrencyEntity>> GetAllCurrencies();
        Task<CurrencyEntity> GetCurrencyByName(string currencyName);
        Task<CurrencyEntity> UpdateCurrency(CurrencyEntity currency);
        Task<CurrencyEntity> AddCurrency(CurrencyEntity currency);
        Task<bool> CheckCurrencyByName(string currencyName);
    }
}
