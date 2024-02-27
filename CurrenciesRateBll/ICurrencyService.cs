using CurrenciesRateBll.Models;

namespace UsersGroupBll
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetAllCurrenciesAsync();
        Task<Currency> GetCurrencyByNameAsync(string name);
        Task LoadDataOfCurrenciesAsync();
    }
}
