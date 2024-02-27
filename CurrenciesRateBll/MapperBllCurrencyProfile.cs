using AutoMapper;
using CurrenciesRateBll.Models;
using CurrenciesRateDal.Models;

namespace UsersGroupBll
{
    public class MapperBllCurrencyProfile : Profile
    {
        public MapperBllCurrencyProfile()
        {
            CreateMap<CurrencyEntity, Currency>().ReverseMap();
        }
    }
}
