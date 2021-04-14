using INTEX2Mock.Models.Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2Mock.Models.ViewModels
{
    public class SeeMummiesViewModel
    {
        //view model for pagination, filtering, and viewing mummies
        public IEnumerable<MainTable> Mummies { get; set; }

        public PageNumberingInfo PageNumberingInfo { get; set; }

        public MummySearchModel mummySearchModel { get; set; }

        public string UrlInfo { get; set; }
    }
}
