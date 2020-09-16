using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KassaOne.Models
{
    public class CreditViewModel
    {
        [Required]
        public double CreditSum { get; set; }
        [Required]
        public int CreditTime { get; set; }
        [Required]
        public double RatePerYear { get; set; }
        [Required]
        public int OptionValue { get; set; }
    }
}
