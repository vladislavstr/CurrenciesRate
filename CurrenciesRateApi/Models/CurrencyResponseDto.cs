﻿namespace CurrenciesRateApi.Models
{
    public class CurrencyResponseDto
    {
        public string Id { get; set; }
        public string CbrID { get; set; }
        public string NumCode { get; set; }
        public string CharCode { get; set; }
        public string Nominal { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Previous { get; set; }
    }
}
