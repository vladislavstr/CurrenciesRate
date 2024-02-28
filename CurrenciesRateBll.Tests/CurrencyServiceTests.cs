using AutoMapper;
using CurrenciesRateBll.Models;
using CurrenciesRateBll.Tests.TestCaseSource;
using CurrenciesRateDal;
using CurrenciesRateDal.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using UsersGroupBll;
using NUnit.Framework;

namespace CurrenciesRateBll.Tests
{
    public class CurrencyServiceTests
    {
        private CurrencyService _currencyService;
        private Mock<ICurrencyRepository> _CurrencyRepositoryMock;
        private IMapper _mapper;
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperBllCurrencyProfile>();
            }
            ).CreateMapper();

            _CurrencyRepositoryMock = new Mock<ICurrencyRepository>();
            _currencyService = new CurrencyService(_mapper, _CurrencyRepositoryMock.Object, _configuration);
        }

        [TestCaseSource(typeof(CurrencyServiceTestCaseSource), nameof(CurrencyServiceTestCaseSource.LoadDataOfCurrenciesAsyncTestCaseSource))]
        public async Task LoadDataOfCurrenciesAsyncTest()
        {
            throw new NotImplementedException();
        }
    }
}