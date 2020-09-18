using System.Collections.Generic;

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
