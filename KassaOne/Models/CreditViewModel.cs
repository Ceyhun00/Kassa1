using System.ComponentModel.DataAnnotations;

namespace KassaOne.Models
{
    public class CreditViewModel
    {
        [Required]
        public double CreditSum { get; set; }
        [Required]
        public int NumberOfPayments { get; set; }
        [Required]
        public double RatePerYear { get; set; }
        [Required]
        public int OptionValue { get; set; }
    }
}
