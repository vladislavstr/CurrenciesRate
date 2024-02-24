using CurrenciesRateBll.Models;

namespace UsersGroupBll
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrenciesRateBll.Models.Currency>> GetAllCurrency();
    }
}
