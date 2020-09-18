using System.ComponentModel.DataAnnotations;

namespace KassaOne.Models
{
    public class ShowModel
    {
        [Required]
        public string CreditSum { get; set; }
        [Required]
        public string PurchasePrice { get; set; }
        [Required]
        public string CreditTime { get; set; }
        [Required]
        public string MonthlyPayment { get; set; }
        [Required]
        public string TotalOverpayment { get; set; }

    }
}
