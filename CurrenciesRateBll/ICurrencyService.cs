using CurrenciesRateDal.Models;

namespace UsersGroupBll
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrenciesRateDal.Models.Currency>> GetAllCurrency();
    }
}
