using System;
using Hayaa.BaseModel;

namespace Hayaa.ModelService.Core
{
    public class ModelServer : IModelService
    {
        public FunctionResult<BussinessModel> Create(BussinessModel info)
        {
            throw new NotImplementedException();
        }

        public BaseFunctionResult DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public GridPager<BussinessModel> GetPager(GridPagerPamater<ModelGridPagerSearch> searchParam)
        {
            throw new NotImplementedException();
        }

        public BaseFunctionResult UpdateByID(BussinessModel info)
        {
            throw new NotImplementedException();
        }
    }
}
