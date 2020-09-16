using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KassaOne.Models
{
    public class ResultViewModel
    {
        public List<ShowTable> ShowTable { get; set; }
        public ShowModel ShowModel { get; set; }
        public ResultViewModel(ShowModel showModel,List<ShowTable> showTable)
        {
            this.ShowModel = showModel;
            this.ShowTable = showTable;
        }
    }
}
