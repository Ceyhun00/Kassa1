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
        public string PayMain { get; set; }
        [Required]
        public string PayPercent { get; set; }
        [Required]
        public string RemainingAmount { get; set; }

        public ShowTable(int monthNum,string monthlyPayment, string payMain, string payPercent,string remainingAmount)
        {
            MonthNum = monthNum;
            MonthlyPayment = monthlyPayment;
            PayMain = payMain;
            PayPercent = payPercent;
            RemainingAmount = remainingAmount;
        }
    }
}
