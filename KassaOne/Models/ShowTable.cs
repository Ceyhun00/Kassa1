using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public string SumCreditLast { get; set; }

        public ShowTable(int monthNum,string monthlyPayment, string payMain, string payPercent,string sumCreditLast)
        {
            MonthNum = monthNum;
            MonthlyPayment = monthlyPayment;
            PayMain = payMain;
            PayPercent = payPercent;
            SumCreditLast = sumCreditLast;
        }
    }
}
