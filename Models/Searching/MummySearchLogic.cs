using INTEX2Mock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2Mock.Models.Searching
{
    public class MummySearchLogic
    {
        private MummyDbContext _mummyContext { get; set; }

        public MummySearchLogic(MummyDbContext mummyContext)
        {
            _mummyContext = mummyContext;
        }

        public IQueryable<Mummy> GetMummies(MummySearchModel searchModel, int pageNum = 1, int pageSize = 5)
        {

            var result = _mummyContext.Mummies.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.MummyID.HasValue)
                {
                    result = result.Where(x => x.MummyID == searchModel.MummyID);
                }
                if(!string.IsNullOrEmpty(searchModel.Name))
                {
                    result = result.Where(x => x.Name.Contains(searchModel.Name));
                }
                if(searchModel.AgeFrom.HasValue)
                {
                    result = result.Where(x => x.Age >= searchModel.AgeFrom);
                }
                if(searchModel.AgeTo.HasValue)
                {
                    result = result.Where(x => x.Age <= searchModel.AgeTo);
                }

            }

            return result;
        }
    }
}
