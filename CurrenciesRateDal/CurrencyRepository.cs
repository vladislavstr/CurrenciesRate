using CurrenciesRateDal.Models;

namespace CurrenciesRateDal
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public Task<IEnumerable<CurrencyEntity>> GetAllCurrencies()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CurrencyEntity>> UpdateAllCurrencies()
        {
            throw new NotImplementedException();
        }
    }
}
