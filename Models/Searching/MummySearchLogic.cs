using INTEX2Mock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2Mock.Models.Searching
{
    public class MummySearchLogic
    {
        private PWOIKMContext _mummyContext { get; set; }

        public MummySearchLogic(PWOIKMContext mummyContext)
        {
            _mummyContext = mummyContext;
        }

        public IQueryable<MainTable> GetMummies(MummySearchModel searchModel)
        {

            var result = _mummyContext.MainTables.AsQueryable();
            if (searchModel != null)
            {
                if(!string.IsNullOrEmpty(searchModel.burialLocationNS))
                {
                    result = result.Where(x => x.BurialLocationNs.Contains(searchModel.burialLocationNS));
                }
                if (!string.IsNullOrEmpty(searchModel.burialLocationEW))
                {
                    result = result.Where(x => x.BurialLocationEw.Contains(searchModel.burialLocationEW));
                }
                if (!string.IsNullOrEmpty(searchModel.yearFound))
                {
                    result = result.Where(x => x.YearFound.Contains(searchModel.yearFound));
                }
                if (searchModel.artifacts.HasValue)
                {
                    result = result.Where(x => x.ArtifactFound == searchModel.artifacts);
                }
                if (!string.IsNullOrEmpty(searchModel.gender))
                {
                    if (searchModel.gender == "F")
                    {
                        result = result.Where(x => x.GenderBodyCol == "Female" || x.GenderBodyCol == "F");
                    }
                    else if (searchModel.gender == "M")
                    {
                        result = result.Where(x => x.GenderBodyCol == "Male" || x.GenderBodyCol == "M");
                    }
                    else
                    {
                        result = result.Where(x => x.GenderBodyCol.Contains(searchModel.gender));
                    }
                    
                }
                if (!string.IsNullOrEmpty(searchModel.burialSituation))
                {
                    result = result.Where(x => x.BurialSituation.Contains(searchModel.burialSituation));
                }
                if (!string.IsNullOrEmpty(searchModel.hairColor))
                {
                    result = result.Where(x => x.HairColor.Contains(searchModel.hairColor));
                }
                if (!string.IsNullOrEmpty(searchModel.headDirection))
                {
                    result = result.Where(x => x.HeadDirection.Contains(searchModel.headDirection));
                }
                if (!string.IsNullOrEmpty(searchModel.ageClassification))
                {
                    if (searchModel.ageClassification == "NI")
                    {
                        result = result.Where(x => x.AgeClassification == "N" || x.AgeClassification == "I" || x.AgeClassification == "Ni");
                    }
                    else
                    {
                        result = result.Where(x => x.AgeClassification.Contains(searchModel.ageClassification));
                    }
                    
                }
                if (!string.IsNullOrEmpty(searchModel.burialSubplot))
                {
                    result = result.Where(x => x.BurialSubplot.Contains(searchModel.burialSubplot));
                }
                if (!string.IsNullOrEmpty(searchModel.burialNumber))
                {
                    result = result.Where(x => x.BurialNumber == searchModel.burialNumber);
                }
                if (!string.IsNullOrEmpty(searchModel.headDirection))
                {
                    if (searchModel.headDirection == "E")
                    {
                        result = result.Where(x => x.HeadDirection == "East" || x.HeadDirection == "E");
                    }
                    else if (searchModel.headDirection == "W")
                    {
                        result = result.Where(x => x.HeadDirection == "West" || x.HeadDirection == "W");
                    }
                    else
                    {
                        result = result.Where(x => x.HeadDirection.Contains(searchModel.headDirection));
                    }

                }
                if (!string.IsNullOrEmpty(searchModel.preservationIndex))
                {
                    if (searchModel.preservationIndex == "II")
                    {
                        result = result.Where(x => x.PreservationIndex == "II");
                    }
                    else if (searchModel.preservationIndex == "I")
                    {
                        result = result.Where(x => x.PreservationIndex == "I");
                    }
                    else if (searchModel.preservationIndex == "III")
                    {
                        result = result.Where(x => x.PreservationIndex == "III");
                    }
                    else if (searchModel.preservationIndex == "IV")
                    {
                        result = result.Where(x => x.PreservationIndex == "IV");
                    }
                    else if (searchModel.preservationIndex == "V")
                    {
                        result = result.Where(x => x.PreservationIndex == "V");
                    }
                    else
                    {
                        result = result.Where(x => x.PreservationIndex.Contains(searchModel.preservationIndex));
                    }

                }
            }

            return result;
        }
    }
}
