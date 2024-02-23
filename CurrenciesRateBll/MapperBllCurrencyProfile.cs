using AutoMapper;
using CurrenciesRateDal.Models;

namespace UsersGroupBll
{
    public class MapperBllCurrencyProfile : Profile
    {
        public MapperBllCurrencyProfile()
        {
            CreateMap<CurrencyEntity, Currency>();
        }
    }
}
