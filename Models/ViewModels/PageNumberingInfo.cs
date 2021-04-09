using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2Mock.Models.ViewModels
{
    public class PageNumberingInfo
    {
        //Number of Items that is displayed on the page
        public int NumItemsPerPage { get; set; }

        //Helps the web app know what page the user currently is on
        public int CurrentPage { get; set; }

        //Helps web app know what the total number of items for the desired query is
        public int TotalNumItems { get; set; }

        //Calculate number of pages that the user can navigate to for the given query
        public int NumPages => (int)(Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage));
    }
}
