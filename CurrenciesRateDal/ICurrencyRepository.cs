using CurrenciesRateDal.Models;

namespace CurrenciesRateDal
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<CurrencyEntity>> GetAllCurrencies();
        Task<IEnumerable<CurrencyEntity>> UpdateAllCurrencies();
    }
}
