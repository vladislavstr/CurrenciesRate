using System.ComponentModel.DataAnnotations;

namespace CurrenciesRateDal.Models
{
    public class CurrencyEntity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string CbrID { get; set; }
        [Required]
        public string NumCode { get; set; }
        [Required]
        public string CharCode { get; set; }
        [Required]
        public string Nominal { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string Previous { get; set; }

    }
}
