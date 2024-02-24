using AutoMapper;
using CurrenciesRateApi.Models;
using Microsoft.AspNetCore.Mvc;
using UsersGroupBll;

namespace UsersGroupApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService, IMapper mapper)
        {

            _mapper = mapper;
            _currencyService = currencyService;
        }

        [HttpGet(Name = "GET/currencies")]
        public async Task<ActionResult<List<CurrencyResponseDto>>> GetAllCurrencies()
        {

            return Ok();
        }

        [HttpGet("{id:int}", Name = "GET/currency")]
        public async Task<ActionResult<CurrencyResponseDto>> GetCurrencyByName(string name)
        {
            return Ok();
        }

    }
}
