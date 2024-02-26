
using AutoMapper;
using CurrenciesRateBll.Models;
using CurrenciesRateDal;
using Newtonsoft.Json;

namespace UsersGroupBll
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currencyRepository;

        private readonly string _url = "https://www.cbr-xml-daily.ru/daily_json.js";

        public CurrencyService (IMapper mapper, ICurrencyRepository currencyRepository)
        {
            _mapper = mapper;
            _currencyRepository = currencyRepository;
        }

        public Task<List<Currency>> GetAllCurrencies()
        {
            throw new NotImplementedException();
        }

        public Task<Currency> GetCurrencyByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Currency>> LoadDataOfCurrencies()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var httpResponse = await httpClient.GetAsync(_url);
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    var post = JsonConvert.DeserializeObject<Root>(jsonResponse);

                    throw new NotImplementedException();
                }
                catch (Exception e)
                {
                    throw new Exception(_url, e);
                }
            }
        }
    }
}
