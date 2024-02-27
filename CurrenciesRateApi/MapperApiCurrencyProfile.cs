using AutoMapper;
using CurrenciesRateApi.Models;
using CurrenciesRateBll.Models;

namespace UsersGroupApi
{
    public class MapperApiCurrencyProfile : Profile
    {
        public MapperApiCurrencyProfile()
        {
            CreateMap<Currency, CurrencyResponseDto>();
        }
    }
}
