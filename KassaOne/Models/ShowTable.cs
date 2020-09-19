using System.ComponentModel.DataAnnotations;

namespace KassaOne.Models
{
    public class ShowTable
    {
        [Required]
        public int MonthNum { get; set; }
        [Required]
        public string MonthlyPayment { get; set; }
        [Required]
        public string MainPart { get; set; } //часть погашения долга от ежемесячного платежа
        [Required]
        public string PercentPart { get; set; } //часть погашения процентов от ежемесячного платежа
        [Required]
        public string RemainingAmount { get; set; }

        public ShowTable(int monthNum,string monthlyPayment, string mainPart, string percentPart,string remainingAmount)
        {
            MonthNum = monthNum;
            MonthlyPayment = monthlyPayment;
            MainPart = mainPart;
            PercentPart = percentPart;
            RemainingAmount = remainingAmount;
        }
    }
}
