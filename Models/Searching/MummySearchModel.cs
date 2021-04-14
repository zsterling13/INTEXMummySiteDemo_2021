using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2Mock.Models.Searching
{
    public class MummySearchModel
    {
        //model for searching and filtering through the database

        public string burialLocationNS { get; set; }
        public string burialLocationEW { get; set; }
        public string burialSituation { get; set; }
        public string gender { get; set; }
        public string hairColor { get; set; }
        public string headDirection { get; set; }
        public string yearFound { get; set; }
        public string monthFound { get; set; }
        public bool? artifacts { get; set; }
        public string ageClassification { get; set; }
        public string burialSubplot { get; set; }
        public string burialNumber { get; set; }
        public string preservationIndex { get; set; }
    }

}
