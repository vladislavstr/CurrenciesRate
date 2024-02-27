namespace CurrenciesRateApi.Models
{
    public class CurrencyResponseDto
    {
        public string CharCode { get; set; }
        public string Name { get; set; }

        public double ConvertedValue
        {
            get { return Value / Nominal; }
        }
        public double Value { private get; set; }
        public int Nominal { private get; set; }
    }
}
