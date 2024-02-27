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
        public async Task<ActionResult<List<CurrencyResponseDto>>> GetAllCurrencies(int page = 1, int pageSize = 10)
        {
            try
            {
                if (page < 1 || pageSize < 1)
                {
                    return BadRequest("Invalid page or pageSize values");
                }

                var currenciesResponse = await _currencyService.GetAllCurrenciesAsync();
                var currenciesResponseDtoList = _mapper.Map<List<CurrencyResponseDto>>(currenciesResponse);

                int currenciesResponseDtoCount = currenciesResponseDtoList.Count;
                int currenciesResponseDtoTotalPages = (int)Math.Ceiling((decimal)currenciesResponseDtoCount / pageSize);

                if (page > currenciesResponseDtoTotalPages)
                {
                    return NotFound("Requested page not found");
                }

                var currenciesResponseDtoPerPage = currenciesResponseDtoList
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return Ok(currenciesResponseDtoPerPage);
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
