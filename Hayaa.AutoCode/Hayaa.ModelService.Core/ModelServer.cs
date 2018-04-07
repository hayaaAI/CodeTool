using System;
using System.Collections.Generic;
using Hayaa.BaseModel;

namespace Hayaa.ModelService.Core
{
    public class ModelServer : IModelService
    {
        public FunctionResult<BussinessModel> Create(BussinessModel info)
        {
            throw new NotImplementedException();
        }

        public FunctionOpenResult<bool> DeleteByID(List<int> idList)
        {
            throw new NotImplementedException();
        }

        public GridPager<BussinessModel> GetPager(GridPagerPamater<ModelGridPagerSearch> searchParam)
        {
            throw new NotImplementedException();
        }

        public FunctionOpenResult<bool> UpdateByID(BussinessModel info)
        {
            throw new NotImplementedException();
        }
    }
}
