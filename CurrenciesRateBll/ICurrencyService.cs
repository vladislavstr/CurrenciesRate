using CurrenciesRateBll.Models;

namespace UsersGroupBll
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetAllCurrencies();
        Task<Currency> GetCurrencyByName(string name);
        Task<List<Currency>> LoadDataOfCurrencies();
    }
}
