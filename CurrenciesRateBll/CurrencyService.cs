
using AutoMapper;
using CurrenciesRateBll.Models;
using CurrenciesRateDal;
using CurrenciesRateDal.Models;
using Newtonsoft.Json;

namespace UsersGroupBll
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currencyRepository;

        private readonly string _url = "https://www.cbr-xml-daily.ru/daily_json.js";

        public CurrencyService(IMapper mapper, ICurrencyRepository currencyRepository)
        {
            _mapper = mapper;
            _currencyRepository = currencyRepository;
        }

        public async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            var currenciesEntitys = await _currencyRepository.GetAllCurrenciesAsync();
            var currenciesResponse = _mapper.Map<List<Currency>>(currenciesEntitys);

            return currenciesResponse;
        }

        public async Task<Currency> GetCurrencyByNameAsync(string name)
        {
            var currencyEntitys = await _currencyRepository.GetCurrencyByNameAsync(name);
            var currencyResponse = _mapper.Map<Currency>(currencyEntitys);

            return currencyResponse;
        }

        public async Task LoadDataOfCurrenciesAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var httpResponse = await httpClient.GetAsync(_url);
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    var post = JsonConvert.DeserializeObject<Root>(jsonResponse);

                    foreach (var value in post.Valute)
                    {
                        CurrencyEntity valueResponse = _mapper.Map<CurrencyEntity>(value.Value);

                        string name = valueResponse.Name;

                        if (await _currencyRepository.CheckCurrencyByNameAsync(name))
                        {
                            await _currencyRepository.UpdateCurrencyAsync(valueResponse);
                        }
                        else
                        {
                            await _currencyRepository.AddCurrencyAsync(valueResponse);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(_url, e);
                }
            }
        }
    }
}
