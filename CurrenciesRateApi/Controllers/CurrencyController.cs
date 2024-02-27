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

        [HttpGet("currencies", Name = "GET/currencies")]
        public async Task<ActionResult<List<CurrencyResponseDto>>> GetAllCurrencies()
        {
            try
            {
                var currenciesResponse = await _currencyService.GetAllCurrenciesAsync();
                var currenciesResponseDto = _mapper.Map<List<CurrencyResponseDto>>(currenciesResponse);

                return Ok(currenciesResponseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("currency/{name}", Name = "GET/currency/")]
        public async Task<ActionResult<CurrencyResponseDto>> GetCurrencyByName(string name)
        {
            try
            {
                var currencyResponse = await _currencyService.GetCurrencyByNameAsync(name);
                var currencyResponseDto = _mapper.Map<CurrencyResponseDto>(currencyResponse);

                return Ok(currencyResponseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
