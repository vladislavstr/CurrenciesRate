using Newtonsoft.Json;

namespace CurrenciesRateBll.Models
{
    public class Currency
    {
        public int Id { get; set; }
        [JsonProperty("ID")]
        public string CbrID { get; set; }
        public string NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Previous { get; set; }
    }
}
